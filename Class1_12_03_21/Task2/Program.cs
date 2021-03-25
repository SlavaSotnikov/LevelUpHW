using System;

namespace Task2
{
    class Program
    {
        static void Main()
        {
            int a, b, c;

            a = 1;
            b = 2;
            c = 3;

            Console.WriteLine($"a = {a}, b = {b}, c = {c}");

            a = c + a;
            c = a - c; 
            a = a - c;

            b = b + c;
            c = b - c;
            b = b - c;

            Console.WriteLine($"a = {a}, b = {b}, c = {c}");

            a = 1;
            b = 2;
            c = 3;

            (a, b, c) = (c, a, b);

            Console.WriteLine($"a = {a}, b = {b}, c = {c}");
            Console.ReadLine();
        }
    }
}
