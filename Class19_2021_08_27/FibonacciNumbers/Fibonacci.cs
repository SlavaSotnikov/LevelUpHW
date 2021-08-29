﻿using System;
using System.Collections;

namespace FibonacciNumbers
{
    class Fibonacci
    {
        #region Private Data

        private int _greaterFib;
        private int _lowerFib;
        private int _last;

        #endregion

        #region Constructor

        public Fibonacci(int first = 1, int last = 10)
        {
            int fibonacci = 0;
            int temp = 1;

            while (fibonacci <= first)
            {
                fibonacci += temp;
                temp = fibonacci - temp;
            }

            _lowerFib = temp;

            _greaterFib = fibonacci;

            _last = last;
        }

        #endregion

        public IEnumerator GetEnumerator()
        {
            int fibonacci = _greaterFib;
            int temp = _lowerFib;

            while (temp < _last)
            {
                fibonacci += temp;
                temp = fibonacci - temp;

                if (temp >= _last)
                {
                    yield break;
                }

                yield return temp;
            }
        }
    }
}
