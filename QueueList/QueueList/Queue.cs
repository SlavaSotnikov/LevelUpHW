using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueList
{
    public class Queue<T> : IEnumerable<T>
    {
        private Entry _head = null;
        private Entry _tail = null;
        private Entry _node = null;

        

        public Entry Head => _head;

        public ulong Amount { get; private set; }

        public bool IsFool => Amount > 0 && _node == null;

        public void Enqueue(T data)
        {
            try
            {
                _node = new Entry(data);
            }
            catch (Exception ex)
            {
                throw new NoObjectException("A new object wasn't created!", ex);
            }

            if (_head == null)
            {
                _head = _node;
                _tail = _node;
            }
            else
            {
                _tail.Next = _node;
                _tail = _node;
            }

            ++Amount;
        }

        public Entry Dequeue()
        {
            if (IsEmpty)
            {
                throw new MissingMemberException("No objects.");
            }

            Entry result = _head;
            _head = _head.Next;

            --Amount;

            return result;
        }

        public IEnumerator<Entry> GetEnumerator()
        {
            return new QueueEnumerator<Entry>(_head);


            //for (Entry en = _head; en != null; en = en.Next)
            //{
            //    yield return en.Data;
            //}
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private Entry _p = null;
        private Entry _c = null;
        private Entry _h = null;

        public void Reverse()
        {
            _p = _head;
            _c = _head;
            _h = _head;

            _c = _c.Next;
            _h = _c.Next;
            _p.Next = null;

            while (_c.Next != null && _h.Next != null)
            {
                _c.Next = _p;
                _p = _h.Next;
                _h.Next = _c;
                _c = _p.Next;
                _p.Next = _h;
                _h = _c.Next;
            }

            _head = _c;
        }

        public bool IsEmpty => _head == null;

        public class Entry
        {
            public T Data { get; set; }

            public Entry Next { get; set; }

            public Entry(T data)
            {
                Data = data;
            }

            public Entry(Entry source)
            {
                Data = source.Data;
                Next = source.Next;
            }
        }
    }

    


}
