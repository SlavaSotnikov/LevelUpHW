using System;

namespace Game
{
    class ClashException : Exception
    {
        public int X { get; }
        public int Y { get; }

        public ClashException()
        {
        }

        public ClashException(string message, int positionX, int positionY)
            : base(message)
        {
            X = positionX;
            Y = positionY;
        }

        public ClashException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
