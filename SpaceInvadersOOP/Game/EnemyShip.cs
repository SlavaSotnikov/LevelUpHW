using System;

namespace Game
{
    class EnemyShip : Ship
    {
        private static int _enemyAmount = 0;
        private static int _oldEnemyAmount = 0;

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

        public EnemyShip(GameField game, int coordX, int coordY, bool active, 
                uint speed, uint counter=0, int oldCoordX=0, int oldCoordY=0)
        {
            _game = game;
            _coordX = coordX;
            _coordY = coordY;
            _oldCoordX = oldCoordX;
            _oldCoordY = oldCoordY;
            _active = true;
            _counter = 0;
            _speed = speed;
            ++_enemyAmount;
        }
        public override void Step()
        {
            _coordY += step;
        }
    }
}