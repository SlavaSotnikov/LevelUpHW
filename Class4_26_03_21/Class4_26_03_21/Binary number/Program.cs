using System;

namespace Binary_number
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter a decimal number: ");
            int decimalNumber = int.Parse(Console.ReadLine());
            
            string binaryNumber = string.Empty;
            int remainder;

            while (decimalNumber > 0)
            {
                remainder = decimalNumber % 2;
                decimalNumber /= 2;
                binaryNumber = remainder.ToString() + binaryNumber;
            }

            Console.WriteLine($"Binary number: {binaryNumber}");
            Console.ReadLine();
        }
    }
}
