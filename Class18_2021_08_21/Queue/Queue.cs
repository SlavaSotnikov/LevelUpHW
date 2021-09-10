using System;
using System.Collections;

namespace Queue
{
    class Queue : IQueue, IEnumerable
    {
        #region Private Data

        private object[] _elements;
        private int _head;
        private int _tail;
        private int _size;

        private const sbyte INITIAL_VALUE = -1;

        private QueueStatus _warning;

        #endregion

        #region Constructors

        public Queue(int capacity = 5)
        {
            _size = 0;
            _head = 0;
            _tail = -1;
            _elements = new object[capacity];
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

        public void Add(object source)
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

        public object Get()
        {
            if (IsEmpty())
            {
                throw new QueueException("The Queue is empty!");    // TODO: Exception 1
            }

            object removed = _elements[_head];

            _elements[_head] = null;
            _head = (_head + 1) % _elements.Length;
            --_size;

            return removed;
        }

        public IEnumerator GetEnumerator()
        {
            return new QueueIterator(_elements, _head, _tail);    
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

        private struct QueueIterator : IEnumerator
        {
            private object[] _elements;
            private int _head;
            private int _tail;

            public QueueIterator(object[] elements, int head, int tail)
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
        }

        #endregion
    }
}
