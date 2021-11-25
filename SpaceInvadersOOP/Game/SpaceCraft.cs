﻿using System;
using System.Collections.Generic;

namespace Game
{
    abstract class SpaceCraft : ISpaceCraft
    {
        #region Private Data
        
        protected sbyte _step;

        protected ISpace _game;

        #endregion

        #region Properties

        //public int X { get; set; }

        //public int Y { get; set; }

        //public int OldX { get; set; }

        //public int OldY { get; set; }

        public bool Active { get; set; }

        public uint Counter { get; set; }

        public uint Speed { get; set; }

        public HashSet<Coordinate> Position { get; set; }

        public HashSet<Coordinate> OldPosition { get; set; }

        #endregion

        #region Methods

        public bool IsNeedStep()
        {
            bool result = false;

            ++Counter;

            if ((Counter % Speed == 0) && Active)
            {
                Counter = 0;

                result = true;
            }

            return result;
        }

        public abstract void Step();

        public virtual void MoveState()
        {
            //OldX = X;
            //OldY = Y;

            OldPosition.Clear();
            OldPosition.TrimExcess();

            foreach (var item in Position)
            {
                OldPosition.Add(new Coordinate(item.X, item.Y));
            }
        }

        #endregion
    }
}