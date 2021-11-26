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

            Position = new HashSet<Coordinate>(1, new Comparer())
            {
                new Coordinate(x, y)
            };

            OldPosition = new HashSet<Coordinate>(1, new Comparer())
            {
                new Coordinate(x - 1, y - 1)
            };
        }

        #endregion

        #region Methods

        public override void Step()
        {
            //Y -= _step;
            HashSet<Coordinate> temp = new HashSet<Coordinate>(7, new Comparer());

            foreach (var item in Position)
            {
                temp.Add(new Coordinate(item.X, --item.Y));
            }

            Position.Clear();
            Position.TrimExcess();
            Position.UnionWith(temp);
            temp.Clear();
            temp.TrimExcess();
        }

        #endregion
    }
}