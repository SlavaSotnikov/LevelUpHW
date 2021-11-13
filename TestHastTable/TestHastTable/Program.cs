using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace TestHastTable
{
    internal class Program
    {
        static void Main()
        {
            Test test = new Test();

            int iterations = 10000;

            var timer = new Stopwatch();

            timer.Start();
            test.TestDictionary(new Dictionary<string, int>(), iterations);
            timer.Stop();

            long res1 = timer.ElapsedTicks;

            timer.Start();
            test.TestDictionary(new SortedDictionary<string, int>(), iterations);
            timer.Stop();

            long res2 = timer.ElapsedTicks;

            timer.Start();
            test.TestDictionary(new SortedList<string, int>(), iterations);
            timer.Stop();

            long res3 = timer.ElapsedTicks;

            timer.Start();
            test.TestHashTable(new Hashtable(), iterations);
            timer.Stop();

            long res4 = timer.ElapsedTicks;

            Console.WriteLine($" Dictionary: {res1, -6} t,\n Hashtable:  {res4, -6} t,\n " +
                $"SList:\t     {res3, -6} t,\n SDitionary: {res2, -6} t");
            Console.ReadKey();
        }
    }
}
