using System;

namespace Game
{
    class LightShip : UserShip
    {
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

        #region Constructors

        public LightShip(GameField game, int coordX, int coordY, bool active,
                uint speed, uint counter, byte hitpoints, byte lifes, int oldCoordX=0, int oldCoordY=0)
            : base(game, coordX, coordY, active, speed, counter, hitpoints, lifes, oldCoordX, oldCoordY)
        {
        }

        #endregion

        #region Methods

        public override void Step()
        {
            switch (UI.AskConsole())
            {
                case Actions.LeftMove:
                    --_coordX;
                    if (_coordX <= _game.LeftBorder)
                    {
                        _coordX = _game.LeftBorder;
                    }
                    break;

                case Actions.RightMove:
                    ++_coordX;
                    if (_coordX >= _game.RightBorder)
                    {
                        _coordX = _game.RightBorder;
                    }
                    break;

                case Actions.UpMove:
                    --_coordY;
                    if (_coordY <= _game.TopBorder)
                    {
                        _coordY = _game.TopBorder;
                    }
                    break;

                case Actions.DownMove:
                    ++_coordY;
                    if (_coordY >= _game.BottomBorder)
                    {
                        _coordY = _game.BottomBorder;
                    }
                    break;

                case Actions.Shooting:
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
