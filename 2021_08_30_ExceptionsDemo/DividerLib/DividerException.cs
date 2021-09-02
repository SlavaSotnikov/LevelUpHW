using System;

namespace DividerLib
{
    public class DividerException : Exception
    {

        public DividerException()
        {
        }

        public DividerException(string message)
            : base(message)
        {
        }

        public DividerException(string message, Exception innerException)
            :base(message, innerException)
        {
        }

    }
}
