using System;

namespace Game
{
    class EnemyShip : Ship
    {
        private static int _enemyAmount = 0;
        private static int _oldEnemyAmount = 0;

        private uint _rateOfFire;
        private uint _countOfFire;

        public uint RateOfFire 
        {
            get
            {
                return _rateOfFire;
            }
        }

        public uint CountOfFire
        {
            get
            {
                return _countOfFire;
            }
            set
            {
                _countOfFire = value;
            }
        }

        public static int EnemyAmount
        {
            get
            {
                return _enemyAmount;
            }
            set
            {
                _enemyAmount = value;
            }
        }
        public static int OldEnemyAmount
        {
            get
            {
                return _oldEnemyAmount;
            }
            set
            {
                _oldEnemyAmount = value;
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

        ~EnemyShip()
        {
            --_enemyAmount;
        }

        public EnemyShip(GameField game, int coordX, int coordY, bool active, 
                uint speed, uint rateOfFire, uint counter=0, int oldCoordX=0, int oldCoordY=0, byte hitPoints = 6)
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
            _rateOfFire = rateOfFire;
            ++_enemyAmount;
        }

        public override void Step()
        {
            _coordY += _step;
        }
    }
}