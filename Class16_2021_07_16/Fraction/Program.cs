using System;

namespace Fraction
{
    class Program
    {
        static void Main()
        {
            Fraction num1 = new Fraction(2, 2);
            Fraction num2 = new Fraction(1, 4);

            Console.WriteLine("User Fraction: {0}", num1);
            Console.WriteLine("User Fraction: {0}\n", num2);
            num1.ApplyNormalize();
            num2.ApplyNormalize();
            Console.WriteLine("Normalize Fraction: {0}", num1);
            Console.WriteLine("Normalize Fraction: {0}\n", num2);
            

            Fraction res = num1 + num2;
            res.ApplyNormalize();
            Console.WriteLine("Sum Fraction: {0}", res);

            Fraction res1 = num1 - num2;
            res1.ApplyNormalize();
            Console.WriteLine("Sub Fraction: {0}", res1);

            Fraction res2 = num1 * num2;
            res2.ApplyNormalize();
            Console.WriteLine("Mult Fraction: {0}", res2);

            Fraction res3 = num1 / num2;
            res3.ApplyNormalize();
            Console.WriteLine("Div Fraction: {0}", res3);

            Fraction res4 = ++num1;
            res4.ApplyNormalize();
            Console.WriteLine("Inc Fraction: {0}", res4);

            Fraction res5 = --num1;
            res5.ApplyNormalize();
            Console.WriteLine("Dec Fraction: {0}", res5);

            Console.ReadKey();
        }
    }
}
