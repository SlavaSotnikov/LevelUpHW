using System;
using System.Collections.Generic;

namespace Game
{
    internal class Shot : SpaceCraft
    {
        #region Constructors

        public Shot(int x, int y, sbyte step, uint speed, SpaceObject source = SpaceObject.ShotLeft)
            :base(source)
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

            OldPosition = new HashSet<Coordinate>(1);

            NextPosition = new HashSet<Coordinate>(1);
        }

        #endregion

        #region Methods

        public override void Step()
        {
            //Y -= _step;

            foreach (var item in Position)
            {
                int y = item.Y;
                NextPosition.Add(new Coordinate(item.X, y - _step));
            }

            Position.Clear();
            Position.UnionWith(NextPosition);
            NextPosition.Clear();
        }

        #endregion
    }
}