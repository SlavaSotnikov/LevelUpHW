using System;
using System.Collections;

namespace Queue
{
    class QueueIterator : IEnumerator
    {
        private IContainer _source;
        private int _currentPosition;

        public QueueIterator(IContainer source)
        {
            _source = source;
            _currentPosition = source.Head - 1;
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

            bool result = true;

            if (_currentPosition == _source.Tale + 1)
            {
                result = false;
            }

            if (_currentPosition >= _source.Length)
            {
                _currentPosition = 0;
            }

            return result;
        }

        public void Reset()
        {
            _currentPosition = _source.Head;
        }
    }
}
