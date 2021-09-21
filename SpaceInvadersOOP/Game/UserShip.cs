using System;

namespace Game
{
    abstract class UserShip : Ship, IUserShip
    {
        #region Properties

        public override byte HP { get; set; }

        public override byte OldHP { get; set; }

        public byte Life { get; set; }

        public byte OldLife { get; set; }

        #endregion

        #region Constructor

        public UserShip(ISpace game, int coordX, int coordY, bool active,
                uint speed, uint counter, byte hitpoints, byte lifes, int oldCoordX = 0, int oldCoordY = 0)
        {
            _game = game;
            X = coordX;
            Y = coordY;
            OldX = oldCoordX;
            OldY = oldCoordY;
            Active = active;
            Speed = speed;
            Counter = counter;
            HP = hitpoints;
            Life = lifes;
            Width = 9;
        }

        #endregion

        #region Member Functions

        public override void MoveState()
        {
            base.MoveState();

            OldHP = HP;
            OldLife = Life;
        }

        #endregion
    }
}