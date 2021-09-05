﻿using System;

namespace Queue
{
    class QueueException : Exception
    {
        public QueueException()
        {
        }

        public QueueException(string message)
            : base(message)
        {
        }

        public QueueException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
