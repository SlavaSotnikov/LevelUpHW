using System;
using static System.Console;

namespace Overloading
{    
    class Program
    {
        public static void ShowErrorMessage(string message = "Error!!!")
        {
            int oldX = CursorLeft;
            int oldY = CursorTop;

            int lastWindowRow = WindowHeight - 1;

            int leftPosition = (WindowWidth - message.Length) / 2;

            SetCursorPosition(leftPosition, lastWindowRow);

            ForegroundColor = ConsoleColor.Red;
            BackgroundColor = ConsoleColor.Yellow;

            Write(message);

            SetCursorPosition(oldX, oldY);

            ResetColor();
        }

        static int GetSum(int a, int b)
        {
            return a + b;
        }

        static int GetSum(int a, int b, int c)
        {
            return GetSum(GetSum(a, b), c);
        }

        static int GetSum(int a, int b, int c, int d)
        {
            return GetSum(GetSum(a, b), c, d);
        }

        static int GetSum(int a, int b, int c, int d, int e)
        {
            return GetSum(GetSum(a, b), c, d, e);
        }
        static void Main()
        {
            ShowErrorMessage("Press any key...");

            WriteLine(GetSum(2, 5, 2, 2, 2));
            ReadKey();
        }
    }
}
