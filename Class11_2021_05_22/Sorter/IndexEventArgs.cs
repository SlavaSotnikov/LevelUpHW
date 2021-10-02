using System;

namespace Sorter
{
    public class IndexEventArgs : EventArgs
    {
        public int Index1 { get; private set; }
        public int Index2 { get; private set; }

        public IndexEventArgs(int num1, int num2)
        {
            Index1 = num1;
            Index2 = num2;
        }
    }
}
