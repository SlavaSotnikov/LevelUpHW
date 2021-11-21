namespace SpaceInvadersDLL
{
    public class EnemyShip : Ship
    {
        #region Private Data

        #endregion

        #region Properties

        public byte Shot { get; set; }

        public override byte HP { get; set; }

        public override byte OldHP { get; set; }

        public override byte Width { get; set; }

        #endregion

        #region Constructor

        internal EnemyShip(ISpace game, int coordX, int coordY, uint speed, sbyte step, byte rndY)
        {
            _game = game;
            X = coordX;
            Y = coordY;
            OldX = 0;
            OldY = 0;
            Active = true;
            Counter = 0;
            Speed = speed;
            HP = 6;
            Shot = rndY;
            _step = step;
            Width = 7;
        }

        #endregion

        #region Member Functions

        public override void Do(GameAction source)
        {
            Y += _step;
        }

        #endregion
    }
}
