using System;

namespace GeometricShapes
{
    class UI
    {
        #region Show Data

        public static void PrintPoint(int coordX, int coordY, char symbol = '*', ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(coordX, coordY);
            Console.Write(symbol);
        }

        #endregion

        public static void Show(params Coordinate[] source)
        {
            Console.CursorVisible = false;

            if (source[0].Radius > 0)
            {
                DrawCircle(source);
            }

            if (source.Length == 1)
            {
                PrintPoint(source[0].X, source[0].Y);
                return;
            }

            for (int i = 0; i < source.Length - 1; i++)
            {
                ConnectTwoPoints(source[i], source[i + 1]);
            }
        }

        #region Bresenham's algorithms

        public static void ConnectTwoPoints(Coordinate first, Coordinate second)
        {
            int coordX = first.X;
            int coordY = first.Y;
            int coordX2 = second.X;
            int coordY2 = second.Y;

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
                PrintPoint(coordX, coordY);

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

        public static void DrawCircle(params Coordinate[] source)
        {
            int x = 0;
            int y = source[0].Radius;
            int d = 3 - 2 * source[0].Radius;

            DrawCircle(source[0].X, source[0].Y, x, y);

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

                DrawCircle(source[0].X, source[0].Y, x, y);
            }
        }

        private static void DrawCircle(int coordX, int coordY, int x, int y)
        {
            PrintPoint(coordX + x, coordY + y);
            PrintPoint(coordX - x, coordY + y);
            PrintPoint(coordX + x, coordY - y);
            PrintPoint(coordX - x, coordY - y);
            PrintPoint(coordX + y, coordY + x);
            PrintPoint(coordX - y, coordY + x);
            PrintPoint(coordX + y, coordY - x);
            PrintPoint(coordX - y, coordY - x);
        }

        #endregion
    }
}
