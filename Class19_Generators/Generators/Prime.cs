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

        public Prime(int first, int last)    // TODO: Ask a question about a constructor.
        {
            _first = first;
            _last = last;
        }

        #endregion

        #region Methods

        public IEnumerable GetSequence()
        {
            int count = 0;

            for (int i = _first; i <= _last; i++)
            {
                for (int j = 2; j < i; j++) 
                {
                    if (i % j != 0)
                    {
                        count += 1;
                    }
                }

                if (count == (i - 2))
                {
                    yield return i;
                }

                count = 0;
            }
        }

        #endregion

    }
}
