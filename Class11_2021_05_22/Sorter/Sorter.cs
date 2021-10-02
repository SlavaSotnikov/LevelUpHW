using System;

namespace Sorter
{
    public delegate void Start(int x);
    public delegate void Finish(int x);

    public delegate void Indexes(int a, int b);
    public delegate void Swap(int a, int b);

    internal abstract class Sorter
    {
        #region Private Data

        private Start _doStart;
        private Finish _doFinish;

        public Indexes _theseIndexes;
        public Swap _indexes;

        protected double[] _data;

        #endregion

        public void SubscribeStart(Start source)
        {
            _doStart += source;
        }

        public void StartMeasureUnsubscribe(Start source)
        {
            _doStart -= source;
        }

        public void SubscribeFinish(Finish source)
        {
            _doFinish += source;
        }

        public void FinishMeasureUnSubscribe(Finish source)
        {
            _doFinish -= source;
        }

        public void SubscribeGetIndexes(Indexes source)
        {
            _theseIndexes += source;
        }

        public void SubscribeWatchSwap(Swap source)
        {
            _indexes += source;
        }

        #region Properties

        protected abstract double[] SortedArray();

        #endregion

        public double[] Do()
        {
            _doStart?.Invoke(DateTime.Now.Millisecond);

            double[] result = SortedArray();

            _doFinish?.Invoke(DateTime.Now.Millisecond);

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
