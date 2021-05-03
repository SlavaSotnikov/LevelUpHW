using System;

namespace Binary_number
{
    class Program
    {
        static string GetBinaryNumber(int decimalNumber)
        {
            string binaryNumber = string.Empty;

            while (decimalNumber > 0)
            {
                int remainder = decimalNumber % 2;
                decimalNumber >>= 1;
                binaryNumber = remainder.ToString() + binaryNumber;
            }

            return binaryNumber;
        }
        static void Main()
        {
            Console.Write("Enter a decimal number: ");
            int decimalNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(GetBinaryNumber(decimalNumber));

            Console.ReadLine();
        }
    }
}
