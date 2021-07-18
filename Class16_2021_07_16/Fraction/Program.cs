using System;

namespace Fraction
{
    class Program
    {
        static void Main()
        {
            Fraction num1 = new Fraction(1, 3);
            Fraction num2 = new Fraction(1, 4);

            Console.WriteLine("User Fraction: {0}", num1);
            Console.WriteLine("User Fraction: {0}\n", num2);
            num1.GetNormalize();
            num2.GetNormalize();
            Console.WriteLine("Normalize Fraction: {0}", num1);
            Console.WriteLine("Normalize Fraction: {0}\n", num2);
            

            Fraction result = num1 + num2;
            result.GetNormalize();
            Console.WriteLine("Sum Fraction: {0}", result);

            Fraction result1 = num1 - num2;
            result.GetNormalize();
            Console.WriteLine("Sub Fraction: {0}", result1);


            Console.ReadKey();
        }
    }
}
