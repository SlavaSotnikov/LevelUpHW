using System;

namespace Sorter
{
    internal class Selection : Sorter
    {
        #region Member Functions

        protected override double[] SortedArray()
        {
            int index = 0;
            double tmp = 0.0;

            for (int j = 1; j < _data.Length; j++)
            {
                for (int i = j; i < _data.Length; i++)
                {
                    if (_data[index] > _data[i])
                    {
                        SwapIndexes?.Invoke(index, i);

                        tmp = _data[index];
                        _data[index] = _data[i];
                        _data[i] = tmp;
                    }
                }

                index++;
            }

            return _data;
        }

        #endregion

        #region Constructor

        public Selection(params double[] data)
            : base(data)
        {
        }

        #endregion

        
    }
}
