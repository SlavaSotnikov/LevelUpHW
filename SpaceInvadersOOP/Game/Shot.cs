using System;

namespace Game
{
    class Shot : SpaceCraft
    {
        #region Constructors

        public Shot(int x, int y, int oldX=0, int oldY=0, uint speed = 5000, uint counter = 0)
        {
            _coordX = x;
            _coordY = y;
            _oldCoordX = oldX;
            _oldCoordY = oldY;
            _speed = speed;
            _counter = counter;
            _active = true;
        }

        //public Shot(Shot source)
        //    : base()
        //{
        //}

        #endregion

        #region Methods

        public override void Step()
        {
            _coordY -= STEP;
        }

        #endregion
    }
}