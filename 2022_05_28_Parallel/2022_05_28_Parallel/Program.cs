using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_05_28_Parallel
{
    internal class Program
    {
        static void Main()
        {
            object[] data = new object[10000000];
            //int[] intData = new int[100000000];

            Stopwatch timer = new Stopwatch();

            timer.Start();

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;
            }

            //for (int i = 0; i < intData.Length; i++)
            //{
            //    intData[i] = (int)data[i];
            //}

            timer.Stop();
            Console.WriteLine($"For: \t\t{timer.Elapsed.TotalSeconds}");
            timer.Reset();

            Action<int> transform = (int i) => data[i] = i;
            //Action<int> intTransform = (int i) => intData[i] = (int)data[i];

            timer.Start();

            ParallelLoopResult result = Parallel.For(0, data.Length, transform);
            
            //Parallel.For(0, data.Length, intTransform);

            timer.Stop();
            Console.WriteLine($"Parallel.For:   {timer.Elapsed.TotalSeconds}");
            Console.ReadKey();
        }
    }
}
