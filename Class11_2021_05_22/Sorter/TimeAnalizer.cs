using System;
using System.Collections.Generic;
using System.Linq;
namespace Sorter
{
    internal class TimeAnalizer
    {
        private int _start;
        private int _finish;

        public void SetStart(int source)    // TODO: Ask a question about just set properties.
        {
            _start = source;
        }

        public void SetFinish(int source)
        {
            _finish = source;
        }

        public int Total 
        { 
            get
            {
                return _finish - _start;
            }
        }
    }
}
