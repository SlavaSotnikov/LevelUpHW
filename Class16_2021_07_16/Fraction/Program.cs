using System;

namespace Fraction
{
    class Program
    {
        static void Main()
        {
            Fraction one = new Fraction(0.25);

            Console.WriteLine("User Fraction: {0}", one);
            one.GetNormalize();
            Console.WriteLine("Normalize Fraction: {0}", one);

            

            Console.ReadKey();
        }
    }
}
