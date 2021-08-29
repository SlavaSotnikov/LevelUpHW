using System;
using System.Collections;

namespace Generators
{
    class Prime : IGenerator
    {
        private int _first;
        private int _last;

        public Prime(int first, int last)
        {
            _first = first;
            _last = last;
        }

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
    }
}
