using System;

namespace Sorter
{
    internal class UI
    {
        public static void ShowTime(string message, int time)
        {
            Console.WriteLine($"{message}: {time}");
        }

        public static void ShowIndexes(int i, int j)
        {
            Console.WriteLine($"{i} <=> {j}");
        }
    }
}
