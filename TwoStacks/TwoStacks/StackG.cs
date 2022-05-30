using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoStacks
{
    internal class StackG<T>
    {
        private Entry _top;
        public int Amount { get; private set; }

        public void Push(object data)
        {
            _top = new Entry(_top, data);

            ++Amount;
        }

        public object Pop()
        {
            if (_top == null)
            {

            }

            object result = _top.data;
            _top = _top.next;

            --Amount;

            return result;
        }

        class Entry
        {
            public Entry next;
            public object data;

            public Entry(Entry next, object data)
            {
                this.next = next;
                this.data = data;
            }
        }
    }
}
