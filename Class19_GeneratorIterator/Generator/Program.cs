using System;
using System.Collections;

namespace Generator
{
    class Program
    {
        static void Main()
        {
            Fibonacci numbers = new Fibonacci(1, 10);

            IEnumerator fib = numbers.GetEnumerator();
            while (fib.MoveNext())
            {
                Console.Write("{0} ", fib.Current);
            }


            Prime num = new Prime(8, 20);
            foreach (var item in num)
            {
                Console.Write("{0} ", item);
            }

            Console.ReadKey();
        }
    }
}
