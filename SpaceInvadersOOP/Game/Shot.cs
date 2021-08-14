using System;

namespace Game
{
    class Shot : SpaceCraft
    {
        private static int _shotAmount = 0;
        private static int _oldShotAmount = 0;

        public static int ShotAmount
        {
            get
            {
                return _shotAmount;
            }
            set
            {
                _shotAmount = value;
            }
        }
        public static int OldShotAmount
        { 
            get
            {
                return _oldShotAmount;
            }
            set
            {
                _oldShotAmount = value;
            }
        }

        #region Constructors

        public Shot(int x, int y, int oldX=0, int oldY=0, 
                uint speed = 5000, uint counter = 0)
        {
            ++_shotAmount;
            _coordX = x;
            _coordY = y;
            _oldCoordX = oldX;
            _oldCoordY = oldY;
            _speed = speed;
            _counter = counter;
            _active = true;
        }

        #endregion

        #region Methods

        public override void Step()
        {
            _coordY -= _step;
        }

        #endregion
    }
}