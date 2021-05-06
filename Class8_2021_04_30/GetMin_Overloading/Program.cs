using System;
using static System.Console;

namespace GetMin_Overloading
{
    class Program
    {
        static int CheckMin(int a, int b)
        {
            if (a < b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        static int CheckMin(int a, int b, int c)
        {
            return CheckMin(CheckMin(a, b), c);
        }

        static int CheckMin(int a, int b, int c, int d)
        {
            return CheckMin(CheckMin(a, b), c, d);
        }

        static int GetMin(int num1, int num2, int num3=0, int num4=0, int num5=0)
        {
            if (num1 < num2) { num2 = num1; }
            if (num2 < num3) { num3 = num2; }
            if (num3 < num4) { num4 = num3; }
            if (num4 < num5) { num5 = num4; }

            int min = num5;

            return min;
        }
        static void Main()
        {
            WriteLine(GetMin(0, -3, 4));

            WriteLine(GetMin(2, 3, num5: 1));
            ReadKey();
        }
    }

    // In my view It's impossible because int is 0 by default.
}
