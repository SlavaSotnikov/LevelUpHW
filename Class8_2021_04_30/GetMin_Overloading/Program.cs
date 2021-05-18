using System;

namespace GetMin_Overloading
{
    class Program
    {
        static int GetMin(int a, int b)
        {
            int min = 0;

            if (a < b)
            {
                min = a;
            }
            else
            {
                min = b;
            }

            return min;
        }

        static int CheckMin(int a, int b, int c)
        {
            return GetMin(GetMin(a, b), c);
        }

        static int CheckMin(int a, int b, int c, int d)
        {
            return CheckMin(GetMin(a, b), c, d);
        }

        static int GetMin(int num1, int num2, int num3=int.MaxValue,
                           int num4=int.MaxValue, int num5=int.MaxValue)
        {
            if (num1 < num2) 
            { 
                num2 = num1; 
            }

            if (num2 < num3) 
            { 
                num3 = num2;
            }

            if (num3 < num4) 
            { 
                num4 = num3;
            }

            if (num4 < num5)
            { 
                num5 = num4;
            }

            int min = num5;

            return min;
        }

        static void Main()
        {
            Console.WriteLine(GetMin(0, -3, 4));

            Console.WriteLine(GetMin(2, 3, num5: 1));

            Console.ReadKey();
        }
    }
}
