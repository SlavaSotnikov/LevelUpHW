using System;
using System.Text;

namespace Game
{
    class UI
    {
        static string[] _shot = { "|" };

        static string[] _lightShip = new string[5] 
        { "    ▲    ",
          "    Ο    ",
          "  ║ Ο ║  ",
          "╱╲╲╲Λ╱╱╱╲",
          "  <╱╦╲>  "
        };

        static string[] _heavyShip = new string[5]
        { "    ▲    ",
          "   ╱Ο╲   ",
          "∩ ╱UKR╲ ∩",
          "╠═══Λ═══╣",
          " <╱*╦*╲> "
        };

        static string[] _enemyShip = new string[3]
        {
        "╲(|-|)╱",
        "˂=-O-=˃",
        "   ˅   "
        };

        private const int WIDTH = 120;         // Width of buffer of consol window.
        private const int HEIGHT = 40;         // Height of buffer of console window.

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

            SpaceObject shipModel;

            if (System.Enum.TryParse(model, true, out shipModel))
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

        public static GameAction AskConsole()
        {
            GameAction userEvent = GameAction.NoAction;

            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        userEvent = GameAction.LeftMove;
                        break;
                    case ConsoleKey.RightArrow:
                        userEvent = GameAction.RightMove;
                        break;
                    case ConsoleKey.UpArrow:
                        userEvent = GameAction.UpMove;
                        break;
                    case ConsoleKey.DownArrow:
                        userEvent = GameAction.DownMove;
                        break;
                    case ConsoleKey.Spacebar:
                        userEvent = GameAction.Shooting;
                        break;
                    case ConsoleKey.Escape:
                        userEvent = GameAction.Exit;
                        break;
                    default:
                        userEvent = GameAction.NoAction;
                        break;
                }
            }

            return userEvent;
        }

        public static void Hide(SpaceCraft source)
        {
            string[] image = GetImage(source);

            if (source.X != source.OldX 
                    || source.Y != source.OldY)
            {
                Print(source.OldX, source.OldY, ConsoleColor.Black, image);
            }

            source.OldX = source.X;
            source.OldY = source.Y;
        }

        public static void Show(SpaceCraft source)
        {
            string[] image = GetImage(source);

            if ((source.X != source.OldX
                    || source.Y != source.OldY) && source.Active)
            {
                Print(source.X, source.Y, ConsoleColor.White, image);

                if ((source is Ship one) && one.HitPoints <= 2)
                {
                    Print(source.X, source.Y, ConsoleColor.DarkRed, image);
                    Console.ResetColor();
                }
            }

            source.OldX = source.X;
            source.OldY = source.Y;
        }

        public static void PrintObject(SpaceCraft source)
        {
            string[] image = GetImage(source);

            if (source.X != source.OldX
                    || source.Y != source.OldY)
            {
                // Hide.
                Print(source.OldX, source.OldY, ConsoleColor.Black, image);

                if (source.Active)
                {
                    // Show.
                    Print(source.X, source.Y, ConsoleColor.White, image);

                    if (source is Ship one)
                    {
                        if (one.HitPoints <= 2)
                        {
                            Print(source.X, source.Y, ConsoleColor.DarkRed, image);
                            Console.ResetColor();
                        }
                    }
                }
            }

            source.OldX = source.X;
            source.OldY = source.Y;
        }

        public static void Print(int x, int y, ConsoleColor color, params string[] view)
        {
            for (int i = view.Length - 1; i >= 0; i--)
            {
                Console.SetCursorPosition(x, y + i);

                Console.ForegroundColor = color;
                Console.Write(view[i]);
            }
        }

        private static string[] GetImage(SpaceCraft source)    // TODO: Static constructor.
        {
            string[] image = _shot;

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

            return image;
        }

        public static void ShowDisplay(int hp, Space source)
        {
            Console.SetCursorPosition(source.LeftBorder, source.BottomBorder);
            Console.Write("HP: {0}%", hp);
            Console.SetCursorPosition(40, source.BottomBorder);
            Console.Write("Life: {0}");
        }
    }
}
