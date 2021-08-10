using System;

namespace Game
{
    class LightShip : UserShip
    {
        #region Private Data

        private string[] _image = new string[5]
        { "    ▲    ",
          "    Ο    ",
          "  ║ Ο ║  ",
          "╱╲╲╲Λ╱╱╱╲",
          "  <╱╦╲>  "
        };

        #endregion

        #region Properties

        public override string[] View
        {
            get
            {
                return _image;
            }
        }

        #endregion

        #region Constructors

        public LightShip()
            : base()
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
                    if (_coordX <= GameField.LEFT_BORDER)
                    {
                        _coordX = GameField.LEFT_BORDER;
                    }
                    break;

                case Actions.RightMove:
                    ++_coordX;
                    if (_coordX >= GameField.RIGHT_BORDER)
                    {
                        _coordX = GameField.RIGHT_BORDER;
                    }
                    break;

                case Actions.UpMove:
                    --_coordY;
                    if (_coordY <= GameField.TOP_BORDER)
                    {
                        _coordY = GameField.TOP_BORDER;
                    }
                    break;

                case Actions.DownMove:
                    ++_coordY;
                    if (_coordY >= GameField.BOTTOM_BORDER)
                    {
                        _coordY = GameField.BOTTOM_BORDER;
                    }
                    break;

                case Actions.Shooting:

                    break;

                default:
                    break;
            }
        }

        #endregion
    }
}
