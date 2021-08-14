﻿using System;
using System.Text;

namespace Game
{
    class UI
    {
        static string[] _lightShip = new string[5] // TODO: Static array.
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

        public static void ShowAmountOfObjects()
        {
            if (GameField.GFAmount != GameField.OldGFAmount)
            {
                Console.SetCursorPosition(90, 1);
                Console.WriteLine("GF: {0}", GameField.GFAmount);

                GameField.OldGFAmount = GameField.GFAmount;
            }

            if (UserShip.ShipAmount != UserShip.OldShipAmount)
            {
                Console.SetCursorPosition(90, 2);
                Console.WriteLine("User ships: {0}", UserShip.ShipAmount);

                UserShip.OldShipAmount = UserShip.ShipAmount;
            }

            if (Shot.ShotAmount != Shot.OldShotAmount)
            {
                Console.SetCursorPosition(90, 3);
                Console.WriteLine("Shots: {0}", Shot.ShotAmount);

                Shot.OldShotAmount = Shot.ShotAmount;
            }

            if (EnemyShip.EnemyAmount != EnemyShip.OldEnemyAmount)
            {
                Console.SetCursorPosition(90, 4);
                Console.WriteLine("Enemy: {0}", EnemyShip.EnemyAmount);

                EnemyShip.OldEnemyAmount = EnemyShip.EnemyAmount;
            }
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

                    if (source is EnemyShip)
                    {
                        EnemyShip one = (EnemyShip)source;

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

        private static void Print(int x, int y, ConsoleColor color, params string[] view)
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
            string[] image = { "|" };

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

        public static void ShowDisplay(int hp, GameField source)
        {
            Console.SetCursorPosition(source.LeftBorder, source.BottomBorder);
            Console.Write("HP: {0}%", hp);
            Console.SetCursorPosition(40, source.BottomBorder);
            Console.Write("Life: {0}");
        }
    }
}
