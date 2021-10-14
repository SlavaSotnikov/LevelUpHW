using System;

namespace Game
{
    public class UIEventArgs : EventArgs
    {
        public GameAction Action { get; private set; }

        public UIEventArgs(GameAction source)
        {
            Action = source;
        }
    }
}
