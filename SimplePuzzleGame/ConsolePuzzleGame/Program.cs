
using BL;

namespace ConsolePuzzleGame
{
    internal class Program
    {
        static void Main()
        {
            byte size = 4;
            IGame puzzle = new Game(size);

            ConsoleUI newGame = new ConsoleUI(puzzle, size);
            newGame.Run();
        }
    }
}
