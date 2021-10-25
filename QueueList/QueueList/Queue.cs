namespace QueueList
{
    public class Queue<T>
    {
        private Entry<T> _head;
        private Entry<T> _tail;

        public int Amount { get; private set; }

        public void Enqueue(T data)
        {
            Entry<T> node = new Entry<T>(data);

            if (_head == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _tail.Next = node;
                _tail = node;
            }

            ++Amount;
        }

        public Entry<T> Dequeue()
        {
            Entry<T> result;

            if (IsEmpty)
            {
                return null;
            }

            result = _head;
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
