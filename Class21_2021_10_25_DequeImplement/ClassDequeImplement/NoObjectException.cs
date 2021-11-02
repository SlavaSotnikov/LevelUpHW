﻿using System;

namespace ClassDequeImplement
{
    internal class NoObjectException : Exception
    {
        public NoObjectException()
        {
        }
        public NoObjectException(string message)
            : base(message)
        {
        }
        public NoObjectException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
