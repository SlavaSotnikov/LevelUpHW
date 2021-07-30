using System;

namespace GeometricShapes
{
    class UI
    {


        #region Show Data

        public static void Show(Point source)
        {
            Console.CursorVisible = false;

            Console.SetCursorPosition(source.CoordinateX, source.CoordinateY);
            Console.WriteLine("*");
        }

        public static void Show(params Point[] source)
        {
            for (int i = 0; i < source.Length - 1; i++)
            {
                ConnectTwoPoints(source[i], source[i + 1]);
            }
        }

        #endregion

        #region Bresenham's algorithms

        public static void ConnectTwoPoints(Point first, Point second)
        {
            int coordX = first.CoordinateX;
            int coordY = first.CoordinateY;
            int coordX2 = second.CoordinateX;
            int coordY2 = second.CoordinateY;

            int w = coordX2 - coordX;
            int h = coordY2 - coordY;

            int dx1 = 0;
            int dy1 = 0;
            int dx2 = 0;
            int dy2 = 0;

            if (w < 0)
            {
                dx1 = -1;
            }
            else if (w > 0)
            {
                dx1 = 1;
            }

            if (h < 0)
            {
                dy1 = -1;
            }
            else if (h > 0)
            {
                dy1 = 1;
            }

            if (w < 0)
            {
                dx2 = -1;
            }
            else if (w > 0)
            {
                dx2 = 1;
            }

            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);

            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);

                if (h < 0)
                {
                    dy2 = -1;
                }
                else if (h > 0)
                {
                    dy2 = 1;
                }

                dx2 = 0;
            }

            int numerator = longest >> 1;

            for (int i = 0; i <= longest; i++)
            {
                Show(new Point(coordX, coordY));

                numerator += shortest;

                if (!(numerator < longest))
                {
                    numerator -= longest;
                    coordX += dx1;
                    coordY += dy1;
                }
                else
                {
                    coordX += dx2;
                    coordY += dy2;
                }
            }
        }

        public static void DrawCircle(Circle source)
        {
            int x = 0;
            int y = source.Radius;
            int d = 3 - 2 * source.Radius;

            DrawCircle(source.CoordinateX, source.CoordinateY, x, y);

            while (y >= x)
            {
                x++;

                if (d > 0)
                {
                    y--;
                    d = d + 4 * (x - y) + 10;
                }
                else
                {
                    d = d + 4 * x + 6;
                }

                DrawCircle(source.CoordinateX, source.CoordinateY, x, y);
            }
        }

        private static void DrawCircle(int coordX, int coordY, int x, int y)
        {
            Show(new Point(coordX + x, coordY + y));
            Show(new Point(coordX - x, coordY + y));
            Show(new Point(coordX + x, coordY - y));
            Show(new Point(coordX - x, coordY - y));
            Show(new Point(coordX + y, coordY + x));
            Show(new Point(coordX - y, coordY + x));
            Show(new Point(coordX + y, coordY - x));
            Show(new Point(coordX - y, coordY - x));
        }

        #endregion
    }
}
