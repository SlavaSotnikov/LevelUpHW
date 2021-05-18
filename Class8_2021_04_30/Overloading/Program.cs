using System;

namespace Overloading
{    
    class Program
    {
        public static void ShowErrorMessage(string message = "Error!!!")
        {
            int oldX = Console.CursorLeft;
            int oldY = Console.CursorTop;

            int lastWindowRow = Console.WindowHeight - 1;

            int leftPosition = (Console.WindowWidth - message.Length) / 2;

            Console.SetCursorPosition(leftPosition, lastWindowRow);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Yellow;

            Console.Write(message);

            Console.SetCursorPosition(oldX, oldY);

            Console.ResetColor();
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

            Console.WriteLine(GetSum(2, 5, 2, 2, 2));
            Console.ReadKey();
        }
    }
}
