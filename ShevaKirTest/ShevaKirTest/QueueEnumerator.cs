using System.Collections;

namespace ShevaKirTest
{
    class QueueEnumerator : IEnumerator
    {
        private object[] _data;
        private int _first;
        private int _end;

        public QueueEnumerator(object[] data, int first, int end)
        {
            _data = data;
            _first = first - 1;
            _end = end;
        }

        public object Current
        {
            get
            {
                return _data[_first];
            }
        }

        public bool MoveNext()
        {
            bool result = false;

            if (_first != _end)
            {
                _first++;
                if (_first > _data.Length - 1)
                {
                    _first = 0;
                }
                result = true;
            }

            return result;
        }

        public void Reset()
        {
            _first = -1;
        }
    }
}
