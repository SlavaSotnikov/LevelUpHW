using System;

namespace GeometricShapes
{
    class UI
    {
        public static void PrintPoint(int coordinateX, int coordinateY)
        {
            Console.CursorVisible = false;

            Console.SetCursorPosition(coordinateX, coordinateY);
            Console.WriteLine("*");
        }

        public static void ShowPoint(Point source)
        {
            PrintPoint(source.CoordinateX, source.CoordinateY);
        }

        public static void ShowLine(Line source)
        {
            PrintLine(source.CoordinateX, source.CoordinateY,
                    source.CoordinatePoint2X, source.CoordinatePoint2Y);
        }

        public static void ShowTriangle(Triangle source)
        {
            PrintLine(source.CoordinateX, source.CoordinateY,
                    source.CoordinatePoint3X, source.CoordinatePoint3Y);

            PrintLine(source.CoordinateX, source.CoordinateY,
                    source.CoordinatePoint2X, source.CoordinatePoint2Y);

            PrintLine(source.CoordinatePoint3X, source.CoordinatePoint3Y,
                    source.CoordinatePoint2X, source.CoordinatePoint2Y);
        }

        public static void PrintLine(int coordinateX, int coordinateY,
                int coordinateX2, int coordinateY2)
        {
            int w = coordinateX2 - coordinateX;
            int h = coordinateY2 - coordinateY;

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
            } else if (w > 0)
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
                numerator += shortest;

                if (!(numerator < longest))
                {
                    numerator -= longest;
                    coordinateX += dx1;
                    coordinateY += dy1;
                }
                else
                {
                    coordinateX += dx2;
                    coordinateY += dy2;
                }

                PrintPoint(coordinateX, coordinateY);
            }
        }
    }
}
