using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class21_DoublyLinkedList
{
    internal class DLEnumerator : IEnumerator
    {
        private Entry _head;

        public DLEnumerator(Entry source)
        {
            _head = source;
        }

        public object Current
        {
            get { return _head; }
            set { _head = (Entry)value; }
        }

        public bool MoveNext()    // TODO: What about a very first item?
        {
            bool result = false;

            if (Current is Entry one && one.Next != null)
            {
                Current = one.Next;
                result = true;
            }

            return result;
        }

        public void Reset()
        {
            Current = _head;
        }
    }
}
