using System;
using System.Collections;

namespace Queue
{
    class Queue : IQueue, IEnumerable
    {
        #region Private Data

        private object[] _elements;
        private int _head;
        private int _tale;
        private int _size;

        private const sbyte INITIAL_VALUE = 0;

        private QueueStatus _warning;

        #endregion

        #region Constructors

        public Queue(int capacity = 5)
        {
            _size = 0;
            _head = INITIAL_VALUE;
            _tale = INITIAL_VALUE;
            _elements = new object[capacity];
        }

        #endregion

        #region Public Methods

        public void Add(object source)
        {
            _warning = QueueStatus.Ok;

            //if (IsFool())
            //{
            //    _warning = QueueStatus.Full;

            //    Array.Resize(ref _elements, _elements.Length * 2);
            //}

            if (IsFool())
            {
                _warning = QueueStatus.Full;

                Array.Resize(ref _elements, _elements.Length * 2);

                Array.Copy(_elements, _head, _elements, 
                        _elements.Length - (_size - _head), _size - _head);

                _head = _elements.Length - _size + 2;
            }

            if (_head == -1)
            {
                _head = 0;
                _tale = 0;
            }
            else
            {
                if (_tale == _elements.Length - 1)
                {
                    _tale = 0;
                }
                else
                {
                    _tale += 1;
                }
            }

            _elements[_tale] = source;
            ++_size;

        }

        public object Get()
        {
            if (IsEmpty())
            {
                throw new QueueException("The Queue is empty!");    // TODO: Exception 1
            }

            object result = _elements[_head];

            _elements[_head] = null;
            --_size;

            if (_head == _tale)
            {
                _head = -1;
                _tale = -1;
            }
            else
            {
                if (_head == _elements.Length - 1)
                {
                    _head = 0;
                }
                else
                {
                    _head += 1;
                }
            }

            return result;
        }

        public IEnumerator GetEnumerator()
        {
            return new QueueIterator(_elements, _head, _tale);    
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
            return (_head == 0 && _tale == _elements.Length - 1) 
                    || (_head == _tale + 1);
        }

        #endregion

        #region QueueIterator

        private struct QueueIterator : IEnumerator
        {
            private object[] _elements;
            private int _head;
            private int _tale;

            public QueueIterator(object[] elements, int head, int tale)
            {
                _elements = elements;
                _head = head - 1;
                _tale = tale;
            }

            public object Current
            {
                get
                {
                    //if (_head < 0)
                    //{
                    //    throw new InvalidOperationException("Invalid operation!");    // TODO: Exception 2
                    //}

                    return _elements[_head];
                }
            }

            public bool MoveNext()
            {
                bool result = false;

                if (_head != _tale)
                {
                    ++_head;

                    if (_head >= _elements.Length)
                    {
                        _head = 0;
                    }

                    result = true;
                }

                return result;
            }

            public void Reset()
            {
                _head -= 1;
            }
        }

        #endregion
    }
}
