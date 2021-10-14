﻿using System;

namespace Game
{
    class EnemyShip : Ship
    {
        #region Private Data

        #endregion

        #region Properties

        public byte Shot { get; set; }

        public override byte HP { get; set; }

        public override byte OldHP { get; set; }

        public override byte Width {  get; set; }

        #endregion

        #region Constructor

        public EnemyShip(ISpace game, int coordX, int coordY, bool active,
                uint speed, sbyte step, byte rndY, uint counter = 0,
                    int oldX = 0, int oldY = 0, byte hitPoints = 6)
        {
            _game = game;
            X = coordX;
            Y = coordY;
            OldX = oldX;
            OldY = oldY;
            Active = true;
            Counter = 0;
            Speed = speed;
            HP = hitPoints;
            Shot = rndY;
            _step = step;
            Width = 7;
        }

        #endregion

        #region Member Functions

        public override void Step()
        {
            Y += _step;
        }

        #endregion
    }
}