using System;


namespace One_count
{
    class Program
    {
        static int GetShift(int decimalNumber)
        {
            return decimalNumber >>= 1;
        }
        static void GetBinaryNumber(int yourNumber)
        {
            int decimalNumber = yourNumber;

            int count0 = 0;
            int count1 = 0;

            while (decimalNumber > 0)
            {
                if ((decimalNumber & 0x00000001) == 0)
                {
                    decimalNumber = GetShift(decimalNumber);
                    count0++;
                }
                else
                {
                    decimalNumber = GetShift(decimalNumber);
                    count1++;
                }
            }

            Console.WriteLine($"Number {yourNumber} contains {count0} zeros and {count1} units.");
        }
        static void Main()
        {
            Console.Write("Enter a decimal number: ");
            int yourNumber = int.Parse(Console.ReadLine());

            GetBinaryNumber(yourNumber);

            Console.ReadLine();
        }
    }
}
