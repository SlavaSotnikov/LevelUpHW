using System;

namespace Game
{
    abstract class SpaceCraft : ISpaceCraft
    {
        #region Private Data

        protected int _coordX;
        protected int _coordY;
        protected int _oldCoordX;
        protected int _oldCoordY;
        protected bool _active;
        protected uint _speed;
        protected uint _counter;
        protected sbyte _step;

        protected ISpace _game;

        #endregion

        #region Properties

        public int X
        {
            get
            {
                return _coordX;
            }
            set
            {
                _coordX = value;
            }
        }

        public int Y
        {
            get
            {
                return _coordY;
            }
            set
            {
                _coordY = value;
            }
        }

        public int OldX
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

        public int OldY
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

        #endregion
    }
}