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

        const byte HITS = 6;

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
                case Actions.LeftMove:
                    --ship.сoordinateX;
                    if (ship.сoordinateX <= borders.left)
                    {
                        ship.сoordinateX = borders.left;
                    }
                    break;

                case Actions.RightMove:
                    ++ship.сoordinateX;
                    if (ship.сoordinateX >= borders.right)
                    {
                        ship.сoordinateX = borders.right;
                    }
                    break;

                case Actions.UpMove:
                    --ship.сoordinateY;
                    if (ship.сoordinateY <= borders.top)
                    {
                        ship.сoordinateY = borders.top;
                    }
                    break;

                case Actions.DownMove:
                    ++ship.сoordinateY;
                    if (ship.сoordinateY >= borders.bottom)
                    {
                        ship.сoordinateY = borders.bottom;
                    }
                    break;

                case Actions.Shooting:
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
                methodCounterPrintShot = 0,
            };

            return clip;
        }

        public static void AddShotToMag(ref Cartridge source, Shot left, Shot right)
        {
            if (source.countOfShots < source.mag.Length)
            {
                source.mag[source.countOfShots] = left;
                ++source.countOfShots;

                source.mag[source.countOfShots] = right;
                ++source.countOfShots;
            }
        }

        public static void CleanMag(ref Cartridge source)
        {
            for (int i = 0; i < source.countOfShots; i++)
            {
                if (source.mag[i].counter % source.mag[i].speed == 0)
                {
                    while (!source.mag[i].active && source.countOfShots > 0)
                    {
                        for (int j = i; j < source.countOfShots - 1; j++)
                        {
                            source.mag[j] = source.mag[j + 1];
                        }

                        --source.countOfShots;
                    }
                }
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

            AddShotToMag(ref shipMag, left, right);
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
                speed = 350000
            };

            return enemies;
        }

        public static Fly GetFullCopy(Fly source)
        {
            Fly destination = new Fly()
            {
                coordinateX = BL_Random.GetCoordinateX(),
                coordinateY = 1,
                oldCoordinateX = source.oldCoordinateX,
                oldCoordinateY = source.oldCoordinateY,
                active = source.active,
                counter = source.counter,
                speed = BL_Random.GetFlySpeed(),
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
                speed = BL_Random.GetFlySpeed(),
                counter = 0
            };

            return enemy;
        }

        public static void ProduceEnemies(ref Swarm enemies, ref Fly enemy)
        {
            ++enemies.methodCounterProduceFly;

            if (enemies.methodCounterProduceFly % enemies.speed == 0)
            {
                enemies.methodCounterProduceFly = RESET;

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
        }

        public static void CleanSwarm(ref Swarm source)
        {
            for (int i = 0; i < source.countOfFly - 1; i++)
            {
                if (source.enemyFly[i].counter % source.enemyFly[i].speed == 0)
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

        public static void CheckAllObjects(ref Cartridge source, ref Swarm enemies, ref Display battle, GameField borders)
        {
            CheckShot(ref source, borders);

            CheckFly(ref enemies, ref battle, borders);

            CheckShotAndFly(ref enemies, ref source, ref battle);
        }

        public static void CheckShotAndFly(ref Swarm enemies, ref Cartridge source, ref Display battle)
        {
            for (int i = 0; i < enemies.countOfFly; i++)
            {
                for (int j = 0; j < source.countOfShots; j++)
                {
                    if ((enemies.enemyFly[i].coordinateY == source.mag[j].coordinateY) && // TODO: Add method
                            (enemies.enemyFly[i].coordinateX < source.mag[j].coordinateX) &&
                                (source.mag[j].coordinateX < enemies.enemyFly[i].coordinateX + 6))
                    {
                        if (source.mag[j].active)
                        {
                            source.mag[j].active = false;
                            enemies.enemyFly[i].hit += 1;

                            if (enemies.enemyFly[i].hit >= HITS)
                            {
                                enemies.enemyFly[i].active = false;
                                battle.killed += 1;
                                //battle.enemies -= 1;
                            }
                        }
                    }
                }
            }
        }

        public static void CheckShot(ref Cartridge source, GameField borders)
        {
            for (int i = 0; i < source.countOfShots; i++)
            {
                if (source.mag[i].coordinateY <= borders.top)
                {
                    source.mag[i].active = false;
                }
            }
            
        }

        public static void CheckFly(ref Swarm enemies, ref Display battle, GameField borders)
        {
            for (int i = 0; i < enemies.countOfFly; i++)
            {
                if (enemies.enemyFly[i].coordinateY >= borders.bottom + 2) // TODO: Fix +2
                {
                    enemies.enemyFly[i].active = false;

                    if (enemies.enemyFly[i].counter % enemies.enemyFly[i].speed == 0)
                    {
                        battle.skip += 1;
                    }
                }
            }
        }

        public static void CleanDataStructures(ref Swarm enemies, ref Cartridge shipMag)
        {
            CleanSwarm(ref enemies);

            CleanMag(ref shipMag);
        }
    }
}