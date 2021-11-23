using System;
using System.Collections.Generic;

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

        //public override byte Width {  get; set; }

        #endregion

        #region Constructor

        public EnemyShip(ISpace game, HashSet<Coordinate> position, int x, int y, bool active,
                uint speed, sbyte step, byte rndY, byte hitPoints = 6)
        {
            _game = game;
            //X = coordX;
            //Y = coordY;
            //OldX = 0;
            //OldY = 0;
            Active = true;
            Counter = 0;
            Speed = speed;
            HP = hitPoints;
            Shot = rndY;
            _step = step;
            //Width = 7;

            Position = position;
        }

        #endregion

        #region Member Functions

        public override void Step()    // TODO: ref return.
        {
            //Y += _step;
            foreach (var item in Position)
            {
                item.Y += _step;
            }
        }

        #endregion
    }
}