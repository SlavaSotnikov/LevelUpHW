using System;

namespace MoveShip
{
    class BL
    {
        #region Constants

        const int INITIAL_X = 53;      // Initial X position of Spaceship.
        const int INITIAL_Y = 33;      // Initial Y position of Spaceship.

        const byte HITPOINTS = 100;    // Initial value of Hit Points.
        const byte LIFES = 3;          // Initial value of Life.

        public static char bulletLeft = '│';
        public static char bulletRight = '│';

        const int RESET = 0;

        const byte STEP = 1;    // One step in Console's coordinate.
        const byte LEFT_SHIFT = 2;   // This shift tunes the Left bullet. 
        const byte RIGHT_SHIFT = 6;   // This shift tunes the Right bullet. 

        const byte TOP_BORDER = 38;
        const byte BOTTOM_BORDER = 39;
        const byte LEFT_BORDER = 30;
        const byte RIGHT_BORDER = 83;

        #endregion


        /// <summary>
        /// It alters the coordinates X or Y.
        /// </summary>
        /// <param name="borders">Geme field size.</param>
        /// <param name="userAction">User direction enum from console.</param>
        /// <param name="coordinateX">Reference to X coordinate.</param>
        /// <param name="coordinateY">Reference to Y coordinate.</param>
        public static void EventProcessing(ref Spacecraft ship, GameField borders, Actions userAction, ref Cartridge shipMag)
        {
            switch (userAction)
            {
                case Actions.Left:
                    --ship.сoordinateX;
                    if (ship.сoordinateX <= borders.left)
                    {
                        ship.сoordinateX = borders.left;
                    }
                    break;

                case Actions.Right:
                    ++ship.сoordinateX;
                    if (ship.сoordinateX >= borders.right)
                    {
                        ship.сoordinateX = borders.right;
                    }
                    break;

                case Actions.Up:
                    --ship.сoordinateY;
                    if (ship.сoordinateY <= borders.top)
                    {
                        ship.сoordinateY = borders.top;
                    }
                    break;

                case Actions.Down:
                    ++ship.сoordinateY;
                    if (ship.сoordinateY >= borders.bottom)
                    {
                        ship.сoordinateY = borders.bottom;
                    }
                    break;

                case Actions.Spacebar:
                    Shooting(ref shipMag, ref ship);
                    break;

                default:
                    break;
            }
        }

        #region Shooting

        public static Cartridge CreateCartridge(int capacity)
        {
            Cartridge clip = new Cartridge
            {
                mag = new Shot[capacity],
                countOfShots = 0,
                methodCounterPrintShot = 0
            };

            return clip;
        }

        public static void AddShotToMag(ref Cartridge source, ref Spacecraft ship, Shot left, Shot right, byte count=0)
        {
            if (source.countOfShots < source.mag.Length)
            {
                source.mag[source.countOfShots] = left;
                ++source.countOfShots;

                source.mag[source.countOfShots] = right;
                ++source.countOfShots;
            }
        }

        public static void CleanMag(ref Cartridge source, int i)
        {
            if (!source.mag[i].active)
            {
                for (int j = i; j < source.countOfShots - 1; j++)
                {
                    source.mag[j] = source.mag[j + 1];

                    break;
                }

                --source.countOfShots;
            }
        }

        public static Shot CreateLeftShot(ref Spacecraft ship)
        {
            Shot leftBullet = new Shot()
            {
                coordinateX = ship.сoordinateX + LEFT_SHIFT,
                coordinateY = ship.сoordinateY + 1,
                oldCoordinateX = ship.сoordinateX,
                oldCoordinateY = ship.oldCoordinateY,
                view = bulletLeft,
                active = true,
                speed = 5000,
                counter = 0
            };

            return leftBullet;
        }

        public static Shot CreateRightShot(ref Spacecraft ship)
        {
            Shot rightBullet = new Shot()
            {
                coordinateX = ship.сoordinateX + RIGHT_SHIFT,
                coordinateY = ship.сoordinateY + 1,
                oldCoordinateX = ship.сoordinateX,
                oldCoordinateY = ship.oldCoordinateY,
                view = bulletRight,
                active = true,
                speed = 5000,
                counter = 0
            };

            return rightBullet;
        }

        public static void ModifyBulletCoordinate(ref Shot bullet)
        {
            bullet.coordinateY -= STEP;
        }

        public static void Shooting(ref Cartridge shipMag, ref Spacecraft ship)
        {
            Shot left = CreateLeftShot(ref ship);
            Shot right = CreateRightShot(ref ship);

            AddShotToMag(ref shipMag, ref ship, left, right);
        }

        #endregion

        #region Enemies

        public static Swarm CreateSwarm(int capacity)
        {
            Swarm enemies = new Swarm
            {
                enemyFly = new Fly[capacity],
                countOfFly = 0,
                methodCounterPrintSwarm = 0,
                speed = 400000
            };

            return enemies;
        }

        public static Fly GetFullCopy(Fly source)
        {
            Fly destination = new Fly()
            {
                coordinateX = source.coordinateX,
                coordinateY = source.coordinateY,
                oldCoordinateX = source.oldCoordinateX,
                oldCoordinateY = source.oldCoordinateY,
                active = source.active,
                counter = source.counter,
                speed = source.speed,
                view = (string[])source.view.Clone()
            };

            return destination;
        }

        public static Fly CreateFly()
        {
            Fly enemy = new Fly()
            {
                coordinateX = BL_Random.GetCoordinateX(),
                coordinateY = 1,
                oldCoordinateX = 58 - 1,
                oldCoordinateY = 2 - 1,
                view = UI.fly,
                active = true,
                speed = BL_Random.GetSpeed(),
                counter = 0
            };

            return enemy;
        }

        public static void ProduceEnemies(ref Swarm enemies)
        {
            ++enemies.methodCounterProduceFly;

            if (enemies.methodCounterProduceFly == enemies.speed)
            {
                enemies.methodCounterProduceFly = RESET;

                Fly enemy = CreateFly();

                AddFlyToSwarm(ref enemies, ref enemy);
            }
        }

        public static void AddFlyToSwarm(ref Swarm source, ref Fly enemy)
        {
            if (source.countOfFly < source.enemyFly.Length)
            {
                source.enemyFly[source.countOfFly] = GetFullCopy(enemy);
                ++source.countOfFly;
            }
            else
            {
                for (int i = 0; i < source.countOfFly; i++)
                {
                    if (!source.enemyFly[i].active)
                    {
                        source.enemyFly[i] = GetFullCopy(enemy);

                        break;
                    }
                }
            }
        }

        public static void CleanSwarm(ref Swarm source)
        {
            for (int i = 0; i < source.countOfFly - 1; i++)
            {
                if (!source.enemyFly[i].active)
                {
                    for (int j = i; j < source.countOfFly - 1; j++)
                    {
                        source.enemyFly[j] = source.enemyFly[j + 1];
                    }

                    --source.countOfFly;
                }
            }
        }

        #endregion

        public static Spacecraft InitSpacecraft(string[] source)
        {
            Spacecraft ship = new Spacecraft()
            {
                сoordinateX = INITIAL_X,
                сoordinateY = INITIAL_Y,
                oldCoordinateX = INITIAL_X + 1,     // Is it correct?
                oldCoordinateY = INITIAL_Y - 1,
                view = source,
                alive = true,
                hitPoints = HITPOINTS,
                life = LIFES
            };

            return ship;
        }

        public static void ModifyFlyCoordinate(ref Fly enemy)
        {
            enemy.coordinateY += STEP;
        }

        public static void CheckAllObjects(ref Cartridge source, ref Swarm enemies, GameField borders, Display battle)
        {
            for (int i = 0; i < source.countOfShots; i++)
            {
                CheckShot(ref source.mag[i], borders);
            }

            for (int i = 0; i < enemies.countOfFly; i++)
            {
                CheckFly(ref enemies.enemyFly[i], ref enemies, borders);
            }
        }

        public static void CheckShotAndFly(ref Shot bullet, ref Fly enemy)
        {
            if (bullet.coordinateY == enemy.coordinateY)
            {
                bullet.active = false;
                enemy.active = false;
            }
        }

        public static void CheckShot(ref Shot bullet, GameField borders)
        {
            if (bullet.coordinateY <= borders.top)
            {
                bullet.active = false;
            }

            //if (bullet.coordinateY == enemy.coordinateY)
            //{
            //    bullet.active = false;
            //}
        }

        public static void CheckFly(ref Fly enemy, ref Swarm enemies, GameField borders)
        {
            if (enemy.coordinateY >= borders.bottom + 2) // TODO Fix +2
            {
                enemy.active = false;
            }

            //if (enemy.coordinateY == bullet.coordinateY)
            //{
            //    enemy.active = false;
            //}
        }
    }
}