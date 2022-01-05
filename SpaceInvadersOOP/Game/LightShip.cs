using System;
using System.Collections.Generic;

namespace Game
{
    internal class LightShip : UserShip
    {
        #region Properties

        public override byte HP { get; set; }

        public override byte OldHP { get; set; }

        //public override byte Width { get; set; }

        #endregion

        #region Constructors

        public LightShip(ISpace game, int coordX, int coordY, bool active,
                uint speed, uint counter, byte hitpoints, byte lifes, SpaceObject source = SpaceObject.LightShip)
            : base(game, coordX, coordY, active, speed, counter,
                    hitpoints, lifes, source)
        {
            SetPosition();
        }

        private void SetPosition()
        {
            Position = new HashSet<Coordinate>(19)
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

            OldPosition = new HashSet<Coordinate>(19);

            int x = 0;
            foreach (var item in Position)
            {
                x = item.X;

                OldPosition.Add(new Coordinate(++x, item.Y));
            }

            NextPosition = new HashSet<Coordinate>();
        }

        #endregion

        #region Member Functions

        public override void Step()
        {
            switch (_keyEvent?.Invoke())
            {
                case Action.LeftMove:

                    FakeShift(NextPosition, -1, 0);

                    if (!NextPosition.Overlaps(_game.Borders))
                    {
                        Move();
                    }
                    break;

                case Action.RightMove:

                    FakeShift(NextPosition, 1, 0);

                    if (!NextPosition.Overlaps(_game.Borders))
                    {
                        Move();
                    }
                    break;

                case Action.UpMove:

                    FakeShift(NextPosition, 0, -1);

                    if (!NextPosition.Overlaps(_game.Borders))
                    {
                        Move();
                    }
                    break;

                case Action.DownMove:

                    FakeShift(NextPosition, 0, 1);

                    if (!NextPosition.Overlaps(_game.Borders))
                    {
                        Move();
                    }
                    break;

                case Action.Shooting:
                    _game.AddObject(SpaceObject.ShotLeft);
                    //_game.AddObject(SpaceObject.ShotRight);
                    break;
                case Action.NoAction:
                    break;

                default:
                    break;
            }

            NextPosition.Clear();
        }

        private void Move()
        {
            Position.Clear();

            foreach (var item in NextPosition)
            {
                Position.Add(new Coordinate(item));
            }
        }

        private void FakeShift(HashSet<Coordinate> source, int x, int y)
        {
            foreach (var item in Position)
            {
                source.Add(new Coordinate(item.X + x, item.Y + y));
            }
        }

        #endregion
    }
}
