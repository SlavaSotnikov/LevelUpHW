using System;


namespace One_count
{
    class Program
    {
        static int GetShift(int decimalNumber)
        {
            return decimalNumber >>= 1;
        }
        static int GetBinaryNumber(int yourNumber, ref int units)
        {
            int decimalNumber = yourNumber;

            int zeros = 0;

            while (decimalNumber > 0)
            {
                if ((decimalNumber & 0x00000001) == 0)
                {
                    decimalNumber = GetShift(decimalNumber);
                    zeros++;
                }
                else
                {
                    decimalNumber = GetShift(decimalNumber);
                    units++;
                }
            }

            return zeros;
        }
        static void Main()
        {
            int units = 0;

            Console.Write("Enter a decimal number: ");
            int yourNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Number {0} contains {1} zeros and {2} units.", 
                yourNumber, GetBinaryNumber(yourNumber, ref units), units );

            Console.ReadLine();
        }
    }
}
