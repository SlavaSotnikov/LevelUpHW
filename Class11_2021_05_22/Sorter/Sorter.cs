using System;

namespace Sorter
{
    internal delegate void Start(object sender, TimeEventArgs e);
    internal delegate void Finish(object sender, TimeEventArgs e);

    internal delegate void Indexes(object sender, IndexEventArgs e);
    internal delegate void Swap(object sender, IndexEventArgs e);

    internal abstract class Sorter
    {
        #region Private Data

        private Start _doStart;
        private Finish _doFinish;

        public Indexes _theseIndexes;
        public Swap _indexes;

        protected double[] _data;

        #endregion

        #region Events

        public event Start StartSort
        {
            add
            {
                _doStart += value;
            }
            remove
            {
                _doStart -= value;
            }
        }

        public event Finish FinishSort
        {
            add
            {
                _doFinish += value;
            }
            remove
            {
                _doFinish -= value;
            }
        }

        public event Indexes CompareIndexes
        {
            add
            {
                _theseIndexes += value;
            }
            remove
            {
                _theseIndexes -= value;
            }
        }

        public event Swap SwapIndexes
        {
            add
            {
                _indexes += value;
            }
            remove
            {
                _indexes -= value;
            }
        }

        #endregion

        #region Properties

        protected abstract double[] SortedArray();

        #endregion

        public double[] Do()
        {
            _doStart?.Invoke(this ,new TimeEventArgs("Start", DateTime.Now.Millisecond));

            double[] result = SortedArray();

            _doFinish?.Invoke(this, new TimeEventArgs("Finish", DateTime.Now.Millisecond));

            return result;
        }

        #region Constructor

        protected Sorter(params double[] data)
        {
            _data = new double[data.Length];

            Array.Copy(data, _data, data.Length);
        }

        #endregion
    }
}
