using System;

namespace Game
{
    class LightShip : UserShip
    {
        #region Properties

        public override byte HitPoints
        {
            get
            {
                return _hitPoints;
            }

            set
            {
                _hitPoints = value;
            }
        }

        public override byte OldHitPoints
        {
            get
            {
                return _oldHitPoints;
            }

            set
            {
                _oldHitPoints = value;
            }
        }

        public override byte Width
        {
            get
            {
                return _width;
            }
        }

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
                    --_coordX;
                    if (_coordX <= _game.LeftBorder)
                    {
                        _coordX = _game.LeftBorder;
                    }
                    break;

                case GameAction.RightMove:
                    ++_coordX;
                    if (_coordX >= _game.RightBorder)
                    {
                        _coordX = _game.RightBorder;
                    }
                    break;

                case GameAction.UpMove:
                    --_coordY;
                    if (_coordY <= _game.TopBorder)
                    {
                        _coordY = _game.TopBorder;
                    }
                    break;

                case GameAction.DownMove:
                    ++_coordY;
                    if (_coordY >= _game.BottomBorder)
                    {
                        _coordY = _game.BottomBorder;
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
