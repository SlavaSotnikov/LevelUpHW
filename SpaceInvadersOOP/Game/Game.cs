using System;

namespace Game
{
    class Game
    {
        public static GameAction GetEvent()
        {
            return UI.AskConsole();
        }

        public Game()
        {
        }
    }
}
