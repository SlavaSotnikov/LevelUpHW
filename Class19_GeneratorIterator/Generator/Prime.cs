using System.Collections;

namespace Generator
{
    class Prime : IEnumerable
    {
        #region Private Data

        private int _first;
        private int _last;

        #endregion

        #region Constructors

        public Prime(int first, int last)
        {
            _first = first;
            _last = last;
        }

        #endregion

        public IEnumerator GetEnumerator()
        {
            return new PrimeIterator(_first, _last);
        }

        public IEnumerable GetSequence()
        {
            throw new System.NotImplementedException();
        }

        #region Iterator

        private struct PrimeIterator : IEnumerator
        {
            #region Private Data

            private int _first;
            private int _last;
            private int _i;

            #endregion

            #region Constructors

            public PrimeIterator(int first, int last)
            {
                _first = first - 1;
                _last = last;
                _i = first;
            }

            #endregion

            public object Current
            {
                get
                {
                    ++_first;

                    int result = 0;
                    int count = 0;

                    while (_first <= _last)
                    {
                        for (int j = 2; j < _first; j++)
                        {
                            if (_first % j != 0)
                            {
                                count += 1;
                            }
                        }

                        if (count == (_first - 2))
                        {
                            result = _first;
                            break;
                        }
                        else
                        {
                            ++_first;
                            count = 0;
                        }
                    }

                    return result;
                }
            }

            public bool MoveNext()
            {
                bool result = true;

                if (_first >= _last)
                {
                    result = false;
                }

                return result;
            }

            public void Reset()
            {
            }
        }

        #endregion

    }
}
