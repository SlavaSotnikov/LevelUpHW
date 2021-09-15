using System;

namespace Game
{
    class ClashException : Exception
    {
        public int X { get; set; }
        public int Y { get; set; }

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
        {
        }
    }
}
