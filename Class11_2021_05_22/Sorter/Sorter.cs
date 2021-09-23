using System;

namespace Sorter
{
    public delegate void One(int x);

    public delegate int Two(int a, int b);

    internal abstract class Sorter
    {
        #region Private Data

        protected double[] _data;

        #endregion

        #region Properties

        public abstract double[] Sort { get; }

        #endregion

        #region Constructor

        protected Sorter(params double[] data)
        {
            _data = new double[data.Length];

            Array.Copy(data, _data, data.Length);
        }

        #endregion
    }
}
