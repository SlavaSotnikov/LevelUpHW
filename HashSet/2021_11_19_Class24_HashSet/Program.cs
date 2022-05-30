﻿using System;
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

            //SortedSet<Coordinate> rect3 = new SortedSet<Coordinate>(new CoordinateComparer());
            //SortedSet<Coordinate> rect4 = new SortedSet<Coordinate>(new CoordinateComparer());
            //SortedSet<Coordinate> rectResult2 = new SortedSet<Coordinate>(new CoordinateComparer());

            //TestISet(rect3, rect4, rectResult2, "SortedSet");

            //Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.Blue;
            Show(rect1);

            Console.ForegroundColor = ConsoleColor.Green;
            Show(rect2);

            //Console.ForegroundColor = ConsoleColor.Red;
            //Show(rectResult1);

            Console.ReadKey();
        }

        private static void TestISet(ISet<Coordinate> rect1, ISet<Coordinate> rect2, ISet<Coordinate> rectResult, string nameOfStruct)
        {
            GenerateCoordOfPoint(5, 5, rect1);
            GenerateCoordOfPoint(6, 5, rect2);

            //Console.Write("{0,10} ", nameOfStruct);
            //GenerateCoordOfRectangle(9, 1, 11, 2, rect1);
            //Console.Write("{0,10} ", nameOfStruct);
            //GenerateCoordOfRectangle(9, 1, 10, 2, rect2);
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
            destination.Clear();

            foreach (var item in source1)
            {
                ++item.X;
            }

            //foreach (Coordinate item in source2)
            //{
            //    ++item.X;
            //}

            destination.UnionWith(source1);
            //foreach (var item in source2)
            //{
            //    ++item.X;
            //}
            
            bool overlaps = destination.SetEquals(source2);
        }

        public static void GenerateCoordOfRectangle(int x1, int y1, int x2, int y2, ISet<Coordinate> destination)
        {
            for (int x = x1; x < x2; x++)
            {
                for (int y = y1; y < y2; y++)
                {
                    destination.Add(new Coordinate(x, y));
                }
            }
        }

        public static void GenerateCoordOfPoint(int x, int y, ISet<Coordinate> destination)
        {
            destination.Add(new Coordinate(x, y));
        }
    }
}