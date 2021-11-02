using System.Collections;

namespace Class21_DoublyLinkedList
{
    internal class DLEnumerator : IEnumerator
    {
        private Entry _head;
        private Entry _temp;

        public DLEnumerator(Entry source)
        {
            _head = source;
            _temp = new Entry(0) { Next = _head };    // Try bool.
        }

        public object Current
        {
            get { return _temp; }
            set { _temp = (Entry)value; }
        }

        public bool MoveNext()
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
