using System;

namespace Game
{
    class EnemyShip : Ship
    {
        private static int _enemyAmount = 0;
        private static int _oldEnemyAmount = 0;

        private byte _shot;

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

        public EnemyShip(Space game, int coordX, int coordY, bool active, 
                uint speed, sbyte step, byte rndY, uint counter=0, int oldCoordX=0, int oldCoordY=0, byte hitPoints = 6)
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
            ++_enemyAmount;
        }

        public override void Step()
        {
            _coordY += _step;
        }
    }
}