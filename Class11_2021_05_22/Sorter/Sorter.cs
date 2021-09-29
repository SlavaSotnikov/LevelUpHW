using System;

namespace Sorter
{
    internal abstract class Sorter
    {
        #region Private Data

        protected double[] _data;

        #endregion

        #region Properties

        public Speed TimeMeasure { get; set; }

        public Compare SwapIndexes { get; set; }

        protected abstract double[] SortedArray { get; }    // TODO: Method.

        #endregion

        public double[] Do()
        {
            TimeMeasure?.Invoke("Start", DateTime.Now.Millisecond);

            double[] result = SortedArray;

            TimeMeasure?.Invoke("Finish", DateTime.Now.Millisecond);

            return result;
        }

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
