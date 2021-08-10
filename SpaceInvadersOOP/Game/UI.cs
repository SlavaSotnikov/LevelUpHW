using System;
using System.Text;

namespace Game
{
    class UI
    {
        private const int WIDTH = 120;         // Width of buffer of consol window.
        private const int HEIGHT = 40;         // Height of buffer of console window.

        public static void SetBufferSize()
        {
            Console.SetBufferSize(WIDTH, HEIGHT);

            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;
        }

        public static UserShip AskShipModel()
        {
            string model = "LightShip";/*Console.ReadLine();*/

            Console.Clear();

            Model shipModel;

            UserShip ship = null;

            if (Enum.TryParse(model, true, out shipModel))
            {
                switch (shipModel)
                {
                    case Model.None:
                        break;
                    case Model.LightShip:
                        ship = new LightShip();
                        break;
                    case Model.HeavyShip:
                        ship = new HeavyShip();
                        break;
                    default:
                        break;
                }
            }

            return ship;
        }

        public static Actions AskConsole()
        {
            Actions userEvent = Actions.NoDirection;

            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        userEvent = Actions.LeftMove;
                        break;
                    case ConsoleKey.RightArrow:
                        userEvent = Actions.RightMove;
                        break;
                    case ConsoleKey.UpArrow:
                        userEvent = Actions.UpMove;
                        break;
                    case ConsoleKey.DownArrow:
                        userEvent = Actions.DownMove;
                        break;
                    case ConsoleKey.Spacebar:
                        userEvent = Actions.Shooting;
                        break;
                    case ConsoleKey.Escape:
                        userEvent = Actions.Exit;
                        break;
                    default:
                        userEvent = Actions.NoDirection;
                        break;
                }
            }

            return userEvent;
        }

        public static void PrintObject(SpaceCraft source)
        {
            if (source.CoordinateX != source.OldCoordinateX 
                    || source.CoordinateY != source.OldCoordinateY)
            {
                // Hide.
                Print(source.OldCoordinateX, source.OldCoordinateY,
                        source.View, ConsoleColor.Black);

                // Show.
                Print(source.CoordinateX, source.CoordinateY,
                        source.View, ConsoleColor.White);
            }

            source.OldCoordinateX = source.CoordinateX;
            source.OldCoordinateY = source.CoordinateY;
        }

        private static void Print(int x, int y, string[] view, ConsoleColor color)
        {
            for (int i = view.Length - 1; i >= 0; i--)
            {
                Console.SetCursorPosition(x, y + i);

                Console.ForegroundColor = color;
                Console.Write(view[i]);
            }
        }
    }
}
