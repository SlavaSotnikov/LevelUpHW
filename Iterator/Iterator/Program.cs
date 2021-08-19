using System;
using System.Collections;

namespace Iterator
{
    class Program
    {
        static void Main()
        {
            double[] src = new double[] { 2.0, -2.1, 4.2, 5.0, 7.4, 6.4, 7.2 };

            DoubleContainer dc1 = new DoubleContainer(src);

            IEnumerator iter = dc1.GetEnumerator();

            while (iter.MoveNext())
            {
                Console.Write("{0} ", iter.Current);
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in dc1)
            {
                Console.Write("{0} ", item);
            }

            Console.ReadKey();
        }
    }
}
