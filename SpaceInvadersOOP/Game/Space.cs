using System;

namespace Game
{
    class Space : ISpace, IUi
    {
        #region Private Data

        protected int _leftBorder = 30;
        protected int _rightBorder = 83;
        protected int _topBorder = 0;
        protected int _bottomBorder = 33;

        #endregion

        #region Properties

        public int LeftBorder
        {
            get
            {
                return _leftBorder;
            }
        }

        public int RightBorder
        {
            get
            {
                return _rightBorder;
            }
        }

        public int TopBorder
        {
            get
            {
                return _topBorder;
            }
        }

        public int BottomBorder
        {
            get
            {
                return _bottomBorder;
            }
        }

        public SpaceCraft this[int index]
        {
            get
            {
                return _gameObjects[index];
            }
        }

        public int Amount 
        {
            get
            {
                return _amountOfObjects;
            }
        }

        #endregion

        #region Methods

        public void Run()
        {
            do
            {
                Controller.Show(this);

                StepObjects();

                ProduceEnemies();

                ShotEnemies();

                CheckObjects();

                //PrintObjects();

                Controller.Hide(this);

                //DeleteObjects();

            } while (IsgameOver());
        }

        public bool IsgameOver()
        {
            bool gameOn = true;

            for (int i = 0; i < _amountOfObjects; i++)
            {
                if ((_gameObjects[i] is UserShip user) && !user.Active)
                {
                    gameOn = false;
                    break;
                }
            }

            return gameOn;
        }

        public void AddObject(SpaceObject source)
        {
            SpaceCraft creature = null;

            switch (source)
            {
                case SpaceObject.None:
                    break;
                case SpaceObject.LightShip:
                    creature = new LightShip(this, _initialX, _initialY,
                            _active, _shipSpeed, _counter, _hitpoints, _lifes);
                    break;
                case SpaceObject.HeavyShip:
                    creature = new HeavyShip(this, _initialX, _initialY,
                            _active, _shipSpeed, _counter, _hitpoints, _lifes);
                    break;
                case SpaceObject.EnemyShip:
                    creature = AddEnemy();
                    break;
                case SpaceObject.ShotLeft:
                    creature = AddShot(_leftShift);
                    break;
                case SpaceObject.ShotRight:
                    creature = AddShot(_rightShift);
                    break;
                case SpaceObject.ShotEnemy:
                    creature = AddEnemyShot(_shotEnemyShift);
                    break;
                default:
                    break;
            }

            if (_amountOfObjects >= _gameObjects.Length - 1)
            {
                Array.Resize(ref _gameObjects, _gameObjects.Length * 2);
            }

            for (int i = 0; i <= _amountOfObjects; i++)
            {
                if (_gameObjects[i] is null)
                {
                    _gameObjects[i] = creature;
                    ++_amountOfObjects;

                    break;
                }

                if (!_gameObjects[i].Active)
                {
                    _gameObjects[i] = creature;
                    break;
                }
            }

            //for (int i = -1; i < _amountOfObjects; i++)
            //{
            //    if (_gameObjects[i + 1] is null)
            //    {
            //        _gameObjects[i + 1] = creature;
            //        ++_amountOfObjects;

            //        break;
            //    }

            //    if (!_gameObjects[i + 1].Active)
            //    {
            //        _gameObjects[i + 1] = creature;

            //        break;
            //    }
            //}
        }

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

        public Space(int capacity = 13, int speed = 350000)
        {
            _gameObjects = new SpaceCraft[capacity];
            _amountOfObjects = 0;
            _counterProduceEnemy = 0;
            _speed = speed;
        }

        public void StepObjects()
        {
            for (int i = 0; i < _amountOfObjects; i++)
            {
                ++_gameObjects[i].Counter;

                if ((_gameObjects[i].Counter % _gameObjects[i].Speed == 0)
                        && _gameObjects[i].Active)
                {
                    _gameObjects[i].Counter = RESET;

                    _gameObjects[i].Step();

                }
            }
        }

        public void CheckObjects()
        {
            for (int i = 0; i < _amountOfObjects; i++)
            {
                for (int j = 0; j < _amountOfObjects; j++)
                {
                    if (i != j)
                    {
                        if (_gameObjects[i] is UserShip user && _gameObjects[j] is EnemyShip enemy)
                        {
                            if (IsClash(user, enemy))
                            {
                                throw new ColorException();

                                //user.Y = user.Y + 2; 
                                //enemy.Y = enemy.Y - 2;
                            }
                        }

                        if (_gameObjects[i] is Shot bullet && _gameObjects[j] is Ship ship)
                        {
                            if (bullet.Active && ship.Active)
                            {
                                if (IsHit(bullet, ship))
                                {
                                    bullet.Active = false;
                                    --ship.HitPoints;

                                    if (ship.HitPoints <= 0)
                                    {
                                        ship.Active = false;
                                        ship.Step();
                                    }
                                }
                            }
                        }

                        if (_gameObjects[i] is EnemyShip one)
                        {
                            if (one.Y == BottomBorder)
                            {
                                one.Active = false;
                            }
                        }

                        if (_gameObjects[i] is Shot two)
                        {
                            if (two.Y == TopBorder || two.Y == BottomBorder)
                            {
                                two.Active = false;
                            }
                        }
                    }
                }
            }
        }

        private bool IsClash(UserShip user, EnemyShip enemy)
        {
            return user.Y - 1 == enemy.Y && enemy.X >= user.X
                    && enemy.X + enemy.Width <= user.X + user.Width;
        }

        private bool IsHit(Shot bullet, Ship user)
        {
            return bullet.Y == user.Y && user.X < bullet.X
                    && bullet.X < user.X + user.Width;
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

        public void ShotEnemies()
        {
            for (int i = _amountOfObjects; i >= 0; i--)
            {
                if (_gameObjects[i] is EnemyShip one)
                {
                    if (one.Y == one.Shot)
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
                    if (_gameObjects[i] is EnemyShip enemy)
                    {
                        if (!((rndX > enemy.X + enemy.Width) || (rndX + enemy.Width < enemy.X)))
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
                if (_gameObjects[i] is UserShip user)
                {
                    bullet = new Shot(user.X + shift, user.Y - 1, 1, 5000);
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
                    bullet = new Shot(one.X + shift, one.Y + 3, -1, 28000);
                    one.Shot = 0;
                    break;
                }
            }

            return bullet;
        }
    }

    #endregion
}