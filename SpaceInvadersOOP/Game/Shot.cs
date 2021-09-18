using System;

namespace Game
{
    class Shot : SpaceCraft
    {
        #region Constructors

        public Shot(int x, int y, sbyte step, uint speed,
                int oldX=0, int oldY=0, uint counter = 0)
        {
            _coordX = x;
            _coordY = y;
            _oldCoordX = oldX;
            _oldCoordY = oldY;
            _speed = speed;
            _counter = counter;
            _active = true;
            _step = step;
        }

        #endregion

        #region Methods

        public override void Step()
        {
            OldX = X;
            OldY = Y;

            _coordY -= _step;
        }

        #endregion
    }
}