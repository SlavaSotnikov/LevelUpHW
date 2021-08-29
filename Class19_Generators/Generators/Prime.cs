using System;
using System.Collections;

namespace Generators
{
    class Prime : IGenerator
    {
        #region Private Data

        private int _first;
        private int _last;

        #endregion

        #region Constructor

        public Prime(int first, int last)    // TODO: Ask a question about constructor.
        {
            _first = first;
            _last = last;
        }

        #endregion

        #region Methods

        public IEnumerable GetSequence()
        {
            bool prime = true;

            for (int i = _first; i <= _last; i++)
            {
                for (int j = 2; j < _last; j++)
                {
                    if (i != j && i % j == 0)
                    {
                        prime = false;

                        break;
                    }
                }

                if (prime)
                {
                    yield return i;
                }

                prime = true;
            }
        }

        #endregion

    }
}
