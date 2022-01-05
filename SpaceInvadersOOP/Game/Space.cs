using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    internal class Space : GameField, ISpace, ITimer
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

        //public int LeftBorder => _leftBorder;

        //public int RightBorder => _rightBorder;

        //public int TopBorder => _topBorder;

        //public int BottomBorder => _bottomBorder;

        #endregion

        #region Constructor

        public Space(int capacity = 0, int speed = 330000)
        {
            _gameObjects = new List<SpaceCraft>(capacity);
            _amountOfObjects = 0;
            _counterProduceEnemy = 0;
            _speed = speed;

            InitBorders();

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
            //AddStars();

            AddObject((SpaceObject)1);

            Controller.ShowBorders(this);

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

        public void ResetObject(SpaceCraft source)
        {
            switch (source.View)
            {
                case SpaceObject.None:
                    break;
                case SpaceObject.LightShip:
                    //spaceObject = new LightShip(this, _initialX, _initialY,
                    //    _active, _shipSpeed, _counter, _hitpoints, _lifes);
                    break;
                case SpaceObject.HeavyShip:
                    //creature = new HeavyShip(this, _initialX, _initialY,
                    //    _active, _shipSpeed, _counter, _hitpoints, _lifes);
                    break;
                case SpaceObject.EnemyShip:

                    ResetEnemy((EnemyShip)source);
                    break;

                case SpaceObject.ShotLeft:

                    ResetShot((Shot)source);
                     break;

                case SpaceObject.ShotRight:
                    //creature = AddShot(_rightShift);
                    break;
                case SpaceObject.ShotEnemy:
                    

                    for (int i = 0; i < _gameObjects.Count; i++)
                    {
                        if (_gameObjects[i] is EnemyShip one)
                        {
                            if (GetMinY(one).Y == one.Shot)
                            {
                                Coordinate newPosition = NewEnemyShotPosition();
                                source.Position.Clear();
                                source.Position.Add(newPosition);
                                break;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void ResetShot(Shot source)
        {
            Coordinate newPosition = NewShotPosition();
            source.Position.Clear();
            source.Position.Add(new Coordinate(newPosition.X, newPosition.Y - 1));
            source.Active = true;
            source.Counter = 0;
        }

        public Coordinate NewEnemyShotPosition()
        {
            Coordinate bow = default;

            for (int i = 0; i < _gameObjects.Count; i++)
            {
                if ((_gameObjects[i] is EnemyShip one) && (GetMinY(one).Y == one.Shot))  
                {
                    bow = new Coordinate(GetMaxY(one).X, GetMaxY(one).Y + 1);
                    one.Shot = 0;
                    break;
                }
            }

            return bow;
        }

        public Coordinate NewShotPosition()
        {
            Coordinate bow = default;

            for (int i = 0; i < _gameObjects.Count; i++)
            {
                if (_gameObjects[i] is UserShip user)
                {
                    bow = GetMinY(user);
                    break;
                }
            }

            return bow;
        }

        public void AddObject(SpaceObject source)
        {
            SpaceCraft creature = null;

            bool reset = false;
            for (int i = /*10*/0; i < _gameObjects.Count/*_amountOfObjects*/; i++)
            {
                if (source == _gameObjects[i].View && !_gameObjects[i].Active)
                {
                    ResetObject(_gameObjects[i]);
                    reset = true;
                    break;
                }
            }

            if (!reset)
            {
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
                        //creature = AddShot(_rightShift);
                        break;
                    case SpaceObject.ShotEnemy:
                        creature = AddEnemyShot(_shotEnemyShift);
                        break;
                    default:
                        break;
                }

                _gameObjects.Add(creature);
                ++_amountOfObjects;
            }

            

            

            //if (_amountOfObjects >= _gameObjects.Length - 1)
            //{
            //    Array.Resize(ref _gameObjects, _gameObjects.Length * 2);
            //}

            //for (int i = /*10*/0; i <= _gameObjects.Count/*_amountOfObjects*/; i++)
            //{
            //    if (_gameObjects[i] is null)
            //    {
            //        _gameObjects[i] = creature;
            //        ++_amountOfObjects;

            //        break;
            //    }

            //    if (!_gameObjects[i].Active)
            //    {
            //        _gameObjects[i] = creature;
            //        break;
            //    }

            //    if (i == _gameObjects.Count - 1)
            //    {
            //        _gameObjects.Add(creature);
            //        break;
            //    }
            //}
        }

        private void ResetEnemy(EnemyShip source)
        {
            bool isExist;
            //int rndX = 0;
            uint speed = BL_Random.GetFlySpeed();
            byte rndYShot = BL_Random.GetRndY();
            HashSet<Coordinate> newPosition;

            do
            {
                //rndX = BL_Random.GetX();

                newPosition = InitNewEnemy(BL_Random.GetX());

                isExist = false;

                for (int i = 0; i < _amountOfObjects; i++)
                {
                    if (_gameObjects[i] is EnemyShip enemy)
                    {
                        if (newPosition.Overlaps(enemy.Position) /*!((rndX > enemy.X + enemy.Width) || (rndX + enemy.Width < enemy.X))*/)
                        {
                            isExist = true;
                            break;
                        }
                    }
                }

            } while (isExist);

            source.Active = true;
            source.Counter = 0;
            source.HP = 6;
            source.Position.Clear();
            foreach (var item in newPosition)
            {
                source.Position.Add(new Coordinate(item));
            }
        }

        private SpaceCraft AddEnemy()
        {
            bool isExist;
            //int rndX = 0;
            uint speed = BL_Random.GetFlySpeed();
            byte rndYShot = BL_Random.GetRndY();
            HashSet<Coordinate> position;

            do
            {
                //rndX = BL_Random.GetX();

                position = InitNewEnemy(BL_Random.GetX());

                isExist = false;

                for (int i = 0; i < _amountOfObjects; i++)
                {
                    if (_gameObjects[i] is EnemyShip enemy)
                    {
                        if (position.Overlaps(enemy.Position) /*!((rndX > enemy.X + enemy.Width) || (rndX + enemy.Width < enemy.X))*/)
                        {
                            isExist = true;
                            break;
                        }
                    }
                }

            } while (isExist);

            return new EnemyShip(this, position, 0/*rndX*/, CONST_Y, _active, speed, 1, rndYShot);
        }

        private HashSet<Coordinate> InitNewEnemy(int x)
        {
            HashSet<Coordinate> result = new HashSet<Coordinate>(16);
            int width = 7;
            int height = 4;

            for (int y = 0; y < height; y++)
            {
                for (int i = y; i < width; i++)
                {
                    result.Add(new Coordinate(x + i, y + 1));
                }
                width--;
            }

            return result;
        }

        public Shot AddShot(int shift)
        {
            Shot bullet = null;

            for (int i = 0; i < _gameObjects.Count; i++)
            {
                if (_gameObjects[i] is UserShip user)
                {
                    Coordinate bow = GetMinY(user);
                    bullet = new Shot(bow.X/* + shift*/, bow.Y - 1, 1, 2000);
                    break;
                }
            }

            return bullet;
        }

        private Coordinate GetMinY(Ship source)
        {
            Coordinate min = new Coordinate(0, int.MaxValue);

            foreach (var item in source.Position)
            {
                if (item.Y < min.Y)
                {
                    min = item;
                }
            }

            return min;
        }

        private Coordinate GetMaxY(Ship source)
        {
            Coordinate min = new Coordinate(0, int.MinValue);

            foreach (var item in source.Position)
            {
                if (item.Y > min.Y)
                {
                    min = item;
                }
            }

            return min;
        }

        public Shot AddEnemyShot(int shift)
        {
            Shot bullet = null;

            for (int i = 0; i < _gameObjects.Count; i++)
            {
                if (_gameObjects[i] is EnemyShip one && one.Shot != 0)
                {
                    bullet = new Shot(GetMaxY(one).X, GetMaxY(one).Y + 1, -1, 2000);
                    one.Shot = 0;
                    break;
                }
            }

            return bullet;
        }

        public void ShotEnemies()
        {
            for (int i = 0; i < _gameObjects.Count; i++)
            {
                if (_gameObjects[i] is EnemyShip one)
                {
                    if (GetMinY(one).Y == one.Shot)
                    {
                        AddObject(SpaceObject.ShotEnemy);
                        break;
                    }

                    //if (one.Y == one.Shot)
                    //{
                    //    AddObject(SpaceObject.ShotEnemy);
                    //}
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