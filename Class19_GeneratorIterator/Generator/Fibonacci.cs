using System;
using System.Collections;

namespace Generator
{
    class Fibonacci : IGenerator, IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetSequence()
        {
            throw new NotImplementedException();
        }
    }
}
