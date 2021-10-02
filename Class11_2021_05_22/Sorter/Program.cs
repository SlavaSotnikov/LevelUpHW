using System;

namespace Sorter
{
    internal class Program
    {
        static void Main()
        {
            //Insertion insertionSorter = new Insertion(9, 2, 4, 5, 1, 6, 7, 3, 8)
            //{
            //    TimeMeasure = UI.ShowTime,
            //    SwapIndexes = UI.ShowIndexes
            //};

            TimeAnalizer time = new TimeAnalizer();
            SpeedAnalizer speed = new SpeedAnalizer();

            Selection selectionSorter = new Selection(8, 3, 7, 5, 1, 6, 4, 2, 9);

            selectionSorter.StartSort += UI.ShowTime;
            selectionSorter.FinishSort += UI.ShowTime;
            selectionSorter.StartSort += time.SetStart;
            selectionSorter.FinishSort += time.SetFinish;

            selectionSorter.CompareIndexes += UI.ShowIndexes;
            selectionSorter.SwapIndexes += UI.ShowSwapIndexes;
            selectionSorter.CompareIndexes += speed.CountCompare;
            selectionSorter.SwapIndexes += speed.CountSwaps;

            double[] result = selectionSorter.Do();

            for (int i = 0; i < result.Length; i++)
            {
                Console.Write("{0} ", result[i]);
            }

            Console.WriteLine("\nTotal time: {0}", time.Total);
            Console.WriteLine("\nTotal Compares: {0}, Swaps {1}", speed.Compare, speed.Swaps);

            Console.ReadKey();
        }
    }
}
