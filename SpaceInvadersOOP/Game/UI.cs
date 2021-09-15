﻿using System;
using System.Text;
using System.Threading;

namespace Game
{
    static class UI    // TODO: 1 - Ask a question, what's going on?
    {
        #region Constants

        private const int WIDTH = 120;         // Width buffer of consol window.
        private const int HEIGHT = 40;         // Height buffer of console window.

        #endregion

        #region Private Data

        private static string[] _shot;

        private static string[] _lightShip;

        private static string[] _heavyShip;

        private static string[] _enemyShip;

        #endregion

        #region Constructor

        static UI()    // TODO: 2 - Ask a question, what's going on?
        {
            _shot = new string[] { "|" };

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

                Print(source.X, source.Y, ConsoleColor.White, image);

                if ((source is Ship one) && one.HitPoints <= 2)
                {
                    Print(one.X, one.Y, ConsoleColor.DarkRed, image);
                    Console.ResetColor();
                }
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

        private static string[] GetImage(ISpaceCraft source)    // TODO: Static constructor.
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

        //public static void ShowDisplay(int hp, Space source)
        //{
        //    Console.SetCursorPosition(source.LeftBorder, source.BottomBorder);
        //    Console.Write("HP: {0}%", hp);
        //    Console.SetCursorPosition(40, source.BottomBorder);
        //    Console.Write("Life: {0}");
        //}

        #endregion
    }
}
