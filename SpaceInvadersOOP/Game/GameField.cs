using System;

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
        private int _initialY = 33;      // Initial Y position of Spaceship.
        private byte _lifes = 3;
        private byte _hitpoints = 100;
        private byte _leftShift = 2;     // This shift tunes the Left bullet. 
        private byte _rightShift = 6;    // This shift tunes the Right bullet.
        private uint _shipSpeed = 1;
        private bool _active = true;
        private uint _counter = 0;

        private SpaceCraft[] _gameObjects;
        private int _amountOfObjects;
        private int _counterProduceEnemy;
        private int _speed;

        #endregion

        private static int _gfAmount = 0;
        private static int _oldGFAmount = 0;

        public SpaceCraft this[int index]
        {
            get 
            {
                return _gameObjects[index];
            }
            set 
            {
                _gameObjects[index] = value;
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

        #region Properties

        public GameField GetReference
        {
            get
            {
                return this;
            }
        }

        public int InitialX
        {
            get
            {
                return _initialX;
            }
        }

        public int InitialY
        {
            get
            {
                return _initialY;
            }
        }

        public byte Lifes
        {
            get
            {
                return _lifes;
            }
        }

        public byte Hitpoints
        {
            get
            {
                return _hitpoints;
            }
        }

        public byte LeftShift
        {
            get
            {
                return _leftShift;
            }
        }

        public byte RightShift
        {
            get
            {
                return _rightShift;
            }
        }

        public uint ShipSpeed
        {
            get
            {
                return _shipSpeed;
            }
        }

        public bool Active
        {
            get
            {
                return _active;
            }
        }

        public uint Counter
        {
            get
            {
                return _counter;
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
            return false;
        }

        public void Run()
        {
            do
            {
                ProduceEnemies();

                CheckObjects();

                PrintObjects();

                StepObjects();

                DeleteObjects();

                

                UI.ShowAmountOfObjects();

            } while (!IsgameOver());

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
                default:
                    break;
            }

            if (_amountOfObjects >= _gameObjects.Length)
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

            do
            {
                rndX = BL_Random.GetCoordinateX();

                isExist = false;

                for (int i = 0; i < _amountOfObjects; i++)
                {
                    if (IsEnemyShip(i))
                    {
                        if (!((rndX > _gameObjects[i].CoordinateX + 7) ||
                                (rndX + 7 < _gameObjects[i].CoordinateX)))
                        {
                            isExist = true;
                            i = 0;
                            break;
                        }
                    }
                }

            } while (isExist);

            return new EnemyShip(this, rndX, CONST_Y, _active, speed);
        }

        public Shot AddShot(int shift)
        {
            Shot bullet = null;

            for (int i = 0; i < _amountOfObjects; i++)
            {
                if (IsUserShip(i))
                {
                    bullet = new Shot(_gameObjects[i].CoordinateX + shift,
                            _gameObjects[i].CoordinateY);
                    break;
                }
            }

            return bullet;
        }

        

        private void CheckObjects()
        {
            for (int i = 0; i < _amountOfObjects; i++)
            {
                if (IsShot(i))
                {
                    CheckShot(i);
                }

                if (IsEnemyShip(i))
                {
                    CheckEnemy(i);
                }

                if (IsUserShip(i))
                {

                }


            }
        }

        private void CheckEnemy(int enemy)
        {
            if (_gameObjects[enemy].CoordinateY == BottomBorder)
            {
                DeactivateObject(enemy);
            }
        }

        private void CheckShot(int shot)
        {
            if (_gameObjects[shot].CoordinateY == TopBorder)
            {
                DeactivateObject(shot);
                return;
            }

            for (int enemy = 0; enemy < _amountOfObjects; enemy++)
            {
                if (IsEnemyShip(enemy))
                {
                    if (IsHit(shot, enemy))
                    {
                        DeactivateObject(shot);

                        EnemyShip one = (EnemyShip)_gameObjects[enemy];
                        --one.HitPoints;

                        if (one.HitPoints <= 0)
                        {
                            DeactivateObject(enemy); 
                        }
                    }
                }
            }
        }

        private bool IsHit(int shot, int enemy)
        {
            return _gameObjects[shot].CoordinateY == _gameObjects[enemy].CoordinateY &&
                    _gameObjects[enemy].CoordinateX < _gameObjects[shot].CoordinateX &&
                        _gameObjects[shot].CoordinateX < _gameObjects[enemy].CoordinateX + 7;
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
        }

        private bool IsEnemyShip(int index)
        {
            return _gameObjects[index] is EnemyShip;
        }

        private bool IsShot(int index)
        {
            return _gameObjects[index] is Shot;
        }

        private bool IsUserShip(int index)
        {
            return (_gameObjects[index] is LightShip) 
                    || (_gameObjects[index] is HeavyShip);
        }

        private void DeactivateObject(int index)
        {
            _gameObjects[index].Active = false;
            _gameObjects[index].Step(); // Change Y for UI.
        }
    } 

    #endregion
}