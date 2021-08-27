using System;
using System.Collections;

namespace Container
{
    class ContainerIterator : IEnumerator
    {
        private IContainer _source;
        private int _currentPosition = -1;

        public ContainerIterator(IContainer source)
        {
            _source = source;
        }

        public object Current 
        {
            get
            {
                return _source[_currentPosition];
            }
        }

        public bool MoveNext()
        {
            ++_currentPosition;

            return (_currentPosition < _source.Size);
        }

        public void Reset()
        {
            _currentPosition = -1;
        }
    }
}
