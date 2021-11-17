using System;
using System.Text;
using System.Threading;

namespace Game
{
    static class UI
    {
        #region Constants
        private const int WIDTH = 120;    // Width buffer of consol window.
        private const int HEIGHT = 40;    // Height buffer of console window.

        #endregion

        #region Private Data

        private static string[] _shot;

        private static string[] _star;

        private static string[] _lightShip;

        private static string[] _heavyShip;

        private static string[] _enemyShip;

        private static string _gameOver;

        #endregion

        #region Constructor

        static UI()
        {
            _shot = new string[] { "|" };

            _star = new string[] { "." };

            _lightShip = new string[5]
            {
               "    ▲    ",
               "    Ο    ",
               "  ║ Ο ║  ",
               "╱╲╲╲Λ╱╱╱╲",
               "  <╱╦╲>  "
            };

            _heavyShip = new string[5]
            {
              "    ▲    ",
              "   ╱Ο╲   ",
              "∩ ╱UKR╲ ∩",
              "╠═══Λ═══╣",
              " <╱*╦*╲> "
            };

            _enemyShip = new string[3]
            {
              "╲(|-|)╱",
              "˂=-O-=˃",
              "   ˅   "
            };

            _gameOver = @"
                                       ____ ____ _  _ ____    ____ _  _ ____ ____ 
                                       | __ |__| |\/| |___    |  | |  | |___ |__/ 
                                       |__] |  | |  | |___    |__|  \/  |___ |  \ ";
        }

        #endregion

        #region Methods

        public static void ShowExplosion(ClashException ex)
        {
            Console.SetCursorPosition(ex.X + 2, ex.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{ex.Message}");
            Console.ResetColor();
            Thread.Sleep(400);
        }

        public static void SetBufferSize()
        {
            Console.SetBufferSize(WIDTH, HEIGHT);

            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;
        }

        public static SpaceObject AskShipModel()
        {
            string model = "LightShip";/*Console.ReadLine();*/

            Console.Clear();

            if (Enum.TryParse(model, true, out SpaceObject shipModel))
            {
                switch (shipModel)
                {
                    case SpaceObject.None:
                        shipModel = SpaceObject.None;
                        break;
                    case SpaceObject.LightShip:
                        shipModel = SpaceObject.LightShip;
                        break;
                    case SpaceObject.HeavyShip:
                        shipModel = SpaceObject.HeavyShip;
                        break;
                    default:
                        shipModel = SpaceObject.None;
                        break;
                }
            }

            return shipModel;
        }

        public static Action PressKey()
        {
            Action userEvent = Action.NoAction;

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        userEvent = Action.LeftMove;
                        break;
                    case ConsoleKey.RightArrow:
                        userEvent = Action.RightMove;
                        break;
                    case ConsoleKey.UpArrow:
                        userEvent = Action.UpMove;
                        break;
                    case ConsoleKey.DownArrow:
                        userEvent = Action.DownMove;
                        break;
                    case ConsoleKey.Spacebar:
                        userEvent = Action.Shooting;
                        break;
                    case ConsoleKey.Escape:
                        userEvent = Action.Exit;
                        break;
                    default:
                        userEvent = Action.NoAction;
                        break;
                }
            }

            return userEvent;
        }

        public static void Hide(ISpaceCraft source)
        {
            if (source.X != source.OldX
                        || source.Y != source.OldY)
            {
                Print(source.OldX, source.OldY, ConsoleColor.Black, GetImage(source));
            }
        }

        public static void Show(ISpaceCraft source)
        {
            if ((source.X != source.OldX
                    || source.Y != source.OldY) && source.Active)
            {
                string[] image = GetImage(source);

                ConsoleColor color = ConsoleColor.White;

                if ((source is Ship one) && one.HP <= 2)
                {
                    color = ConsoleColor.DarkRed;
                }

                Print(source.X, source.Y, color, image);
            }
        }

        public static void Print(int x, int y, ConsoleColor color, params string[] view)
        {
            for (int i = 0; i < view.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);

                Console.ForegroundColor = color;
                Console.Write(view[i]);
            }
        }

        private static string[] GetImage(ISpaceCraft source)
        {
            string[] image = _star;

            if (source is LightShip)
            {
                image = _lightShip;
            }

            if (source is HeavyShip)
            {
                image = _heavyShip;
            }

            if (source is EnemyShip)
            {
                image = _enemyShip;
            }

            if (source is Shot)
            {
                image = _shot;
            }

            return image;
        }

        public static void ShowDisplay(IUserShip source)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(54, 38);
            Console.Write("HP: {0, -2}", source.HP);
            Console.SetCursorPosition(54, 39);
            Console.Write("Life: {0}", source.Life);
        }

        public static void PrintGameOver(object sender, EventArgs e)
        {
            Console.SetCursorPosition(0, 18);
            Console.WriteLine("{0}", _gameOver);
        }

        #endregion
    }
}
