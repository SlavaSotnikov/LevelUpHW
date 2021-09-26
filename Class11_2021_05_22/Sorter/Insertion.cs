using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorter
{
    internal class Insertion : Sorter
    {
        #region MyRegion

        public override double[] SortedArray
        {
            get
            {
                int i = 0;
                int memory = 0;

                if (TimeMeasure != null)
                {
                    TimeMeasure("Start", DateTime.Now.Millisecond);
                }

                while (i < _data.Length - 1)
                {
                    if (_data[i] > _data[i + 1])
                    {
                        if (SwapIndexes != null)
                        {
                            SwapIndexes(i, i + 1);
                        }

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

                if (TimeMeasure != null)
                {
                    TimeMeasure("Finish", DateTime.Now.Millisecond);
                }

                return _data;
            }
        }

        #endregion

        #region Constructor

        public Insertion(params double[] data)
            : base(data)
        {
        }

        #endregion
    }
}
