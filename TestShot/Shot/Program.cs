using System;

namespace Shot
{
    class Program
    {
        static void Main()
        {
            int x = Console.WindowWidth / 2;
            int y = Console.WindowHeight / 2;

            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;

            do
            {
                Console.SetCursorPosition(x, y);
                Console.Write(' ');
                Console.SetCursorPosition(x + 5, y);
                Console.Write(' ');
                Console.SetCursorPosition(x, y + 4);
                Console.Write(' ');
                Console.SetCursorPosition(x + 5, y+4);
                Console.Write(' ');

                y -= 1;

                if (y <= 0)
                {
                    y = Console.WindowHeight;
                }

                Console.SetCursorPosition(x, y);
                Console.Write('█');
                Console.SetCursorPosition(x + 5, y);
                Console.Write('█');

                Console.SetCursorPosition(x, y+4);
                Console.Write('|');
                Console.SetCursorPosition(x + 5, y+4);
                Console.Write('|');

                System.Threading.Thread.Sleep(40);

            } while (true);


        }
    }
}
