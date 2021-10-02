using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorter
{
    internal class SpeedAnalizer
    {
        private int _amountOfCompare = 0;
        private int _amountOfSwaps = 0;

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

        public void CountCompare(int a, int b)    // TODO: Ask a question about subscribers' signature.
        {                                         // Is it necessary to add a specific delegate for Compare and Swaps separate UI?
            ++_amountOfCompare;
        }

        public void CountSwaps(int a, int b)
        {
            ++_amountOfSwaps;
        }
    }
}
