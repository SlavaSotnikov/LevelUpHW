using System;

namespace Game
{
    class Game
    {
        protected int _initialX = 53;      // Initial X position of Spaceship.
        protected int _initialY = 28;      // Initial Y position of Spaceship.
        protected byte _lifes = 3;
        protected byte _hitpoints = 10;
        protected byte _leftShift = 2;     // This shift tunes the Left bullet. 
        protected byte _rightShift = 6;    // This shift tunes the Right bullet.
        protected byte _shotEnemyShift = 3;
        protected uint _shipSpeed = 1;
        protected bool _active = true;
        protected uint _counter = 0;
        protected const int RESET = 0;
        protected const int CONST_Y = 1;

        protected int _counterProduceEnemy;
        protected int _speed;

        protected SpaceCraft[] _gameObjects;
        protected int _amountOfObjects;

        public static GameAction GetEvent()
        {
            return UI.AskConsole();
        }

        public Game()
        {
        }

        public void PrintObjects()
        {
            for (int i = 0; i < _amountOfObjects; i++)
            {
                UI.PrintObject(_gameObjects[i]);
            }
        }

        public void StepObjects()
        {
            for (int i = 0; i < _amountOfObjects; i++)
            {
                ++_gameObjects[i].Counter;

                if (_gameObjects[i].Counter % _gameObjects[i].Speed == 0)
                {
                    _gameObjects[i].Counter = RESET;

                    _gameObjects[i].Step();

                }
            }
        }

        public void DeleteObjects()
        {
            for (int i = _gameObjects.Length - 1; i >= 0; i--)
            {
                if (_gameObjects[i] != null)
                {
                    if (!_gameObjects[i].Active)
                    {
                        Array.Copy(_gameObjects, i + 1, _gameObjects,
                                i, _amountOfObjects - i);
                        --_amountOfObjects;
                    }
                }
            }
        }
    }
}
