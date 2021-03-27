using System;

namespace Even_Odd_Numbers
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter a value: ");
            byte decimalNumber = byte.Parse(Console.ReadLine());

            if ((decimalNumber & 1) == 0)
            {
                Console.WriteLine($"{decimalNumber} - is even number.");
            }
            else
            {
                Console.WriteLine($"{decimalNumber} - is odd number.");
            }

            Console.ReadLine();
        }
    }
}
