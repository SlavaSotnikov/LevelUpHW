using System;

namespace Game
{
    class Space : GameField, IGame
    {
        #region Private Data
        
        protected const int RESET = 0;

        protected int _counterProduceEnemy;
        protected int _speed;

        #endregion

        #region Properties

        public ISpaceCraft this[int index]
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

                try
                {
                    CheckObjects();
                }
                catch (ClashException ex)
                {
                    Console.Beep(1000, 100); // TODO: Try Console.
                }
                finally
                {
                    Controller.Hide(this);
                }


            } while (IsGameOver());
        }

        public bool IsGameOver()
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
                                throw new ClashException();

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
    }

    #endregion
}