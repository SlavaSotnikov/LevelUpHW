using System;

namespace Game
{
    abstract class SpaceCraft
    {
        #region Private Data

        protected int _coordX;
        protected int _coordY;
        protected int _oldCoordX;
        protected int _oldCoordY;
        protected bool _active;
        protected uint _speed;
        protected uint _counter;
        protected const byte STEP = 1;
        
        protected GameField _game;

        #endregion

        //public SpaceCraft(SpaceCraft source)
        //{

        //}

        #region Properties

        public int CoordinateX
        {
            get
            {
                return _coordX;
            }
        }

        public int CoordinateY
        {
            get
            {
                return _coordY;
            }
        }

        public int OldCoordinateX
        {
            get
            {
                return _oldCoordX;
            }
            set
            {
                _oldCoordX = value;
            }
        }

        public int OldCoordinateY
        {
            get
            {
                return _oldCoordY;
            }
            set
            {
                _oldCoordY = value;
            }
        }

        public bool Active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
            }
        }

        public uint Counter
        {
            get 
            { 
                return _counter; 
            }
            set 
            { 
                _counter = value; 
            }
        }

        public uint Speed
        {
            get 
            {
                return _speed; 
            }
            set
            {
                _speed = value; 
            }
        }

        #endregion

        #region Methods

        public abstract void Step();

        //public abstract void Shoot();

        #endregion
    }
}