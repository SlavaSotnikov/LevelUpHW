using System;

namespace QueueList
{
    public class Queue<T>
    {
        private Entry<T> _head = null;
        private Entry<T> _tail = null;
        private Entry<T> _node = null;

        public ulong Amount { get; private set; }

        public bool IsFool
        {
            get
            {
                return Amount > 0 && _node == null;
            }
        }



        public void Enqueue(T data)    // TODO: Design IsFool method.
        {
            _node = new Entry<T>(data);

            if (_node == null)
            {
                throw new NoObjectException("A new object wasn't created!");
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

            public Entry(U data)
            {
                Data = data;
            }
        }
    }
}
