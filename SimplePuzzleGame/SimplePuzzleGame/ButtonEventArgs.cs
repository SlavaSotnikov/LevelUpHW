using System;

namespace SimplePuzzleGame
{
    internal class ButtonEventArgs : EventArgs
    {
        public int I { get; set; }
        public int J { get; set; }

        public ButtonEventArgs(int i, int j)
        {
            I = i;
            J = j;
        }
    }
}
