using System;
using System.Collections;

namespace Queue
{
    class QueueIterator : IEnumerator
    {
        Queue _source;

        public QueueIterator(Queue source)
        {
            _source = source;
        }

        public object Current
        {
            get
            {
                return _source[_source.Head];
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
