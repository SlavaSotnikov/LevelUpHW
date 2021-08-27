using System;
using System.Collections;

namespace Container
{
    class Container : IContainer, IEnumerable
    {
        private int _size;
        private object[] _items;

        public object this[int index]
        {
            get
            {
                return _items[index];
            }
            set
            {
                _items[index] = (int)value;
            }
        }

        public int Size
        {
            get
            {
                return _size;
            }
        }

        public Container(int capacity = 3)
        {
            _size = 0;
            _items = new object[capacity];
        }

        public void Add(object item)
        {
            _items[_size] = item;
            ++_size;
        }

        public IEnumerator GetEnumerator()
        {
            return new ContainerIterator(this);
        }
    }
}
