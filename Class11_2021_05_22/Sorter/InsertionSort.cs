using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorter
{
    internal class InsertionSort : Sorter
    {
        #region MyRegion

        public override double[] Sort
        {
            get
            {
                int i = 0;
                int memory = 0;

                if (_time != null)
                {
                    _time.Invoke("Start", DateTime.Now.Millisecond);
                }

                while (i < _data.Length - 1)
                {
                    if (_data[i] > _data[i + 1])
                    {
                        double tmp = _data[i];
                        _data[i] = _data[i + 1];
                        _data[i + 1] = tmp;

                        if (i != 0)
                        {
                            i--;
                        }
                        else
                        {
                            memory++;
                            i = memory;
                        }
                    }
                    else
                    {
                        memory++;
                        i = memory;
                    }
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

        public InsertionSort(params double[] data)
            : base(data)
        {
        }

        #endregion
    }
}
