using System;
using System.Diagnostics;

namespace Sorter
{
    internal class SelectionSort : Sorter
    {
        private int _count = 0;

        #region Properties

        public override double[] Sort
        {
            get
            {
                One one = Time;

                int index = 0;

                for (int j = 1; j < _data.Length; j++)
                {
                    for (int i = j; i < _data.Length; i++)
                    {
                        if (_data[index] > _data[i])
                        {
                            double tmp = _data[index];
                            _data[index] = _data[i];
                            _data[i] = tmp;
                        }
                    }

                    index++;
                }

                return _data;
            }
        }

        #endregion

        #region Constructor

        public SelectionSort(params double[] data)
            : base(data)
        {
        }

        #endregion

        public void Time(int time)
        {
            ++_count;
            Console.WriteLine("{0}", time);
        }
    }
}
