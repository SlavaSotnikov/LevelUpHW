using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Timer
    {
        ITimer _game;

        public Timer(ITimer source)
        {
            _game = source;
        }

        public void RunTimer()
        {
            do
            {
                _game.Run();

            } while (IsGameOver());
        }

        private bool IsGameOver()    // TODO: Sign in to BL.
        {
            return false;
        }
    }
}
