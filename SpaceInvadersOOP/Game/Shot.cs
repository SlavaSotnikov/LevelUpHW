using System;

namespace Game
{
    class Shot : SpaceCraft
    {
        #region Private Data

        private string[] _image = { "|" };

        #endregion

        #region Properties

        public override string[] View
        {
            get
            {
               return _image;
            }
        }
        #endregion

        #region Constructors

        public Shot(int x, int y, int oldX, int oldY, uint speed = 5000, uint counter = 0)
        {
            _coordX = x;
            _coordY = y;
            _oldCoordX = oldX;
            _oldCoordY = oldY;
            _speed = speed;
            _counter = counter;
            _active = true;
        }

        public Shot(Shot source)
            : base()
        {
        }

        #endregion

        #region Methods

        public override void Step()
        {
            _coordY -= STEP;
        }

        #endregion
    }
}