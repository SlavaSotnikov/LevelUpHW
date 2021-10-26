using System;
using System.Collections;

namespace QueueList
{
    public class QueueEnumerator : IEnumerator
    {
        public QueueEnumerator(Entry head)
        {
            Current = head;
        }

        public object Current { get; private set; }
        //{ 
        //    get 
        //    {
        //        return _current;
        //    }
        //    set
        //    {
        //        _current = (Entry)value;
        //    }   
        //}

        public bool MoveNext()
        {
            bool result = true;

            Entry entry = (Entry)Current;

            if (entry.Next == null)
            {
                result = false;
            }

            Current = entry.Next;

            return result;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
