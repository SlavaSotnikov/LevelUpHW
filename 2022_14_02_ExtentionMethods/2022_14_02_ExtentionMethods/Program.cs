using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_14_02_ExtentionMethods
{
    internal class Program
    {
        static void Main()
        {
            int[] source = { 2, 5, 100, -10};

            TestLinqMode(source);

            Console.ReadKey();
        }

        private static void TestLinqMode(IEnumerable<int> source)
        {
            List<int> result = (from number in source 
                                      where number > 0
                                      select number).ToList();


            //foreach (var VARIABLE in result)
            //{
            //    Console.Write("{0} ", VARIABLE);
            //}

            //Console.WriteLine();
            //Console.WriteLine("Min of source: {0}", source.Min());
            //Console.WriteLine("Max of source: {0}", source.Max());
            //Console.WriteLine("Average of source: {0}", source.Average());
            //Console.WriteLine("Count of source: {0}", source.Count(n=>n>0));

            //if (source.All(n=> n >= -100 && n <= 100))
            //{
            //    Console.WriteLine("All source items in [{0},{1}]", -100, 100);
            //}

            //if (source.All(n => n >= -10 && n <= 10))
            //{
            //    Console.WriteLine("All source items in [{0},{1}]", -100, 100);
            //}

            //if (source.Any(n => n < -1))
            //{
            //    Console.WriteLine("Contains less then 1000");
            //}

            //int[] source2 = {2, 4, 6, 8};

            //IEnumerable<int> containsResult = source.Concat(source2);

            //foreach (var VARIABLE in containsResult)
            //{
            //    Console.Write("{0} ",VARIABLE);
            //}

            int[] source3 = {2, 4, 6, 8};

            IEnumerable<int> item1 = source3.DefaultIfEmpty(-1);

            foreach (var VARIABLE in item1)
            {
                Console.WriteLine("{0}", VARIABLE);
            }
        }
    }
}
