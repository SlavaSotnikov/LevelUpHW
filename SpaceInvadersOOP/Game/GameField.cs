using System;

namespace Game
{
    class GameField
    {
        public const int LEFT_BORDER = 30;    // The Left border of game field.
        public const int RIGHT_BORDER = 83;   // The Right border of game field.
        public const int TOP_BORDER = 0;      // The Top border of game field.
        public const int BOTTOM_BORDER = 33;  // The Bottom border of game field.
        private const int RESET = 0;


        private SpaceCraft[] _gameObjects;
        private int _amountOfObjects;
        private int _counterProduceEnemy;
        private int _speed;

        public GameField(int capacity = 20, int amount = 0, int speed = 350000)
        {
            _gameObjects = new SpaceCraft[capacity];
            _amountOfObjects = amount;
            _counterProduceEnemy = amount;
            _speed = speed;
        }

        public bool IsgameOver()
        {
            return false;
        }

        public void Run()
        {
            do
            {
                ProduceEnemies();

                

                ProcessObjects();




            } while (!IsgameOver());
            
        }

        public void ProcessObjects()
        {
            for (int i = 0; i < _amountOfObjects; i++)
            {
                ++_gameObjects[i].Counter;

                if (_gameObjects[i].Counter % _gameObjects[i].Speed == 0)
                {
                    _gameObjects[i].Counter = RESET;

                    _gameObjects[i].Step();

                    UI.PrintObject(_gameObjects[i]); 
                }
            }
        }

        public void ProduceEnemies()
        {
            ++_counterProduceEnemy;

            if (_counterProduceEnemy % _speed == 0)
            {
                _counterProduceEnemy = RESET;

                _gameObjects[_amountOfObjects] = new EnemyShip();
                ++_amountOfObjects;
            }
        }

        public void AddObject(SpaceCraft source)
        {
            if (_amountOfObjects >= _gameObjects.Length)
            {
                Array.Resize(ref _gameObjects, _gameObjects.Length * 2);
            }

            _gameObjects[_amountOfObjects] = source; // TODO: Safety copy.
            ++_amountOfObjects;
        
        }
    }
}