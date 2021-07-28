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

        public static void Show(Line source)
        {
            Show(new Point(source.CoordinateX, source.CoordinateY));

            Show(new Point(source.Coordinate2X, source.Coordinate2Y));
        }

        public static void Show(Triangle source)
        {
            ConnectTwoPoints(new Point(source.CoordinateX, source.CoordinateY), new Point(source.Coordinate2X, source.Coordinate2Y));
            ConnectTwoPoints(new Point(source.CoordinateX, source.CoordinateY), new Point(source.Coordinate3X, source.Coordinate3Y));
            ConnectTwoPoints(new Point(source.Coordinate3X, source.Coordinate3Y), new Point(source.Coordinate2X, source.Coordinate2Y));
        }

        public static void Show(params Point[] source)
        {
            for (int i = 0; i < source.Length - 1; i++)
            {
                ConnectTwoPoints(source[i], source[i+1]);
            }
        }

        #endregion

        #region Bresenham's algorithms

        public static void ConnectTwoPoints(Point first, Point last)
        {
            int coordX = first.CoordinateX;
            int coordY = first.CoordinateY;
            int coordX2 = last.CoordinateX;
            int coordY2 = last.CoordinateY;

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

            int capacity = 20;
            //byte coef = 2;
            Point[] points = new Point[capacity];

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

                //if (_countOfPoints >= points.Length)
                //{
                //    Array.Resize(ref points, points.Length * coef);
                //}

                //points[_countOfPoints] = new Point(coordX, coordY);
                //++_countOfPoints;
            }

            //return points;
        }

        public static void ShowCircle(Circle source)
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
            //PrintPoint(coordX + x, coordY + y);
            //PrintPoint(coordX - x, coordY + y);
            //PrintPoint(coordX + x, coordY - y);
            //PrintPoint(coordX - x, coordY - y);
            //PrintPoint(coordX + y, coordY + x);
            //PrintPoint(coordX - y, coordY + x);
            //PrintPoint(coordX + y, coordY - x);
            //PrintPoint(coordX - y, coordY - x);
        }

        #endregion
    }
}
