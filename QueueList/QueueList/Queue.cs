using System;
using System.Numerics;

namespace QueueList
{
    public class Queue<T>
    {
        private Entry<T> _head = null;
        private Entry<T> _tail = null;
        private Entry<T> _node = null;

        public ulong Amount { get; private set; }

        public bool IsFool { get; private set; }



        public void Enqueue(T data)
        {
            try
            {
                _node = new Entry<T>(data);
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

        public Entry<T> Dequeue()
        {
            if (IsEmpty)
            {
                throw new MissingMemberException("No objects.");
            }

            Entry <T> result = _head;
            _head = _head.Next;

            --Amount;

            return result;
        }

        public bool IsEmpty => _head == null;

        public class Entry<U>
        {
            public U Data { get; set; }

            public Entry<U> Next { get; set; }

            private decimal _weight = decimal.MaxValue;
            private decimal _weight1 = decimal.MaxValue;
            private decimal _weight2 = decimal.MaxValue;
            private decimal _weight3 = decimal.MaxValue;

            public Entry(U data)
            {
                Data = data;
            }
        }
    }
}
