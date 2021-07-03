using System;
using System.Threading;

namespace MoveShip
{
    class UI
    {
        #region Constants

        const int LEFT_BORDER = 30;    // The Left border of game field.
        const int RIGHT_BORDER = 83;   // The Right border of game field.
        const int TOP_BORDER = 0;      // The Top border of game field.
        const int BOTTOM_BORDER = 33;  // The Bottom border of game field.
        const int TOP_DISPLAY_BORDER = 38;  // The Top display border.
        const int BOTTOM_DISPLAY_BORDER = 39;  //  The Bottom display border.

        const int WIDTH = 120;         // Width of buffer of consol window.
        const int HEIGHT = 40;         // Height of buffer of console window.

        const int RESET = 0;           // Initial value.

        #endregion

        #region UserShip

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
        #endregion

        #region Enemies

        public static string[] fly = new string[3]
        {
            "╲(|-|)╱",
            "˂=-O-=˃",
            "   ˅   "
        };

        public static void PrintEnemies(ref Swarm source)
        {
            for (int i = 0; i < source.countOfFly; i++)
            {
                ++source.enemyFly[i].counter;

                if (source.enemyFly[i].counter % source.enemyFly[i].speed == 0)
                {
                    ShowHideEnemies(ref source.enemyFly[i]);
                }
            }
        }

        public static void ShowHideEnemies(ref Fly enemy)
        {
            HideEnemy(ref enemy);

            if (enemy.active)
            {
                BL.ModifyFlyCoordinate(ref enemy);

                if (enemy.hit >= 4)
                {
                    PrintEnemy(enemy, ConsoleColor.DarkRed);
                }
                else
                {
                    PrintEnemy(enemy);
                }

                enemy.oldCoordinateX = enemy.coordinateX;
                enemy.oldCoordinateY = enemy.coordinateY;
            }
        }

        public static void HideEnemy(ref Fly enemy, ConsoleColor color=ConsoleColor.Black) // Is it correct?
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
            for (int i = 0; i < enemy.view.Length; i++)
            {
                Console.SetCursorPosition(enemy.coordinateX, enemy.coordinateY + i);

                Console.ForegroundColor = color;
                Console.Write(enemy.view[i]);
            }

            Console.ResetColor();
        }

        #endregion

        #region Shooting

        public static void PrintShots(ref Cartridge source)
        {
            for (int i = 0; i < source.countOfShots; i++)
            {
                ++source.mag[i].counter;

                if (source.mag[i].counter % source.mag[i].speed == 0)
                {
                    source.mag[i].counter = RESET;

                    ShowHideShots(ref source.mag[i], ref source, i);
                }
            }
        }

        public static void ShowHideShots(ref Shot bullet, ref Cartridge source, int i)
        {
            HideBullet(bullet);

            if (bullet.active)
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

        #endregion

        #region FieldsDisplays

        public static Display CreateButtleDisplay()
        {
            Display battle = new Display
            {
                topBorder = TOP_DISPLAY_BORDER,
                bottomBorder = BOTTOM_DISPLAY_BORDER,
                leftBorder = LEFT_BORDER,
                rightBorder = RIGHT_BORDER,
                name = "Slava",
                country = "Ukraine",
                hp = 100,
                oldHp = 99,    // Pay your attention!!!
                life = 3,
                oldLife = 3,
                enemies = 20,
                oldEnemies = 20,
                skip = 0,
                oldSkip = 0,
                killed = 0,
                oldKilled = 0
            };

            return battle;
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
            if (battle.hp != battle.oldHp || battle.enemies != battle.oldEnemies ||
                   battle.killed != battle.oldKilled || battle.life != battle.oldLife ||
                      battle.skip != battle.oldSkip)
            {
                Console.SetCursorPosition(45, battle.topBorder);
                Console.Write("Pilot: {0}", battle.name);
                Console.SetCursorPosition(58, battle.topBorder);
                Console.Write("From: {0}", battle.country);
                Console.SetCursorPosition(battle.leftBorder, battle.bottomBorder);
                Console.Write("HP: {0}%", battle.hp);
                Console.SetCursorPosition(40, battle.bottomBorder);
                Console.Write("Life: {0}", battle.life);
                Console.SetCursorPosition(51, battle.bottomBorder);
                Console.Write("Missed Enemies: {0}", battle.skip);
                Console.SetCursorPosition(70, battle.bottomBorder);
                Console.Write("Killed: {0}", battle.killed);
                Console.SetCursorPosition(81, battle.bottomBorder);
                Console.Write("Enemies: {0}", battle.enemies);

                battle.oldHp = battle.hp;
                battle.oldEnemies = battle.enemies;
                battle.oldLife = battle.life;
                battle.oldKilled = battle.killed;
                battle.oldSkip = battle.skip;
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
                left = LEFT_BORDER,
                right = RIGHT_BORDER,
                top = TOP_BORDER,
                bottom = BOTTOM_BORDER
            };

            return borders;
        }

        #endregion

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

        public static Actions GetAction(Actions source)
        {
            Actions userEvent = Actions.NoDirection;

            if (source.HasFlag(Actions.UpMove))
            {
                userEvent = Actions.UpMove;
            }
            if (source.HasFlag(Actions.DownMove))
            {
                userEvent |= Actions.DownMove;
            }
            if (source.HasFlag(Actions.LeftMove))
            {
                userEvent |= Actions.LeftMove;
            }
            if (source.HasFlag(Actions.RightMove))
            {
                userEvent |= Actions.RightMove;
            }

            return userEvent;
        }
    }
}