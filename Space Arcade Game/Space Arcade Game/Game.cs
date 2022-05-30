using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Arcade_Game
{
    internal class Game
    {
        private Map _gameField;

        public void Run()
        {
            do
            {
                

            } while (IsGameOver());
        }

        private bool IsGameOver()
        {
            return false;
        }

        public Game(int size)
        {
            _gameField = new Map(size);
        }
    }
}
