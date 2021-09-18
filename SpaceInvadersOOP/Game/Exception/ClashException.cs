using System;

namespace Game
{
    class ClashException : Exception
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public ClashException(string message, int positionX, int positionY)
            : base(message)
        {
            SetterXY(positionX, positionY);
        }

        public ClashException(string message, Exception innerException,
                int positionX, int positionY)
            : base(message, innerException)
        {
            SetterXY(positionX, positionY);
        }

        private void SetterXY(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
