using System;
using static System.Console;

namespace SumOfNumbers_Overloading
{
    class Program
    {
        static int GetSum(int num1, int num2, int num3=0, int num4=0, int num5=0,
                      int num6=0, int num7=0, int num8=0, int num9=0, int num10=0)
        {
            return num1 + num2 + num3 + num4 + num5 + num6 + num7 + num8 + num9 + num10;
        }

        static void Main()
        {
            WriteLine(GetSum(5, 6, 5, 5));
            ReadKey();
        }
    }
}
