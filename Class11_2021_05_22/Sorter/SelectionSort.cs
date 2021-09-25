using System;
using System.Diagnostics;

namespace Sorter
{
    internal class SelectionSort : Sorter
    {
        #region Properties

        public override double[] Sort
        {
            get
            {
                if (_time != null)
                {
                    _time.Invoke("Start", DateTime.Now.Millisecond); 
                }

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

                if (_time != null)
                {
                    _time.Invoke("Finish", DateTime.Now.Millisecond); 
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

        
    }
}
