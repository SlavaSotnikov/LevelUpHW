using System;
using System.Collections.Generic;

namespace Game
{
    class Space : GameField, ISpace
    {
        #region Private Data

        protected int _counterProduceEnemy;
        protected int _speed;

        #endregion

        public event GameStatus FinishedGame
        {
            add
            {
                _finishGame += value;
            }
            remove
            {
                _finishGame -= value;
            }
        }

        #region Properties

        public int LeftBorder => _leftBorder;

        public int RightBorder => _rightBorder;

        public int TopBorder => _topBorder;

        public int BottomBorder => _bottomBorder;

        #endregion

        #region Constructor

        public Space(int capacity = 23, int speed = 330000)
        {
            _gameObjects = new List<SpaceCraft>(capacity);
            _amountOfObjects = 0;
            _counterProduceEnemy = 0;
            _speed = speed;

            for (int i = 0; i < _gameObjects.Capacity; i++)
            {
                _gameObjects.Add(null);
            }

            FinishedGame += UI.PrintGameOver;
        }

        #endregion

        #region Member Functions

        public void AddStars()
        {
            for (int i = 0; i < 10; i++)
            {
                _gameObjects[i] = new Star(BL_Random.GetX(), BL_Random.GetY(), 1, 2000);
                ++_amountOfObjects;
            }
        }

        public void Run()
        {
            AddStars();

            AddObject((SpaceObject)1);

            do
            {
                Controller.Hide(this);

                Controller.Show(this);

                Controller.ShowDisplay(this);

                StepObjects();

                ProduceEnemies();

                ShotEnemies();

                try
                {
                    CheckObjects();
                }
                catch (ClashException ex)
                {
                    Controller.ShowExplosion(ex);
                }

            } while (IsGameOver());
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

            //if (_amountOfObjects >= _gameObjects.Length - 1)
            //{
            //    Array.Resize(ref _gameObjects, _gameObjects.Length * 2);
            //}

            for (int i = 10; i <= _gameObjects.Count/*_amountOfObjects*/; i++)
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

                if (i == _gameObjects.Count - 1)
                {
                    _gameObjects.Add(creature);
                }
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
                rndX = BL_Random.GetX();

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

        #endregion
    }
}