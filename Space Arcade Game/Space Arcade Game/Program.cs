using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Arcade_Game
{
    internal class Program
    {
        static void Main()
        {
            Game game = new Game(5);
            game.Run();
        }
    }
}
