using System;

namespace Sorter
{
    internal class Program
    {
        static void Main()
        {
            //Insertion sort = new Insertion(9, 2, 4, 5, 1, 6, 7, 3, 8)
            //{
            //    TimeMeasure = UI.ShowTime,
            //    SwapIndexes = UI.ShowIndexes
            //};

            Selection sort = new Selection(8, 3, 7, 5, 1, 6, 4, 2, 9)
            {
                TimeMeasure = UI.ShowTime,
                SwapIndexes = UI.ShowIndexes
            };

            double[] result = sort.SortedArray;

            for (int i = 0; i < result.Length; i++)
            {
                Console.Write("{0} ", result[i]);
            }

            Console.ReadKey();
        }
    }
}
