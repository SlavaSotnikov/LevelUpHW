using System;
using static System.Console;

namespace GetMin_Overloading
{
    class Program
    {
        static int GetMin(int num1, int num2, int num3, int num4, int num5)
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
            WriteLine(GetMin(0, -6, 7, 9, 1));
            ReadKey();
        }
    }

    // In my view It's impossible because default for int is 0.
}
