using System;
using System.Collections;

namespace GeometricShapes
{
    class Iterator : IEnumerator
    {
        private Picture _source;
        private int _currerntPosition = -1;

        public Iterator(Picture source)
        {
            _source = source;
        }

        public object Current 
        {
            get 
            {
                return _source[_currerntPosition].Name;
            }
        }

        public string Name
        {
            get
            {
                return _source.Name;
            }
        }

        public bool MoveNext()
        {
            ++_currerntPosition;

            return _currerntPosition < _source.Amount; 
        }

        public void Reset()
        {
            _currerntPosition = -1;
        }
    }
}
