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

        private const sbyte INITIAL_VALUE = -1;

        private QueueStatus _warning;

        #endregion

        public object[] GetElements 
        {
            get; 
        }

        public int Head { get; set; }

        public int Tale { get; set; }

        public int Size { get; set; }

        #region Constructors

        public Queue(int capacity)
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

            if (_head == 0 && _tale == _elements.Length - 1)
            {
                _warning = QueueStatus.Full;

                Array.Resize(ref _elements, _elements.Length * 2);
            }

            if (_head == _tale + 1)
            {
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
            if (_head == -1)
            {
                _warning = QueueStatus.Empty;

                return null;
            }

            object temp = _elements[_head];

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

            return temp;
        }

        public IEnumerator GetEnumerator()
        {
            return new QueueIterator(this);
        }


        #endregion
    }
}
