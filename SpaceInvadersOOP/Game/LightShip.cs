using System;
using System.Collections.Generic;

namespace Game
{
    class LightShip : UserShip
    {
        #region Properties

        public override byte HP { get; set; }

        public override byte OldHP { get; set; }

        //public override byte Width { get; set; }

        #endregion

        #region Constructors

        public LightShip(ISpace game, int coordX, int coordY, bool active,
                uint speed, uint counter, byte hitpoints, byte lifes)
            : base(game, coordX, coordY, active, speed, counter, 
                    hitpoints, lifes)
        {
            SetPosition();
        }

        private void SetPosition()
        {
            Position = new HashSet<Coordinate>(19, new Comparer())
            {
                new Coordinate(56, 28),
                new Coordinate(56, 29),
                new Coordinate(54, 30),
                new Coordinate(56, 30),
                new Coordinate(58, 30),
                new Coordinate(52, 31),
                new Coordinate(53, 31),
                new Coordinate(54, 31),
                new Coordinate(55, 31),
                new Coordinate(56, 31),
                new Coordinate(57, 31),
                new Coordinate(58, 31),
                new Coordinate(59, 31),
                new Coordinate(60, 31),
                new Coordinate(54, 32),
                new Coordinate(55, 32),
                new Coordinate(56, 32),
                new Coordinate(57, 32),
                new Coordinate(58, 32)
            };

            OldPosition = new HashSet<Coordinate>(19, new Comparer());

            foreach (var item in Position)
            {
                OldPosition.Add(new Coordinate(item));
            }

            foreach (var item in OldPosition)
            {
                item.X++;
                item.Y++;
                break;
            }
        }

        #endregion

        #region Member Functions

        public override void Step()
        {
            HashSet<Coordinate> temp = null;

            switch (_keyEvent?.Invoke())
            {
                case Action.LeftMove:

                    if (!IsCross())
                    {
                        temp = new HashSet<Coordinate>(19, new Comparer());

                        foreach (var item in Position)
                        {
                            temp.Add(new Coordinate(--item.X, item.Y)); 
                        } 
                    }
                    break;

                case Action.RightMove:

                    if (!IsCross())
                    {
                        temp = new HashSet<Coordinate>(19, new Comparer());

                        foreach (var item in Position)
                        {
                            temp.Add(new Coordinate(++item.X, item.Y));
                        }
                    }
                    break;

                case Action.UpMove:

                    if (!IsCross())
                    {
                        temp = new HashSet<Coordinate>(19, new Comparer());

                        foreach (var item in Position)
                        {
                            temp.Add(new Coordinate(item.X, --item.Y));
                        }
                    }
                    break;

                case Action.DownMove:

                    if (!IsCross())
                    {
                        temp = new HashSet<Coordinate>(19, new Comparer());

                        foreach (var item in Position)
                        {
                            temp.Add(new Coordinate(item.X, ++item.Y));
                        }
                    }
                    break;

                case Action.Shooting:
                    _game.AddObject(SpaceObject.ShotLeft);
                    _game.AddObject(SpaceObject.ShotRight);
                    break;
                case Action.NoAction:
                    break;

                default:
                    break;
            }

            if (temp != null)
            {
                Position.Clear();
                Position.TrimExcess();
                Position.UnionWith(temp);
                temp.Clear(); 
                temp.TrimExcess();
            }
        }

        private bool IsCross()
        {
            bool result = Position.Overlaps(_game.Borders);

            return result;
        }

        #endregion
    }
}
