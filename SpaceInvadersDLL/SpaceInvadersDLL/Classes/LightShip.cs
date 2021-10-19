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

        public LightShip(ISpace game, int coordX, int coordY, bool active,
                uint speed, uint counter, byte hitpoints, byte lifes,
                    int oldCoordX = 0, int oldCoordY = 0)
            : base(game, coordX, coordY, active, speed, counter,
                    hitpoints, lifes, oldCoordX, oldCoordY)
        {
        }

        #endregion

        #region Member Functions

        public override void Do(Action source)
        {
            switch (source /*Controller.GetEvent()*/)
            {
                case Action.LeftMove:
                    if (X > _game.LeftBorder)
                    {
                        X -= 3;
                    }
                    break;

                case Action.RightMove:
                    if (X < _game.RightBorder)
                    {
                        X += 3;
                    }
                    break;

                case Action.UpMove:
                    if (Y > _game.TopBorder)
                    {
                        Y -= 3;
                    }
                    break;

                case Action.DownMove:
                    if (Y < _game.BottomBorder)
                    {
                        Y += 3;
                    }
                    break;

                case Action.Shooting:
                    _game.AddObject(SpaceObject.ShotLeft);
                    _game.AddObject(SpaceObject.ShotRight);
                    break;

                case Action.NoAction:
                    break;

                default:
                    break;
            }
        }

        #endregion
    }
}
