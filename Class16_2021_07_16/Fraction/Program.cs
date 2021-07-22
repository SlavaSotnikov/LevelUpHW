using System;

namespace Fraction
{
    class Program
    {
        static void Main()
        {
            Fraction num1 = new Fraction(2, 2);
            Fraction num2 = new Fraction(1, 1);

            Console.WriteLine("User Fraction: {0}", num1);
            Console.WriteLine("User Fraction: {0}\n", num2);

            #region Overloading

            AnotherFraction anNum = new AnotherFraction(3, 2);

            Fraction num3 = (Fraction)anNum++;

            AnotherFraction anNum1 = (AnotherFraction)num1;

            Fraction res0 = num1 + anNum;

            bool res = num1 ^ num2;
            Console.WriteLine("Sum Fraction: {0}", res);

            //Fraction res1 = num1 - num2;
            //Console.WriteLine("Sub Fraction: {0}", res1);

            //Fraction res2 = num1 * num2;
            //Console.WriteLine("Mult Fraction: {0}", res2);

            //Fraction res3 = num1 / num2;
            //Console.WriteLine("Div Fraction: {0}", res3);

            //Fraction res4 = ++num1;
            //Console.WriteLine("Inc Fraction: {0}", res4);

            //Fraction res5 = --num1;
            //Console.WriteLine("Dec Fraction: {0}", res5);

            //bool comp = num1 < num2;
            //Console.WriteLine("Compare Fractions: {0}", comp);

            //bool comp1 = num1 > num2;
            //Console.WriteLine("Compare Fractions: {0}", comp1);

            //bool comp2 = num1 <= num2;
            //Console.WriteLine("Compare Fractions: {0}", comp2);

            //bool comp3 = num1 >= num2;
            //Console.WriteLine("Compare Fractions: {0}", comp3);

            #endregion

            Console.ReadKey();
        }
    }
}
