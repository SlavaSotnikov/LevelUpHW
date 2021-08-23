using System;

namespace Queue
{
    class Queue
    {
        #region Private Data

        private object[] _elements;
        private object[] _auxiliary;
        private int _head;
        private int _tale;

        private Warnings _warning;

        #endregion

        #region Constructors

        public Queue(int capacity)
        {
            _head = -1;
            _tale = -1;
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
                //Array.Resize(ref _elements, _elements.Length * 2);

                _auxiliary = new object[_tale + 1];

                // Copy to _auxiliary
                Array.Copy(_elements, 0, _auxiliary, 0, _tale + 1);

                // Move at the beginning.
                Array.Copy(_elements, _head, _elements, 0, _elements.Length - _head);  
                
                _tale = _elements.Length - _head;
                _head = 0;

                // Copy from _auxiliary into _elements
                Array.Copy(_auxiliary, 0, _elements, _tale, _auxiliary.Length);

                _tale += _auxiliary.Length - 1;
                
                Array.Resize(ref _elements, _elements.Length * 2);
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

        #endregion
    }
}
