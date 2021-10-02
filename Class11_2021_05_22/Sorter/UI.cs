using System;

namespace Sorter
{
    internal class UI
    {
        public static void ShowTime(int time)
        {
            Console.WriteLine($"{time}");
        }

        public static void ShowSwapIndexes(int i, int j)
        {
            Console.WriteLine($"{i} <=> {j}");
        }

        public static void ShowIndexes(int i, int j)
        {
            Console.WriteLine($"{i} - {j}");
        }
    }
}
