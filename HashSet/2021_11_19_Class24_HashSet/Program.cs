using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _2021_11_19_Class24_HashSet
{
    internal class Program
    {
        static void Main()
        {
            HashSet<Coordinate> rect1 = new HashSet<Coordinate>(new CoordinateEqualityComparer());
            HashSet<Coordinate> rect2 = new HashSet<Coordinate>(new CoordinateEqualityComparer());
            HashSet<Coordinate> rectResult1 = new HashSet<Coordinate>(new CoordinateEqualityComparer());

            TestISet(rect1, rect2, rectResult1, "HashSet");

            SortedSet<Coordinate> rect3 = new SortedSet<Coordinate>(new CoordinateComparer());
            SortedSet<Coordinate> rect4 = new SortedSet<Coordinate>(new CoordinateComparer());
            SortedSet<Coordinate> rectResult2 = new SortedSet<Coordinate>(new CoordinateComparer());

            TestISet(rect3, rect4, rectResult2, "SortedSet");

            Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.Blue;
            Show(rect1);

            Console.ForegroundColor = ConsoleColor.Green;
            Show(rect2);

            Console.ForegroundColor = ConsoleColor.Red;
            Show(rectResult1);

            Console.ReadKey();
        }

        private static void TestISet(ISet<Coordinate> rect1, ISet<Coordinate> rect2, ISet<Coordinate> rectResult, string nameOfStruct)
        {
            Console.Write("{0,10} ", nameOfStruct);
            GenerateCoordOfRectangle(1, 1, 11 * 100, 11 * 100, rect1);
            Console.Write("{0,10} ", nameOfStruct);
            GenerateCoordOfRectangle(6 * 100, 1, 16 * 100, 11 * 100, rect2);
            //Console.Write("  {0,10} ", nameOfStruct);
            GetCommonArea(rect1, rect2, rectResult);
        }

        private static void Show(ISet<Coordinate> set)
        {
            foreach (Coordinate item in set)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write('*');
            }
        }

        private static void GetCommonArea(ISet<Coordinate> source1, ISet<Coordinate> source2, ISet<Coordinate> destination)
        {
            Stopwatch timer = new Stopwatch();

            timer.Start();

            destination.Clear();

            destination.UnionWith(source1);
            destination.SymmetricExceptWith(source2);

            timer.Stop();

            Console.WriteLine("SymmetricExcept:{0}", timer.ElapsedMilliseconds);
        }

        public static void GenerateCoordOfRectangle(int x1, int y1, int x2, int y2, ISet<Coordinate> destination)
        {
            Stopwatch timer = new Stopwatch();

            timer.Start();

            for (int x = x1; x < x2; x++)
            {
                for (int y = y1; y < y2; y++)
                {
                    destination.Add(new Coordinate(x, y));
                }
            }

            timer.Stop();

            Console.WriteLine("Add: {0}", timer.ElapsedMilliseconds);
        }
    }
}
