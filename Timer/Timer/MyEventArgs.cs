using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    internal class MyEventArgs : EventArgs
    {
        public string Message { get; private set; }

        public MyEventArgs(string message)
        {
            Message = message;
        }
    }
}
