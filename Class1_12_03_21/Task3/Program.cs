using System;

namespace Task3
{
    class Program
    {
        static void GetMaxMinNumber(double a, double b, double c, double d, double e, ref double max, ref double min)
        {            
            if (a > b)
            {
                max = a;
                min = b;
            }
            else
            {
                max = b;
                min = a;
            }                
            if (b > max) { max = b; }
                
            if (b < min) { min = b; }
                                
            if (c > max) { max = c; }
                
            if (c < min) { min = c; }
                
            if (d > max) { max = d; }
                
            if (d < min) { min = d; }
                
            if (e > max) { max = e; }
                
            if (e < min) { min = e; }                
        }

        static void Main()
        {
            Console.WriteLine("Please, enter five numbers: ");

            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double d = double.Parse(Console.ReadLine());
            double e = double.Parse(Console.ReadLine());


            double max = 0;
            double min = 0;

            GetMaxMinNumber(a, b, c, d, e, ref max, ref min);

            Console.WriteLine($"The max number is: {max}, the min: {min}");

            Console.ReadLine();

            
            //For starters sort, than first is a lower number, and the last is the biggest one.
            
        }
    }
}
