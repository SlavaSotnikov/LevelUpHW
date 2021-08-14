using System;

namespace Interface
{
    struct V : IContainer
    {
        private int _size;
        private double[] _items;

        public V(double[] source)
        {
            _items = (double[])source.Clone();
            _size = source.Length;
        }

        public double this[int index]
        {
            get
            {
                return _items[index];
            }
            set
            {
                _items[index] = value;
            }
        }

        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }
    }
}
