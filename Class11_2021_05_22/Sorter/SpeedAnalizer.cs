namespace Sorter
{
    internal class SpeedAnalizer
    {
        private int _amountOfCompare;
        private int _amountOfSwaps;

        public SpeedAnalizer()
        {
            _amountOfCompare = 0;
            _amountOfSwaps = 0;
        }

        public int Compare 
        { 
            get
            {
                return _amountOfCompare;
            }
        }

        public int Swaps
        {
            get
            {
                return _amountOfSwaps;
            }
        }

        public void CountCompare(object sender, IndexEventArgs e) 
        {     
            ++_amountOfCompare;
        }

        public void CountSwaps(object sender, IndexEventArgs e)
        {
            ++_amountOfSwaps;
        }
    }
}
