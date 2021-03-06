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

        public override byte Width 
        {
            get
            {
                return _width;
            }
        }

        #region Constructors

        public LightShip(Space game, int coordX, int coordY, bool active,
                uint speed, uint counter, byte hitpoints, byte lifes,
                    int oldCoordX=0, int oldCoordY= 0, byte width = 9)
            : base(game, coordX, coordY, active, speed, width, counter, 
                    hitpoints, lifes, oldCoordX, oldCoordY)
        {
        }

        #endregion

        #region Methods

        public override void Step()
        {
            switch (Game.GetEvent())
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
