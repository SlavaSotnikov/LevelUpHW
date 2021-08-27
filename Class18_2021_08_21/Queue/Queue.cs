using System;
using System.Collections;

namespace Queue
{
    class Queue : IContainer, IEnumerable
    {
        #region Private Data

        private object[] _elements;
        private int _head;
        private int _tale;
        private int _size;

        private const sbyte INITIAL_VALUE = -1;

        private Warnings _warning;

        #endregion

        public object this[int index]
        {
            get
            {
                return _elements[index];
            }
            set
            {
                _elements[index] = (int)value;
            }
        }

        public int Size
        {
            get
            {
                return _size;
            }
        }

        public int Length 
        {
            get
            {
                return _elements.Length;
            }
        }

        public int Head
        {
            get
            {
                return _head;
            }
        }

        public int Tale
        {
            get
            {
                return _tale;
            }
        }
        #region Constructors

        public Queue(int capacity)
        {
            _size = 0;
            _head = INITIAL_VALUE;
            _tale = INITIAL_VALUE;
            _elements = new object[capacity];
        }

        #endregion

        #region public methods

        public void Add(object source)
        {
            _warning = Warnings.Ok;

            if (_head == 0 && _tale == _elements.Length - 1)
            {
                _warning = Warnings.Queue_is_full;

                Array.Resize(ref _elements, _elements.Length * 2);
            }

            if (_head == _tale + 1)
            {
                Array.Resize(ref _elements, _elements.Length * 2);

                Array.Copy(_elements, _head, _elements, 
                        _elements.Length - (Size - _head), Size - _head);

                _head = _elements.Length - Size + 2;
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
                _warning = Warnings.Queue_is_empty;

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
