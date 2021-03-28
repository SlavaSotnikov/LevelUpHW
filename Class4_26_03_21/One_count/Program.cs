using System;


namespace One_count
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter a decimal number: ");
            int yourNumber = int.Parse(Console.ReadLine());

            int decimalNumber = yourNumber;
            string binaryNumber = string.Empty;

            int count0 = 0;
            int count1 = 0;

            while (decimalNumber > 0)
            {
                if ((decimalNumber & 1) == 0)
                {
                    int remainder = decimalNumber % 2;
                    decimalNumber /= 2;
                    count0++;
                }
                else
                {
                    int remainder = decimalNumber % 2;
                    decimalNumber /= 2;
                    count1++;
                }                
            }

            Console.WriteLine($"Number {decimalNumber} contains {count0} zeros and {count1} units.");
            Console.ReadLine();
        }
    }
}
