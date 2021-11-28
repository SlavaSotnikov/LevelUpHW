using System;
using System.Collections.Generic;

namespace Game
{
    internal class Shot : SpaceCraft
    {
        #region Constructors

        public Shot(int x, int y, sbyte step, uint speed)
        {
            //X = x;
            //Y = y;
            //OldX = 0;
            //OldY = 0;
            Counter = 0;
            Speed = speed;
            Active = true;
            _step = step;

            Position = new HashSet<Coordinate>(1)
            {
                new Coordinate(x, y)
            };

            OldPosition = new HashSet<Coordinate>(1)
            {
                new Coordinate(x - 1, y - 1)
            };

            Temp = new HashSet<Coordinate>(1);
        }

        #endregion

        #region Methods

        public override void Step()
        {
            //Y -= _step;
            int y = 0;
            foreach (var item in Position)
            {
                y = item.Y;
                Temp.Add(new Coordinate(item.X, --y));
            }

            Position.Clear();
            foreach (var item in Temp)
            {
                Position.Add(new Coordinate(item));
            }
            Temp.Clear();
        }

        #endregion
    }
}