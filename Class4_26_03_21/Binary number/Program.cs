using System;

namespace Binary_number
{
    class Program
    {
        static void GetBinaryNumber(int decimalNumber)
        {
            string binaryNumber = string.Empty;

            while (decimalNumber > 0)
            {
                int remainder = decimalNumber % 2;
                decimalNumber >>= 1;
                binaryNumber = remainder.ToString() + binaryNumber;
            }

            Console.WriteLine($"Binary number: {binaryNumber}");
        }
        static void Main()
        {
            Console.Write("Enter a decimal number: ");
            int decimalNumber = int.Parse(Console.ReadLine());

            GetBinaryNumber(decimalNumber);

            Console.ReadLine();
        }
    }
}
