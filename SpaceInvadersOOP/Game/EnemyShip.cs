using System;

namespace Game
{
    class EnemyShip : Ship
    {
        #region Private Data

        private string[] _image = new string[3]
        {
        "╲(|-|)╱",
        "˂=-O-=˃",
        "   ˅   "
        };

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

        public EnemyShip()
        {
            _coordX = BL_Random.GetCoordinateX();
            _coordY = 1;
            _oldCoordX = 2;
            _oldCoordY = 2;
            _active = true;
            _counter = 0;
            _speed = BL_Random.GetFlySpeed();
        }
        public override void Step()
        {
            _coordY += STEP;
        }
    }
}