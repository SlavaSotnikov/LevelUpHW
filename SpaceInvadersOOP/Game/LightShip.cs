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
            Position = SetInitPosition();
            OldPosition = SetOldPosition();
        }

        private HashSet<Coordinate> SetOldPosition()
        {
            HashSet<Coordinate> result = new HashSet<Coordinate>(19, new CoordinateComparer());

            for (int i = 0; i < 19; i++)
            {
                result.Add(new Coordinate(i, 0));    // TODO: ???
            }

            return result;
        }

        private HashSet<Coordinate> SetInitPosition()
        {
            HashSet<Coordinate> result = new HashSet<Coordinate>(19, new CoordinateComparer())
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

            return result;
        }

        #endregion

        #region Member Functions

        public override void Step()
        {
            switch (_keyEvent?.Invoke())
            {
                case Action.LeftMove:

                    if (!IsCross())
                    {
                        foreach (var item in Position)
                        {
                            --item.X;
                        } 
                    }
                    
                    break;

                case Action.RightMove:

                    if (!IsCross())
                    {
                        foreach (var item in Position)
                        { ++item.X; }
                    }
                    break;

                case Action.UpMove:

                    if (!IsCross())
                    {
                        foreach (var item in Position)
                        { --item.Y; }
                    }
                    break;

                case Action.DownMove:

                    if (!IsCross())
                    {
                        foreach (var item in Position)
                        { ++item.Y; }
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
        }

        private bool IsCross()
        {
            bool result = Position.Overlaps(_game.Borders);

            return result;
        }

        #endregion
    }
}
