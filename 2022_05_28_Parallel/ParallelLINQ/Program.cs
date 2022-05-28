using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelLINQ
{
    internal class Program
    {
        private static readonly Random _rnd = new Random();

        static void Main()
        {
            Stopwatch time = new Stopwatch();

            int[] array = new int[10000000];

            Parallel.For(0, array.Length, i => array[i] = i);

            array[_rnd.Next(0, array.Length)] = -1;
            array[_rnd.Next(0, array.Length)] = -2;
            array[_rnd.Next(0, array.Length)] = -3;
            array[_rnd.Next(0, array.Length)] = -4;
            array[_rnd.Next(0, array.Length)] = -5;
            array[_rnd.Next(0, array.Length)] = -6;

            time.Start();
            var pNegatives = array.AsParallel()
                                 .Where(element => element < 0)
                                 .OrderByDescending(element => element);

            time.Stop();
            Console.WriteLine($"Parallel query: {time.ElapsedMilliseconds}");

            time.Reset();
            time.Start();

            var negatives = array.Where(element => element < 0)
                                 .OrderByDescending(element => element);

            time.Stop();
            Console.WriteLine($"Query:  \t{time.ElapsedMilliseconds}");

            Parallel.ForEach(pNegatives, (element) => Console.Write($"{element} "));

            Console.WriteLine();
            foreach (var item in pNegatives)
            {
                Console.Write($"{item} ");
            }

            Console.ReadKey();
        }
    }
}
