using System;
using System.Collections;

namespace ShevaKirTest
{
    class QueueObject
    {
        private const int INCREMENT = 5;
        private int _size = 5;
        private int _firstData = 0;
        private int _endData = -1;
        private int _countObject;
        private object[] _data;

        public QueueObject(int sizeQueue)
        {
            _data = new object[sizeQueue];
        }

        public void Put(object data)            // Figura
        {
            if (_countObject == _size)
            {
                _size += INCREMENT;
                Array.Resize(ref _data, _size);

                for (int i = _firstData; i + INCREMENT < _data.Length; i++)
                {
                    _data[i + INCREMENT] = _data[i];
                }
                _firstData += INCREMENT;
            }

            if (_endData == _size - 1)
            {
                _endData = -1;
            }

            _endData++;
            _data[_endData] = data;
            _countObject++;
        }

        public object GetData()
        {
            if (_countObject == 0)
            {
                return -1;
            }

            object data = _data[_firstData];

            _firstData++;
            _countObject--;

            if (_firstData == _size)
            {
                _firstData = 0;
            }

            return data;
        }

        public IEnumerator GetEnumerator()
        {
            return new QueueEnumerator(_data, _firstData, _endData);
        }
    }
}
