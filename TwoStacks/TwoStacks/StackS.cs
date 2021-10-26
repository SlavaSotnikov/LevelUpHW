using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoStacks
{
    internal class StackS
    {
        Entry top;
        public int Amount { get; private set; }

        public void Push(object data)
        {
            top = new Entry(top, data);

            ++Amount;
        }

        class Entry
        {
            public Entry
        }
    }
}
