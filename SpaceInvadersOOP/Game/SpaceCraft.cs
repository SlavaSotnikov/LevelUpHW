﻿using System;

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
        protected const byte LIFES = 3;
        protected const int INITIAL_X = 53;      // Initial X position of Spaceship.
        protected const int INITIAL_Y = 33;      // Initial Y position of Spaceship.
        protected const byte HITPOINTS = 100;
        protected const byte LEFT_SHIFT = 2;     // This shift tunes the Left bullet. 
        protected const byte RIGHT_SHIFT = 6;    // This shift tunes the Right bullet.
        protected GameField _game;

        #endregion

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

        public abstract string[] View 
        { 
            get; 
        }

        #endregion

        #region Methods

        public abstract void Step();

        //public abstract void Shoot();

        #endregion
    }
}