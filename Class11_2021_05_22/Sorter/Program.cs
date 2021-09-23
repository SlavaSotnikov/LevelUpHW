using System;

namespace Sorter
{
    internal class Program
    {
        static void Main()
        {
            //InsertionSort s = new InsertionSort(9, 2, 4, 5, 1, 6, 7, 3, 8);

            SelectionSort s = new SelectionSort(8, 3, 7, 5, 1, 6, 4, 2, 9);

             
            for (int i = 0; i < s.Sort.Length; i++)
            {
                Console.Write("{0} ", s.Sort[i]);
            }

            Console.ReadKey();
        }
    }
}
