using System;

namespace Game
{
    class LightShip : UserShip
    {
        #region Properties

        public override byte HP { get; set; }

        public override byte OldHP { get; set; }

        public override byte Width { get; set; }

        #endregion

        #region Constructors

        public LightShip(ISpace game, int coordX, int coordY, bool active,
                uint speed, uint counter, byte hitpoints, byte lifes,
                    int oldCoordX=0, int oldCoordY= 0)
            : base(game, coordX, coordY, active, speed, counter, 
                    hitpoints, lifes, oldCoordX, oldCoordY)
        {

        }

        #endregion

        #region Member Functions

        public override void Step()
        {
            switch (Controller.GetEvent())
            {
                case GameAction.LeftMove:
                    --X;
                    if (X <= _game.LeftBorder)
                    {
                        X = _game.LeftBorder;
                    }
                    break;

                case GameAction.RightMove:
                    ++X;
                    if (X >= _game.RightBorder)
                    {
                        X = _game.RightBorder;
                    }
                    break;

                case GameAction.UpMove:
                    --Y;
                    if (Y <= _game.TopBorder)
                    {
                        Y = _game.TopBorder;
                    }
                    break;

                case GameAction.DownMove:
                    ++Y;
                    if (Y >= _game.BottomBorder)
                    {
                        Y = _game.BottomBorder;
                    }
                    break;

                case GameAction.Shooting:
                    _game.AddObject(SpaceObject.ShotLeft);
                    _game.AddObject(SpaceObject.ShotRight);
                    break;

                default:
                    break;
            }
        }

        #endregion
    }
}
