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
