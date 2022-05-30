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

            Stopwatch timer = new Stopwatch();

            timer.Start();
            test.TestDictionary(new Dictionary<string, int>(), iterations);
            timer.Stop();

            long res1 = timer.ElapsedMilliseconds;

            timer.Restart();
            test.TestDictionary(new SortedDictionary<string, int>(), iterations);
            timer.Stop();

            long res2 = timer.ElapsedMilliseconds;

            timer.Restart();
            test.TestDictionary(new SortedList<string, int>(), iterations);
            timer.Stop();

            long res3 = timer.ElapsedMilliseconds;

            timer.Restart();
            test.TestHashTable(new Hashtable(), iterations);
            timer.Stop();

            long res4 = timer.ElapsedMilliseconds;

            Console.WriteLine($" Dictionary: {res1, -2} ms,\n Hashtable:  {res4, -2} ms,\n " +
                $"SList:\t     {res3, -2} ms,\n SDitionary: {res2, -2} ms");

            Console.ReadKey();
        }
    }
}
