using System;

namespace Delegates
{
    internal class Subscriber
    {
        private int _iterationCount = 0;

        public Subscriber(Publisher p)
        {
            p.NewIterationSubscribe(OnNewIteration);
        }

        private void OnNewIteration(int i)
        {
            int oldX = Console.CursorLeft;
            int oldY = Console.CursorTop;
            ConsoleColor oldColor= Console.ForegroundColor;

            Console.SetCursorPosition(30, 8);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Iteration: {0}", i);

            Console.ForegroundColor = oldColor;
            Console.SetCursorPosition(oldX, oldY);
        }

        public void OnNewIterationCountIteration(int i)
        {
            ++_iterationCount;

            int oldX = Console.CursorLeft;
            int oldY = Console.CursorTop;
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.SetCursorPosition(30, 8);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Iteration Count: {0}", _iterationCount);

            Console.ForegroundColor = oldColor;
            Console.SetCursorPosition(oldX, oldY);
        }
    }
}
