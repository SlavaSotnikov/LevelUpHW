using System;

namespace Enum
{
    class Program
    {
        static double GetAddition(double num1, double num2)
        {
            return num1 + num2;
        }

        static double GetSubtraction(double num1, double num2)
        {
            return num1 - num2;
        }

        static double GetMultiplication(double num1, double num2)
        {
            return num1 * num2;
        }

        static double GetDivision(double num1, double num2)
        {
            return num1 / num2;
        }

        static void Main()
        {
            Console.Title = "Simple Calculator";

            Console.SetBufferSize(120, 40);

            Console.WriteLine("Enter an expression: ");
            double num1 = double.Parse(Console.ReadLine());

            string sign = Console.ReadLine();

            double num2 = double.Parse(Console.ReadLine());

            MathOperations m = MathOperations.None;

            double res = 0.0;

            if (System.Enum.TryParse(sign, out m))
            {
                switch (m)
                {
                    case MathOperations.None:
                        break;
                    case MathOperations.Addition:
                        res = GetAddition(num1, num2);
                        break;
                    case MathOperations.Subtraction:
                        res = GetSubtraction(num1, num2);
                        break;
                    case MathOperations.Multiplication:
                        res = GetMultiplication(num1, num2);
                        break;
                    case MathOperations.Division:
                        res = GetDivision(num1, num2);
                        break;
                    default:
                        break;
                }
            }


            Console.WriteLine("The result is {0}", res);
            Console.ReadKey();
        }
    }
}
