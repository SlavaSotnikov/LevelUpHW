using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueList
{
    public class QueueEnumerator<Entry> : IEnumerator<Entry>
    {
        private Entry _current;

        public QueueEnumerator(Entry head)
        {
            _current =  head;
        }

        public Entry Current
        {
            get { return _current; }

            private set { _current = value; }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            bool result = true;

            Entry entry = Current;


            if (false/*entry.Next == null*/)
            {
                result = false;
            }

            //_current = _current.Next;

            return result;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
