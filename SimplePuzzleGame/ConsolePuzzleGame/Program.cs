using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
