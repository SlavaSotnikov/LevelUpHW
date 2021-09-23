using System;

namespace Delegates
{
    internal class Program
    {
        static void Main()
        {
            Publisher p = new Publisher();

            Subscriber s1 = new Subscriber(p);

            p.NewIterationSubscribe(s1.OnNewIterationCountIteration);

            p.Run(5);

            Console.ReadKey();
        }

        private static void OnNewIteration(int i)
        {
            int oldX = Console.CursorLeft;
            int oldY = Console.CursorTop;
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.SetCursorPosition(40, 5);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Iteration: {0}", i);

            Console.ForegroundColor = oldColor;
            Console.SetCursorPosition(oldX, oldY);
        }
    }
}
