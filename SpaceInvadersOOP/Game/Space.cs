using System;

namespace Game
{
    class Space : ISpace
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

        #endregion

        #region Methods

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

            if (_amountOfObjects >= _gameObjects.Length)
            {
                Array.Resize(ref _gameObjects, _gameObjects.Length * 2);
            }

            for (int i = 0; i < _amountOfObjects; i++)
            {
                if (!_gameObjects[i].Active || _gameObjects[i] is null)
                {
                    _gameObjects[_amountOfObjects] = creature;
                    ++_amountOfObjects;
                }
            }
        }
    } 

    #endregion
}