using System;

namespace Interface
{
    class Z : IContainer
    {
        private int _size = 0;
        private double[] _items;

        public Z(double[] source)
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
