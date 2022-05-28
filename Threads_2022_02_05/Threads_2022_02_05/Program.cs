using System;
using System.Diagnostics;
using System.Linq;

namespace Threads_2022_02_05
{
    internal class Program
    {
        private static readonly Random _rnd = new Random();

        static void Main()
        {
            Stopwatch time = new Stopwatch();

            using (Loger log = new Loger())
            {
                log.Write("Program started");

                DoubleThread dt = new DoubleThread(log);

                var source = _rnd.NextSet(10000).ToArray();

                time?.Start();
                log.Write($"Start sequence: {time.Elapsed.TotalMilliseconds}");

                dt.GetSelectionSort((int[])source.Clone());
                dt.GetSelectionSort((int[])source.Clone());

                log.Write($"Finish sequence: {time.Elapsed.TotalMilliseconds}");
                time.Restart();

                log.Write($"Parallel Start: {time.Elapsed.TotalMilliseconds}");

                dt.ParallelSort(source, source);

                time.Stop();

                log.Write($"Parallel Stop: {time.Elapsed.TotalMilliseconds}");

                Console.WriteLine("Finish Main Thread");
                Console.ReadKey();
            } 
        }
    }
}
