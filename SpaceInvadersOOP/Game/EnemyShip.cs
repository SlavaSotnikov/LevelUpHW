using System;

namespace Game
{
    class EnemyShip : Ship
    {
        #region Private Data

        private byte _shot;

        #endregion

        #region Properties

        public byte Shot
        {
            get
            {
                return _shot;
            }
            set
            {
                _shot = value;
            }
        }

        public override byte HitPoints
        {
            get
            {
                return _hitPoints;
            }

            set
            {
                _hitPoints = value;
            }
        }

        public override byte OldHitPoints
        {
            get
            {
                return _oldHitPoints;
            }

            set
            {
                _oldHitPoints = value;
            }
        }

        public override byte Width
        {
            get
            {
                return _width;
            }
        }

        #endregion

        #region Constructor

        public EnemyShip(ISpace game, int coordX, int coordY, bool active,
                uint speed, sbyte step, byte rndY, uint counter = 0,
                    int oldCoordX = 0, int oldCoordY = 0, byte hitPoints = 6)
        {
            _game = game;
            _coordX = coordX;
            _coordY = coordY;
            _oldCoordX = oldCoordX;
            _oldCoordY = oldCoordY;
            _active = true;
            _counter = 0;
            _speed = speed;
            _hitPoints = hitPoints;
            _shot = rndY;
            _step = step;
            _width = 7;
        }

        #endregion

        #region Member Functions

        public override void Step()
        {
            _coordY += _step;
        }

        #endregion
    }
}