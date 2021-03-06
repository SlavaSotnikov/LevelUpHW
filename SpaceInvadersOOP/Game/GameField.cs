using System;

namespace Game
{
    class GameField : Space
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

        public SpaceCraft this[int index]
        {
            get
            {
                return _gameObjects[index];
            }
        }

        public int AmountOfObj
        {
            get
            {
                return _amountOfObjects;
            }
        }

        public GameField(int capacity = 20, int amount = 0, int speed = 350000)
        {
            _gameObjects = new SpaceCraft[capacity];
            _amountOfObjects = amount;
            _counterProduceEnemy = amount;
            _speed = speed;
        }

        public bool IsgameOver()
        {
            bool gamуOn = false;

            for (int i = 0; i < _amountOfObjects; i++)
            {
                if (_gameObjects[i] is UserShip)
                {
                    gamуOn = true;
                    break;
                }
            }

            return gamуOn;
        }

        public void Run()
        {
            do
            {
                Controller.HideSpaceCrafts(_gameObjects, _amountOfObjects);

                StepObjects();

                ProduceEnemies();

                ShotEnemies();

                CheckObjects();

                PrintObjects();

                Controller.ShowSpaceCrafts(_gameObjects, _amountOfObjects);

                //DeleteObjects();

            } while (IsgameOver());

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

        private void ShotEnemies()
        {
            for (int i = 0; i < _amountOfObjects; i++)
            {
                if (_gameObjects[i] is EnemyShip one)
                {
                    if (_gameObjects[i].Y == one.Shot)
                    {
                        AddObject(SpaceObject.ShotEnemy);
                    }
                }
            }
        }

        public void ProduceEnemies()
        {
            ++_counterProduceEnemy;

            if (_counterProduceEnemy % _speed == 0)
            {
                AddObject(SpaceObject.EnemyShip);
            }
        }

        private void CheckObjects()
        {
            for (int i = 0; i < _amountOfObjects; i++)
            {
                for (int j = 0; j < _amountOfObjects; j++)
                {
                    if (i != j)
                    {
                        if (_gameObjects[i] is UserShip && _gameObjects[j] is EnemyShip)
                        {
                            if (IsClash(i, j))
                            {
                                _gameObjects[i].Y = _gameObjects[i].Y + 2;
                                _gameObjects[j].Y = _gameObjects[j].Y - 2;
                            }
                        }

                        if (_gameObjects[i] is Shot && _gameObjects[j] is Ship one)
                        {
                            if (IsHit(i, j))
                            {
                                _gameObjects[i].Active = false;

                                --one.HitPoints;

                                if (one.HitPoints <= 0)
                                {
                                    _gameObjects[j].Active = false;

                                    one.Step();
                                }
                            }
                        }

                        if (_gameObjects[i] is EnemyShip)
                        {
                            if (_gameObjects[i].Y == BottomBorder)
                            {
                                _gameObjects[i].Active = false;
                            }
                        }

                        if (_gameObjects[i] is Shot)
                        {
                            if (_gameObjects[i].Y == TopBorder ||
                                    _gameObjects[i].Y == BottomBorder)
                            {
                                _gameObjects[i].Active = false;
                            }

                        }
                    }
                }
            }
        }

        private bool IsClash(int userShip, int enemy)
        {
            return _gameObjects[userShip].Y - 1 == _gameObjects[enemy].Y &&
                    _gameObjects[enemy].X >= _gameObjects[userShip].X &&
                        _gameObjects[enemy].X + 7 <= _gameObjects[userShip].X + 9;
        }

        private bool IsHit(int shot, int ship)
        {
            return _gameObjects[shot].Y == _gameObjects[ship].Y &&
                    _gameObjects[ship].X < _gameObjects[shot].X &&
                        _gameObjects[shot].X < _gameObjects[ship].X + 7;
        }

        private SpaceCraft AddEnemy()
        {
            bool isExist;
            int rndX = 0;
            uint speed = BL_Random.GetFlySpeed();
            byte rndYShot = BL_Random.GetRndY();

            do
            {
                rndX = BL_Random.GetCoordinateX();

                isExist = false;

                for (int i = 0; i < _amountOfObjects; i++)
                {
                    if (_gameObjects[i] is EnemyShip)
                    {
                        if (!((rndX > _gameObjects[i].X + 7) ||
                                (rndX + 7 < _gameObjects[i].X)))    // TODO: Ask about width of a ship.
                        {
                            isExist = true;
                            i = 0;

                            break;
                        }
                    }
                }

            } while (isExist);

            return new EnemyShip(this, rndX, CONST_Y, _active, speed, 1, rndYShot);
        }

        public Shot AddShot(int shift)
        {
            Shot bullet = null;

            for (int i = 0; i < _amountOfObjects; i++)
            {
                if (_gameObjects[i] is UserShip)
                {
                    bullet = new Shot(_gameObjects[i].X + shift,
                            _gameObjects[i].Y - 1, 1, 5000);

                    break;
                }
            }

            return bullet;
        }

        public Shot AddEnemyShot(int shift)
        {
            Shot bullet = null;

            for (int i = 0; i < _amountOfObjects; i++)
            {
                if (_gameObjects[i] is EnemyShip one && one.Shot != 0)
                {
                    bullet = new Shot(_gameObjects[i].X + shift,
                            _gameObjects[i].Y + 3, -1, 28000);

                    one.Shot = 0;

                    break;
                }
            }

            return bullet;
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
    }
}
