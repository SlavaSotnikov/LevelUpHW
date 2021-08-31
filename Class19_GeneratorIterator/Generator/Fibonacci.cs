using System;
using System.Collections;

namespace Generator
{
    class Fibonacci : IEnumerable
    {
        #region Private Data

        private int _greaterFib;
        private int _lowerFib;
        private int _last;

        #endregion

        #region Constructor

        public Fibonacci(int first = 1, int last = 10)
        {
            int fib1 = 0;
            int fib2 = 1;

            while (fib1 <= first)    // TODO: Extract a method.
            {
                fib1 += fib2;
                fib2 = fib1 - fib2;
            }

            _greaterFib = fib1;

            _lowerFib = fib2;

            _last = last;
        }

        #endregion

        #region Methods

        public IEnumerator GetEnumerator()
        {
            return new FibonacciIterator(_greaterFib, _lowerFib, _last);
        }

        #endregion

        #region Iterator

        private struct FibonacciIterator : IEnumerator
        {
            #region Private Data

            private int _greaterFib;
            private int _lowerFib;
            private int _last;

            #endregion

            public FibonacciIterator(int greaterFib, int lowerFib, int last)
            {
                _greaterFib = greaterFib;
                _lowerFib = lowerFib;
                _last = last;
            }

            public object Current
            {
                get
                {
                    _greaterFib += _lowerFib;
                    _lowerFib = _greaterFib - _lowerFib;

                    return _lowerFib;
                }
            }

            public bool MoveNext()
            {
                bool resault = true;

                if (_greaterFib >= _last)
                {
                    resault = false;
                }

                return resault;
            }

            public void Reset()
            {
            }
        }

        #endregion

    }
}
