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

            Position = new HashSet<Coord>(1);
            Position.Add(new Coord(x, y));

            OldPosition = new HashSet<Coord>(1);
         
            NextPosition = new HashSet<Coord>(1);
        }

        #endregion

        #region Methods

        public override void Step()
        {
            //Y -= _step;
            
            int y;
            foreach (var item in Position)
            {
                y = item.Y;
                NextPosition.Add(new Coord(item.X, --y));
            }

            Position.Clear();
            Position.UnionWith(NextPosition);
            NextPosition.Clear();
        }

        #endregion
    }
}