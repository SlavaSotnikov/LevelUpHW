using System;

namespace Sorter
{
    public delegate void Speed(string s, int x);

    public delegate void Compare(int a, int b);

    internal abstract class Sorter
    {
        #region Private Data

        protected double[] _data;

        #endregion

        #region Properties

        public Speed TimeMeasure { get; set; }

        public Compare SwapIndexes { get; set; }

        public abstract double[] SortedArray { get; }

        #endregion

        #region Constructor

        protected Sorter(params double[] data)
        {
            _data = new double[data.Length];

            Array.Copy(data, _data, data.Length);
        }

        #endregion

        //public void TimeMeasure(Speed time)
        //{
        //    _time = time;
        //}
        
    }
}
