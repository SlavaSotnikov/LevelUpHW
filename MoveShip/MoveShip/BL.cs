using System;

namespace MoveShip
{
    class BL
    {
        const int INITIAL_X = 53;      // Initial X position of Spaceship.
        const int INITIAL_Y = 33;      // Initial Y position of Spaceship.

        const byte HITPOINTS = 100;    // Initial value of Hit Points.
        const byte LIFES = 3;          // Initial value of Life.

        public static char bulletLeft  = '│';
        public static char bulletRight = '│';

        const int RESET = 0;

        const byte STEP = 1;    // One step in Console's coordinate.
        const byte LEFT_SHIFT = 2;   // This shift tunes the Left bullet. 
        const byte RIGHT_SHIFT = 6;   // This shift tunes the Right bullet. 

        const byte TOP_BORDER = 38;
        const byte BOTTOM_BORDER = 39;
        const byte LEFT_BORDER = 30;
        const byte RIGHT_BORDER = 83;

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
                    if (ship.сoordinateX <= borders.leftBorder)
                    {
                        ship.сoordinateX = borders.leftBorder;
                    }
                    break;

                case Actions.Right:
                    ++ship.сoordinateX;
                    if (ship.сoordinateX >= borders.rightBorder)
                    {
                        ship.сoordinateX = borders.rightBorder;
                    }
                    break;

                case Actions.Up:
                    --ship.сoordinateY;
                    if (ship.сoordinateY <= borders.topBorder)
                    {
                        ship.сoordinateY = borders.topBorder;
                    }
                    break;

                case Actions.Down:
                    ++ship.сoordinateY;
                    if (ship.сoordinateY >= borders.bottomBorder)
                    {
                        ship.сoordinateY = borders.bottomBorder;
                    }
                    break;

                case Actions.Spacebar:
                    Shooting(ref shipMag, ship);
                    break;

                default:
                    break;
            }
        }

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

        public static Display CreateButtleDisplay()
        {
            Display battle = new Display
            {
                topBorder = TOP_BORDER,
                bottomBorder = BOTTOM_BORDER,
                leftBorder = LEFT_BORDER,
                rightBorder = RIGHT_BORDER,
                name = "Slava",
                country = "Ukraine",
                hp = 100,
                life = 3,
                enemies = 20,
                skip = 0,
                killed = 0
            };

            return battle;
        }

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

        public static void AddShotToMag(ref Cartridge source, Shot left, Shot right)
        {
            if (source.countOfShots >= source.mag.Length)
            {
                Array.Resize(ref source.mag, source.mag.Length + 10);
            }

            source.mag[source.countOfShots] = left;
            ++source.countOfShots;

            source.mag[source.countOfShots] = right;
            ++source.countOfShots;
        }

        public static Shot CreateLeftShot(Spacecraft ship)
        {
            Shot leftBullet = new Shot()
            {
                coordinateX = ship.сoordinateX + LEFT_SHIFT,
                coordinateY = ship.сoordinateY + 1,
                oldCoordinateX = ship.сoordinateX,
                oldCoordinateY = ship.oldCoordinateY,
                view = bulletLeft,
                active = true
            };

            return leftBullet;
        }

        public static Shot CreateRightShot(Spacecraft ship)
        {
            Shot rightBullet = new Shot()
            {
                coordinateX = ship.сoordinateX + RIGHT_SHIFT,
                coordinateY = ship.сoordinateY + 1,
                oldCoordinateX = ship.сoordinateX,
                oldCoordinateY = ship.oldCoordinateY,
                view = bulletRight,
                active = true
            };

            return rightBullet;
        }

        public static void ModifyBulletCoordinate(ref Shot bullet)
        {
            bullet.coordinateY -= STEP;
        }

        public static void ModifyFlyCoordinate(ref Fly enemy)
        {
            enemy.coordinateY += STEP;
        }

        public static void CheckAllObjects(ref Cartridge source, GameField borders)
        {
            for (int i = 0; i < source.countOfShots; i++)
            {
                CheckShot(ref source.mag[i], borders);
            }
        }

        public static void CheckShot(ref Shot bullet, GameField borders)
        {
            if (bullet.coordinateY <= borders.topBorder)
            {
                bullet.active = false;
            }
        }

        public static void CleanStructures(ref Cartridge source)
        {
            byte deletedObjects = 0;

            for (int i = 0; i < source.countOfShots; i++)
            {
                //if ((false == source.mag[i].active) & (source.mag[i + 1].active == false) & 
                //      (true == source.mag[i + 2].active) & (source.mag[i + 3].active == true))
                //{
                //    source.mag[i] = source.mag[i + 2];
                //    source.mag[i + 1] = source.mag[i + 3];

                //    deletedObjects += 2;
                //}

                if ((source.mag[i].active == false) & (source.mag[i + 1].active == true))
                {
                    source.mag[i] = source.mag[i + 1];

                    ++deletedObjects;
                }

                source.countOfShots -= deletedObjects;
            }
        }

        public static void Shooting(ref Cartridge shipMag, Spacecraft ship)
        {
            ++shipMag.methodCounterShot;

            if (shipMag.methodCounterShot == 4)
            {
                shipMag.methodCounterShot = RESET;

                Shot leftBullet = CreateLeftShot(ship);
                Shot rightBullet = CreateRightShot(ship);

                AddShotToMag(ref shipMag, leftBullet, rightBullet); 
            }
        }

        public static Swarm CreateSwarm(int capacity)
        {
            Swarm enemies = new Swarm
            {
                enemyFly = new Fly[capacity],
                countOfFly = 0,
                methodCounterPrintSwarm = 0
            };

            return enemies;
        }

        public static void AddFlyToSwarm(ref Swarm source, ref Fly enemy)
        {
            if (source.countOfFly >= source.enemyFly.Length)
            {
                Array.Resize(ref source.enemyFly, source.enemyFly.Length + 10);
            }

            source.enemyFly[source.countOfFly] = GetFullCopy(enemy);
            ++source.countOfFly;
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
                view = (string[])source.view.Clone()
            };

            return destination;
        }

        public static Fly CreateFly()
        {
            Fly enemy = new Fly()
            {
                coordinateX = 58,
                coordinateY = 2,
                oldCoordinateX = 58 - 1,
                oldCoordinateY = 2 - 1,
                view = UI.fly,
                active = true
            };

            return enemy;
        }

        public static void ProduceEnemies(ref Swarm enemies)
        {
            ++enemies.methodCounterProduceFly;

            if (enemies.methodCounterProduceFly == 10000)
            {
                //enemies.methodCounterProduceFly = RESET;

                Fly enemy = CreateFly();

                AddFlyToSwarm(ref enemies, ref enemy); 
            }
        }
    }
}