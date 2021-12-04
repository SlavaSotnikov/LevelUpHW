using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Arcade_Game
{
    internal class UI
    {
        public static string AskConsole()
        {
            string result = string.Empty;

            result = Console.ReadLine();

            return result;
        }
    }
}
