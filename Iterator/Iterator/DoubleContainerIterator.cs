using System.Collections;

namespace Iterator
{
    class DoubleContainerIterator : IEnumerator
    {
        private DoubleContainer _source;
        private int _currentPosition = -1;

        public DoubleContainerIterator(DoubleContainer source)
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

            return _currentPosition < _source.Size;
        }

        public void Reset()
        {
            _currentPosition = -1;
        }
    }
}
