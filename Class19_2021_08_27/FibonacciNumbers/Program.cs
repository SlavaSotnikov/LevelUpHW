using System;

namespace FibonacciNumbers
{
    class Program
    {
        static void Main()
        {
            Fibonacci numbers = new Fibonacci(20, 1000);

            foreach (var item in numbers)
            {
                Console.Write("{0} ", item);
            }

            Console.ReadKey();
        }
    }
}
