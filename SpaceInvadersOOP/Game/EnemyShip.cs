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
            OldPosition = new HashSet<Coordinate>(19, new Comparer());

            foreach (var item in Position)
            {
                OldPosition.Add(new Coordinate(item));
            }

            foreach (var item in OldPosition)
            {
                item.X++;
                item.Y++;
                break;
            }
        }

        #endregion

        #region Member Functions

        public override void Step()    // TODO: ref return.
        {
            //Y += _step;
            HashSet<Coordinate> temp = new HashSet<Coordinate>(7, new Comparer());

            foreach (var item in Position)
            {
                temp.Add(new Coordinate(item.X, ++item.Y));
            }

            Position.Clear();
            Position.TrimExcess();
            Position.UnionWith(temp);
            temp.Clear();
            temp.TrimExcess();
        }

        #endregion
    }
}