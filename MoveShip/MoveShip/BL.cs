using System;

namespace MoveShip
{
    class BL
    {
        public static char bulletLeft = '║';
        public static char bulletRight = '║';

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
                     Shot leftBullet = CreateLeftShot(ship);
                    Shot rightBullet = CreateRightShot(ship);
                    AddShotToGun(ref shipMag, leftBullet, rightBullet);
                    break;

                default:
                    break;
            }
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
                methodCounter = 0
            };

            return clip;
        }

        public static void AddShotToGun(ref Cartridge source, Shot left, Shot right)
        {
            if (source.countOfShots >= source.mag.Length)
            {
                Array.Resize(ref source.mag, source.mag.Length + 8);
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
                coordinateY = ship.сoordinateY,
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
                coordinateY = ship.сoordinateY,
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

        public static void ModifyRightBulletCoordinate(ref Right bullet)
        {
            bullet.coordinateY -= STEP;
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
    }
}
