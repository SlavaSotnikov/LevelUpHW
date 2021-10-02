using System;

namespace Sorter
{
    internal class UI
    {
        public static void ShowTime(object sender, TimeEventArgs e)
        {
            Console.WriteLine($"{e.Text}: {e.Time}");
        }

        public static void ShowSwapIndexes(object sender, IndexEventArgs e)
        {
            Console.WriteLine($"{e.Index1} <=> {e.Index2}");
        }

        public static void ShowIndexes(object sender, IndexEventArgs e)
        {
            Console.WriteLine($"{e.Index1} - {e.Index2}");
        }
    }
}
