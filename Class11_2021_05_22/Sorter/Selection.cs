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
                    if (IsMore(index, i))
                    {
                        tmp = _data[index];
                        _data[index] = _data[i];
                        _data[i] = tmp;

                        _indexes?.Invoke(this, new IndexEventArgs(index, i));
                    }
                }

                index++;
            }

            return _data;
        }

        private bool IsMore(int index, int i)
        {
            _theseIndexes?.Invoke(this, new IndexEventArgs(index, i));

            return _data[index] > _data[i];
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
