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

        static Errors GetError(string sign, Errors e)
        {
            if (System.Enum.TryParse(sign, out e))
            {
                switch (e)
                {
                    case Errors.None:
                        break;
                    case Errors.Exclame:
                        break;
                    case Errors.At:
                        break;
                    case Errors.Pound:
                        break;
                    case Errors.Dollar:
                        break;
                    case Errors.XOR:
                        break;
                    case Errors.And:
                        break;
                    case Errors.Open_Bracket:
                        break;
                    case Errors.Close_Bracket:
                        break;
                    default:
                        break;
                }

                return e;
            }

            return e;   
        }

        static string GetStringForEnum(string sign)
        {
            char toChar = Convert.ToChar(sign);
            byte toByte = Convert.ToByte(toChar);
            string toStr = Convert.ToString(toByte);

            return toStr;
        }

        static void Main()
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

            MathOperations m = MathOperations.None;
            Errors e = Errors.None;

            double res = 0.0;

            if (System.Enum.TryParse(GetStringForEnum(sign), out m))
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
                        Errors errorNum = GetError(GetStringForEnum(sign), e);

                        Console.SetCursorPosition(20, 5);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Error: '{0}' isn't a math operation.", errorNum);
                        Console.ResetColor();
                        break;
                }
            }
            else
            {
                Console.SetCursorPosition(35, 4);
                Console.WriteLine("Ooops!");
            }

            Console.SetCursorPosition(35, 3);
            Console.WriteLine(" = {0}", res);
            Console.SetCursorPosition(40, 3);

            Console.ReadKey();
        }
    }
}
