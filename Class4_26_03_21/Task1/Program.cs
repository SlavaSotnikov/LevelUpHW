using System;

namespace Even_Odd_Numbers
{
    class Program
    {
        static bool GetEvenOddNumber(byte decimalNumber)
        {
            if ((decimalNumber & 1) == 0)
            {
                return true; 
            }
            else
            {
                return false;
            }
        }
        static void Main()
        {
            Console.Write("Enter a value: ");
            byte decimalNumber = byte.Parse(Console.ReadLine());

            bool res = GetEvenOddNumber(decimalNumber);

            switch (res)
            {
                case true:
                    Console.WriteLine($"{decimalNumber} - is even number."); break;
                case false:
                    Console.WriteLine($"{decimalNumber} - is odd number."); break;
                default:
                    break;
            }

            Console.ReadLine();
        }
    }
}
