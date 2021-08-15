﻿using System;

namespace Game
{
    class GameField
    {
        #region Private Data

        private int _leftBorder = 30;
        private int _rightBorder = 83;
        private int _topBorder = 0;
        private int _bottomBorder = 33;
        private const int RESET = 0;
        private const int CONST_Y = 1;

        private int _initialX = 53;      // Initial X position of Spaceship.
        private int _initialY = 28;      // Initial Y position of Spaceship.
        private byte _lifes = 3;
        private byte _hitpoints = 10;
        private byte _leftShift = 2;     // This shift tunes the Left bullet. 
        private byte _rightShift = 6;    // This shift tunes the Right bullet.
        private byte _shotEnemyShift = 3;
        private uint _shipSpeed = 1;
        private bool _active = true;
        private uint _counter = 0;

        private SpaceCraft[] _gameObjects;
        private int _amountOfObjects;
        private int _counterProduceEnemy;
        private int _speed;

        private static int _gfAmount = 0;
        private static int _oldGFAmount = 0;

        #endregion

        #region Properties

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

        public static int GFAmount
        {
            get
            {
                return _gfAmount;
            }
            set
            {
                _gfAmount = value;
            }
        }
        public static int OldGFAmount
        {
            get
            {
                return _oldGFAmount;
            }
            set
            {
                _oldGFAmount = value;
            }
        }

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

        #endregion

        // TODO: GameField divides into Game and Space.

        #region Methods

        public GameField(int capacity = 20, int amount = 0, int speed = 350000)
        {
            _gameObjects = new SpaceCraft[capacity];
            _amountOfObjects = amount;
            _counterProduceEnemy = amount;
            _speed = speed;
            ++_gfAmount;
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
                ProduceEnemies();

                ShotEnemies();

                CheckObjects();

                PrintObjects();

                StepObjects();

                DeleteObjects();

                //Display.SetUserShipData(this);

                //UI.ShowAmountOfObjects();

            } while (IsgameOver());

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

        public void PrintObjects()
        {
            for (int i = 0; i < _amountOfObjects; i++)
            {
                UI.PrintObject(_gameObjects[i]);
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

            if (_amountOfObjects >= _gameObjects.Length)    // TODO: Pay attention!
            {
                Array.Resize(ref _gameObjects, _gameObjects.Length * 2);
            }

            _gameObjects[_amountOfObjects] = creature;
             ++_amountOfObjects;
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

        private void CheckObjects()
        {
            for (int i = 0; i < _amountOfObjects; i++)
            {
                if (_gameObjects[i] is Shot)
                {
                    CheckShot(i);
                }

                if (_gameObjects[i] is EnemyShip)
                {
                    CheckEnemy(i);
                }

                if (_gameObjects[i] is UserShip)
                {
                    CheckUserShip(i);
                }

            }
        }

        private void CheckUserShip(int ship)
        {
            for (int i = 0; i < _amountOfObjects; i++)
            {
                if (_gameObjects[i] is EnemyShip)
                {
                    if (IsClash(ship, i))
                    {
                        _gameObjects[ship].Y = _gameObjects[ship].Y+2;
                        _gameObjects[i].Y = _gameObjects[i].Y-2;
                    }
                }
            }
        }

        private void CheckEnemy(int enemy)
        {
            if (_gameObjects[enemy].Y == BottomBorder)
            {
                DeactivateObject(enemy);
            }
        }

        private void CheckShot(int shot)
        {
            if (_gameObjects[shot].Y == TopBorder)
            {
                DeactivateObject(shot);
                return;
            }

            if (_gameObjects[shot].Y == BottomBorder)
            {
                DeactivateObject(shot);
                return;
            }

            for (int i = 0; i < _amountOfObjects; i++)
            {
                if (_gameObjects[i] is Ship one)
                {
                    if (IsHit(shot, i))
                    {
                        DeactivateObject(shot);

                        --one.HitPoints;

                        if (one.HitPoints <= 0)
                        {
                            DeactivateObject(i); 
                        }
                    }
                }
            }
        }

        private void CheckEnemyShot(int shot)
        {
            if (_gameObjects[shot].Y == BottomBorder)
            {
                DeactivateObject(shot);
                return;
            }

            for (int i = 0; i < _amountOfObjects; i++)
            {
                if (_gameObjects[i] is UserShip)
                {
                    if (IsHit(shot, i))
                    {
                        DeactivateObject(shot);

                        UserShip one = (UserShip)_gameObjects[i];
                        one.HitPoints -= 10;

                        if (one.HitPoints <= 0)
                        {
                            DeactivateObject(i);
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

        private bool IsHit(int shot, int enemy)
        {
            return _gameObjects[shot].Y == _gameObjects[enemy].Y &&
                    _gameObjects[enemy].X < _gameObjects[shot].X &&
                        _gameObjects[shot].X < _gameObjects[enemy].X + 7;
          }

        private void DeleteObjects()
        {
            for (int i = 0; i < _amountOfObjects; i++)
            {
                if (!_gameObjects[i].Active)
                {
                    Array.Copy(_gameObjects, i + 1, _gameObjects,
                            i, _amountOfObjects - i);
                    --_amountOfObjects;
                    --i;
                }
            }

            //GC.Collect();
        }

        private void DeactivateObject(int index)
        {
            _gameObjects[index].Active = false;
            _gameObjects[index].Step(); // Change Y for UI.
        }
    } 

    #endregion
}