using System;

namespace Generators
{
    class Program
    {
        static void Main()
        {
            Fibonacci numbers = new Fibonacci(12, 100);        

            foreach (var item in numbers.GetSequence())
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine();

            Prime number = new Prime(3, 10);

            foreach (var item in number.GetSequence())
            {
                Console.Write("{0} ", item);
            }

            Console.ReadKey();
        }
    }
}
