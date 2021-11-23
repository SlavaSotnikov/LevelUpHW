using System;

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
        }

        #endregion

        #region Methods

        public override void Step()
        {
            //Y -= _step;
        }

        #endregion
    }
}