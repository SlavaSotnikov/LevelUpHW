using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Arcade_Game
{
    internal class Controller
    {
        public static string AskUI()
        {
            return UI.AskConsole();
        }
    }
}
