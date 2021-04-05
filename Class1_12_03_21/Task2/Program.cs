using System;

namespace Task2
{
    class Program
    {
        static void Swap(ref int a, ref int b, ref int c)
        {
            a = c + a;
            c = a - c;
            a = a - c;

            b = b + c;
            c = b - c;
            b = b - c;
        }

        static void Swap1(ref int a, ref int b, ref int c)
        {
            (a, b, c) = (c, a, b);
        }
        static void Main()
        {
            int a = 1;
            int b = 2;
            int c = 3;            

            Console.WriteLine($"a = {a}, b = {b}, c = {c}");

            Swap(ref a, ref b, ref c);

            Console.WriteLine($"a = {a}, b = {b}, c = {c}");

            Swap1(ref a, ref b, ref c);

            Console.WriteLine($"a = {a}, b = {b}, c = {c}");
            Console.ReadLine();
        }
    }
}
