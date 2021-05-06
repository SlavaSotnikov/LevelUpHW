using System;

namespace Overloading
{
    class Program
    {
        static int GetSum(int a, int b)
        {
            return a + b;
        }

        static int GetSum(int a, int b, int c)
        {
            return GetSum(GetSum(a, b), c);
        }

        static int GetSum(int a, int b, int c, int d)
        {
            return GetSum(GetSum(a, b), c, d);
        }

        static int GetSum(int a, int b, int c, int d, int e)
        {
            return GetSum(GetSum(a, b), c, d, e);
        }
        static void Main()
        {
            Console.WriteLine(GetSum(2, 5, 2, 2, 2));
            Console.ReadKey();
        }
    }
}
