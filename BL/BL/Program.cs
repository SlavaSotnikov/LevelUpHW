using System;

namespace BL
{
    internal class Program
    {
        static void Main()
        {
            Game puzzle = new Game(4);
            puzzle.Run();
            
            Console.ReadKey();
        }
    }
}
