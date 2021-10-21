namespace SpaceInvadersDLL
{
    public class LightShip : UserShip
    {
        #region Properties

        public override byte HP { get; set; }

        public override byte OldHP { get; set; }

        public override byte Width { get; set; }

        #endregion

        #region Constructors

        internal LightShip(ISpace game, int coordX, int coordY, bool active,
                uint speed, uint counter, byte hitpoints, byte lifes,
                    int oldCoordX = 0, int oldCoordY = 0)
            : base(game, coordX, coordY, active, speed, counter,
                    hitpoints, lifes, oldCoordX, oldCoordY)
        {
        }

        #endregion

        #region Member Functions

        public override void Do(GameAction source)
        {
            switch (source /*Controller.GetEvent()*/)    // TODO: It's necessary to set source = NoActions.
            {
                case GameAction.LeftMove:
                    if (X > _game.LeftBorder)
                    {
                        --X;
                    }
                    break;

                case GameAction.RightMove:
                    if (X < _game.RightBorder)
                    {
                        ++X;
                    }
                    break;

                case GameAction.UpMove:
                    if (Y > _game.TopBorder)
                    {
                        --Y;
                    }
                    break;

                case GameAction.DownMove:
                    if (Y < _game.BottomBorder)
                    {
                        ++Y;
                    }
                    break;

                case GameAction.Shooting:
                    _game.AddObject(SpaceObject.ShotLeft);
                    _game.AddObject(SpaceObject.ShotRight);
                    break;

                case GameAction.NoAction:
                    break;

                default:
                    break;
            }
        }

        #endregion
    }
}
