using System;

namespace Sum_Of_Range
{
    class Program
    {
        // FOR
        static int GetSum(int num1, int num2)
        {
            if (num1 == num2)
            {
                return 0;
            }
            else if (num1 < num2)
            {
                int res = 0;
                for (int i = num1; i <= num2; i++)
                {
                    res += i;
                }

                return res;
            }
            else
            {
                int res = 0;
                for (int i = num1; i >= num2; i--)
                {
                    res += i;
                }

                return res;
            }
        }

        // Recursion
        static int GetSumRange(int num1, int num2)
        {
            if (num1 == num2)
            {
                return num1;
            }
            if (num1 <= num2)
            {
                return num2 + GetSumRange(num1, num2 - 1);
            }
            else
            {
                return num2 + GetSumRange(num1, num2 + 1);
            }
        }

        static void Main()
        {
            int num1 = 5;
            int num2 = 1;


            Console.WriteLine("Recursion sum: {0} ", GetSumRange(num1, num2));
            Console.WriteLine("Cycle sum:   {0} ", GetSum(num1, num2));
            Console.ReadKey();
        }
    }
}
