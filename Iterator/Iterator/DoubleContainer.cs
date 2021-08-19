using System.Collections;

namespace Iterator
{
    class DoubleContainer : IEnumerable
    {
         private int _size;
         private double[] _items;

         public DoubleContainer(double[] source)
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
         }

         public IEnumerator GetEnumerator()
         {
            return new DoubleContainerIterator(this);
         }
    }
}
