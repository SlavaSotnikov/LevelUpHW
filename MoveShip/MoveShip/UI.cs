using System;
using System.Threading;

namespace MoveShip
{
    class UI
    {
        const int LEFT_BORDER = 30;    // The Left border of game field.
        const int RIGHT_BORDER = 83;   // The Right border of game field.
        const int TOP_BORDER = 0;      // The Top border of game field.
        const int BOTTOM_BORDER = 33;  // The Bottom border of game field.

        const int WIDTH = 120;         // Width of buffer of consol window.
        const int HEIGHT = 40;         // Height of buffer of console window.

       

        const int RESET = 0;           // Initial value.

        private static string[] lightShip = new string[5]
        { "    ▲    ",
          "    Ο    ",
          "  ║ Ο ║  ",
          "╱╲╲╲Λ╱╱╱╲",
          "  <╱╦╲>  "
        };

        private static string[] heavyShip = new string[5]
        { "    ▲    ",
          "   ╱Ο╲   ",
          "∩ ╱UKR╲ ∩",
          "╠═══Λ═══╣",
          " <╱*╦*╲> "
        };

        public static string[] fly = new string[3]
        {
            "╲(|-|)╱",
            "˂=-O-=˃",
            "   ˅   "
        };

        /// <summary>
        /// Print a spacecraft.
        /// </summary>
        /// <param name="spacecraft">A spacecraft model.</param>
        /// <param name="color">The colour of spacecraft.</param>
        /// <param name="coordX">X coordinate.</param>
        /// <param name="coordY">Y coordinate.</param>
        public static void PrintSpacecraft(Spacecraft ship, ConsoleColor color)
        {
            for (int i = ship.view.Length - 1; i >= 0; i--)
            {
                Console.SetCursorPosition(ship.сoordinateX, ship.сoordinateY + i);

                Console.ForegroundColor = color;
                Console.Write(ship.view[i]);
            }
        }

        public static void HideSpacecraft(Spacecraft ship, ConsoleColor color)
        {
            for (int i = ship.view.Length - 1; i >= 0; i--)
            {
                Console.SetCursorPosition(ship.oldCoordinateX, ship.oldCoordinateY + i);

                Console.ForegroundColor = color;
                Console.Write(ship.view[i]);
            }
        }

        /// <summary>
        /// Prints the battle menu in console.
        /// </summary>
        /// <param name="name">Player's name.</param>
        /// <param name="country">Player's country.</param>
        /// <param name="hp">Amount of hit points.</param>
        /// <param name="life">Amount of life points.</param>
        /// <param name="skip">Amount of skipped ships.</param>
        /// <param name="killed">Amount of killed enemies</param>
        /// <param name="enemies">Initial amount of enemies.</param>
        public static void ShowBattleMenu(ref Display battle)
        {
            if (true) //TODO Develop the method.
            {
                Console.SetCursorPosition(45, battle.topBorder);
                Console.Write("Pilot: {0}", battle.name);
                Console.SetCursorPosition(58, battle.topBorder);
                Console.Write("From: {0}", battle.country);
                Console.SetCursorPosition(30, battle.bottomBorder);
                Console.Write("HP: {0}%", battle.hp);
                Console.SetCursorPosition(40, battle.bottomBorder);
                Console.Write("Life: {0}", battle.life);
                Console.SetCursorPosition(51, battle.bottomBorder);
                Console.Write("Missed Enemies: {0}", battle.skip);
                Console.SetCursorPosition(70, battle.bottomBorder);
                Console.Write("MyKills: {0}", battle.killed);
                Console.SetCursorPosition(81, battle.bottomBorder);
                Console.Write("Enemies: {0}", battle.enemies);
            }
        }

        /// <summary>
        /// Initial buffer size of console.
        /// </summary>
        public static void SetBufferSize()
        {
            Console.SetBufferSize(WIDTH, HEIGHT);
        }

        /// <summary>
        /// It sets the borders of game field.
        /// </summary>
        /// <returns>Game field's borders</returns>
        public static GameField SetGameFieldBorders()
        {
            GameField borders = new GameField()
            {
                leftBorder = LEFT_BORDER,
                rightBorder = RIGHT_BORDER,
                topBorder = TOP_BORDER,
                bottomBorder = BOTTOM_BORDER
            };

            return borders;
        }

        public static Display SetButtleDisplay()
        {
            Display dashboard = new Display()
            {
                leftBorder = LEFT_BORDER,
                rightBorder = RIGHT_BORDER,
                topBorder = 38,
                bottomBorder = 39,
            };

            return dashboard;
        }

        /// <summary>
        /// Ask user for direction.
        /// </summary>
        /// <returns>User direction.</returns>
        public static Actions AskConsole()
        {
            Actions userEvent = Actions.NoDirection;

            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        userEvent = Actions.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        userEvent = Actions.Right;
                        break;
                    case ConsoleKey.UpArrow:
                        userEvent = Actions.Up;
                        break;
                    case ConsoleKey.DownArrow:
                        userEvent = Actions.Down;
                        break;
                    case ConsoleKey.Spacebar:
                        userEvent = Actions.Spacebar;
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

        public static void PrintShots(ref Cartridge source)
        {
            ++source.methodCounterPrintShot;

            if (source.methodCounterPrintShot == 5000)
            {
                source.methodCounterPrintShot = RESET;

                for (int i = 0; i < source.countOfShots; i++)
                {
                    ShowHideShots(ref source.mag[i]);
                }
            }
        }

        public static void ShowHideShots(ref Shot bullet)
        {
            HideBullet(bullet);

            if (bullet.active == true)
            {
                BL.ModifyBulletCoordinate(ref bullet);

                PrintBullet(bullet);

                bullet.oldCoordinateX = bullet.coordinateX;
                bullet.oldCoordinateY = bullet.coordinateY;
            }
        }

        public static void HideBullet(Shot bullet, char invisible = '\0') // Is it correct?
        {
            Console.SetCursorPosition(bullet.oldCoordinateX, bullet.oldCoordinateY);
            Console.Write(invisible);
        }

        public static void PrintBullet(Shot bullet)
        {
            Console.SetCursorPosition(bullet.coordinateX, bullet.coordinateY);
            Console.Write(bullet.view);
        }

        public void KeyPressed()
        {
            if (true)
            {

            }
        }

        public void KeyReleased()
        {

        }

        public static Spacecraft AskShipModel()
        {
            string model = Console.ReadLine();

            Console.Clear();

            Model shipModel;

            string[] viewShip = new string[5];

            if (Enum.TryParse(model, true, out shipModel))
            {
                switch (shipModel)
                {
                    case Model.None:
                        break;
                    case Model.LightShip:
                        viewShip = lightShip;
                        break;
                    case Model.HeavyShip:
                        viewShip = heavyShip;
                        break;
                    default:
                        break;
                }
            }

            return BL.InitSpacecraft(viewShip);
        }

        public static void ShowHideSpacecraft(Spacecraft ship)
        {
            if (ship.сoordinateX != ship.oldCoordinateX || ship.сoordinateY != ship.oldCoordinateY)
            {
                // Hide previous coordinates of the Spaceship.
                HideSpacecraft(ship, ConsoleColor.Black);

                // Show the Spaceship.
                PrintSpacecraft(ship, ConsoleColor.Gray);
            }
        }

        public static void PrintEnemies(ref Swarm source)
        {
            ++source.methodCounterPrintSwarm;

            if (source.methodCounterPrintSwarm == 90000)
            {
                source.methodCounterPrintSwarm = RESET;

                for (int i = 0; i < source.countOfFly; i++)
                {
                    ShowHideEnemies(ref source.enemyFly[i]);
                }
            }
        }

        public static void ShowHideEnemies(ref Fly enemy)
        {
            HideEnemy(enemy);

            if (enemy.active == true)
            {
                BL.ModifyFlyCoordinate(ref enemy);

                PrintEnemy(enemy);

                enemy.oldCoordinateX = enemy.coordinateX;
                enemy.oldCoordinateY = enemy.coordinateY;
            }
        }

        public static void HideEnemy(Fly enemy, ConsoleColor color=ConsoleColor.Black) // Is it correct?
        {
            for (int i = enemy.view.Length - 1; i >= 0; i--)
            {
                Console.SetCursorPosition(enemy.oldCoordinateX, enemy.oldCoordinateY + i);

                Console.ForegroundColor = color;
                Console.Write(enemy.view[i]);
            }
        }

        public static void PrintEnemy(Fly enemy, ConsoleColor color=ConsoleColor.White)
        {
            for (int i = enemy.view.Length - 1; i >= 0; i--)
            {
                Console.SetCursorPosition(enemy.coordinateX, enemy.coordinateY + i);

                Console.ForegroundColor = color;
                Console.Write(enemy.view[i]);
            }
        }
    }
}