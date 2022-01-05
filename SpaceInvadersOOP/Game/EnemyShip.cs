using System;
using System.Collections.Generic;

namespace Game
{
    internal class EnemyShip : Ship
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
        :base(SpaceObject.EnemyShip)
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

            OldPosition = new HashSet<Coordinate>(16);

            NextPosition = new HashSet<Coordinate>(16);
        }

        #endregion

        #region Member Functions

        public override void Step()
        {
            //Y += _step;

            int y;
            foreach (var item in Position)
            {
                y = item.Y;
                NextPosition.Add(new Coordinate(item.X, ++y));
            }

            Position.Clear();
            Position.UnionWith(NextPosition);
            NextPosition.Clear();
        }

        #endregion
    }
}