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
            //SpeedAnalizer speed = new SpeedAnalizer();

            Selection selectionSorter = new Selection(8, 3, 7, 5, 1, 6, 4, 2, 9);

            selectionSorter.StartSort += (sender, e) => 
            Console.WriteLine($"{e.Text}: {e.Time}");

            selectionSorter.FinishSort += (sender, e) => 
            Console.WriteLine($"{e.Text}: {e.Time}"); 

            selectionSorter.StartSort += time.SetStart;
            selectionSorter.FinishSort += time.SetFinish;

            selectionSorter.CompareIndexes += (sender, e) => 
            Console.WriteLine($"{e.Index1} - {e.Index2}");

            selectionSorter.SwapIndexes += (sender, e) => 
            Console.WriteLine($"{e.Index1} <=> {e.Index2}");

            int compare = 0;
            selectionSorter.CompareIndexes += delegate(object sender, IndexEventArgs e) 
            {
                ++compare; 
            };

            int swaps = 0;
            selectionSorter.SwapIndexes += (sender, e) => ++swaps;

            double[] result = selectionSorter.Do();

            for (int i = 0; i < result.Length; i++)
            {
                Console.Write("{0} ", result[i]);
            }

            Console.WriteLine("\nTotal time: {0}", time.Total);
            Console.WriteLine("\nTotal Compares: {0}, Swaps {1}", compare, swaps);

            Console.ReadKey();
        }
    }
}
