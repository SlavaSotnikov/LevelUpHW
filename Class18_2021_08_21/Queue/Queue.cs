using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue
{
    class Queue<T> : IQueue<T>, IEnumerable<T>
    {
        #region Private Data

        private T[] _elements;
        private int _head;
        private int _tail;
        private int _size;

        private QueueStatus _warning;

        #endregion

        #region Constructors

        public Queue(int capacity = 5)
        {
            _size = 0;
            _head = 0;
            _tail = -1;
            _elements = new T[capacity];
        }

        #endregion

        #region Public Methods

        public void Resize(int newSize)
        {
            if (newSize > _elements.Length)
            {
                Array.Resize(ref _elements, newSize); 
            }
        }

        public void Add(T source)
        {
            _warning = QueueStatus.Ok;

            if (IsFool())
            {
                throw new QueueException($"Queue is full! \n{source} is an extra object," +
                        $" resize the array.");
            }

            _tail = (_tail + 1) % _elements.Length;
            _elements[_tail] = source;
            ++_size;
        }

        public T Get()
        {
            if (IsEmpty())
            {
                throw new QueueException("The Queue is empty!");    // TODO: Exception 1
            }

            T removed = _elements[_head];

            _elements[_head] = default;
            _head = (_head + 1) % _elements.Length;
            --_size;

            return removed;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new QueueIterator(_elements, _head, _tail);
        }

        private IEnumerator GetEnumerator()
        {
            return GetEnumerator();  
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            bool result = true;

            for (int i = 0; i < _elements.Length; i++)
            {
                if (_elements[i] != null)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public bool IsFool()
        {
            return (_head == 0 && _tail == _elements.Length - 1);
        }

        #endregion

        #region QueueIterator

        private struct QueueIterator : IEnumerator<T>
        {
            private T[] _elements;
            private int _head;
            private int _tail;

            public QueueIterator(T[] elements, int head, int tail)
            {
                _elements = elements;
                _head = head - 1;
                _tail = tail;
            }

            public object Current
            {
                get
                {
                    return _elements[_head];
                }
            }

            T IEnumerator<T>.Current
            {
                get
                {
                    return _elements[_head];
                }
            }

            public bool MoveNext()
            {
                bool result = false;

                if (_head != _tail)
                {
                    _head++;

                    if (_head > _elements.Length - 1)
                    {
                        _head = 0;
                    }

                    result = true;
                }

                return result;
            }

            public void Reset()
            {
                _head = -1;
            }

            public void Dispose() {}
        }

        #endregion
    }
}
