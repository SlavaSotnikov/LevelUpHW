using System;

namespace Task3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please, enter five numbers: ");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double d = double.Parse(Console.ReadLine());
            double e = double.Parse(Console.ReadLine());

            if (a > b)
                b = a;
            if (b > c)
                c = b;
            if (c > d)
                d = c;
            if (d > e)
                e = d;

            Console.WriteLine($"The biggest number is: {e}");

            if (a < b)
                b = a;
            if (b < c)
                c = b;
            if (c < d)
                d = c;
            if (d < e)
                e = d;

            Console.WriteLine($"The lower number is: {e}");
            Console.ReadLine();

            
            //For starters sort, than first is a lower number, and the last is the biggest one.
            
        }
    }
}
