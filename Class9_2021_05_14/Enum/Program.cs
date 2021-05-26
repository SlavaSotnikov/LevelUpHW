using System;

namespace Enum
{
    class Program
    {
        private static double GetAddition(double num1, double num2)
        {
            return num1 + num2;
        }

        private static double GetSubtraction(double num1, double num2)
        {
            return num1 - num2;
        }

        private static double GetMultiplication(double num1, double num2)
        {
            return num1 * num2;
        }

        private static double GetDivision(double num1, double num2)
        {
            return num1 / num2;
        }

        private static void ShowError(string sign)
        {
            Console.SetCursorPosition(20, 5);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Error: '{0}' isn't a math operation.", GetError(sign));
            Console.ResetColor();
        }

        private static double GetResult(string sign, double num1, double num2)
        {           
            double res = 0.0;

            switch (GetMathOperation(sign))
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
                    ShowError(sign);
                    break;
            }

            Console.SetCursorPosition(35, 3);

            return res;
        }

        private static MathOperations GetMathOperation(string sign)
        {
            char signChar = Convert.ToChar(sign);

            return (MathOperations)signChar;
        }

        private static Errors GetError(string sign)
        {
            char signChar = Convert.ToChar(sign);

            return (Errors)signChar;
        }

        private static void Main()
        {
            Console.Title = "Simple Calculator";

            Console.SetBufferSize(120, 40);

            Console.SetCursorPosition(26, 1);
            Console.WriteLine("Enter an expression: ");

            Console.SetCursorPosition(30, 3);
            double num1 = double.Parse(Console.ReadLine());
            Console.SetCursorPosition(31, 3);

            Console.SetCursorPosition(32, 3);
            string sign = Console.ReadLine();
            Console.SetCursorPosition(33, 3);

            Console.SetCursorPosition(34, 3);
            double num2 = double.Parse(Console.ReadLine());
            
            Console.WriteLine(" = {0}", GetResult(sign, num1, num2));
            Console.SetCursorPosition(40, 3);
            
            Console.ReadKey();
        }
    }
}
