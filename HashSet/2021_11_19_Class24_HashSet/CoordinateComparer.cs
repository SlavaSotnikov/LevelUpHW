using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021_11_19_Class24_HashSet
{
    internal class CoordinateComparer : IComparer<Coordinate>
    {
        public int Compare(Coordinate first, Coordinate second)
        {
            int result = first.Y.CompareTo(second.Y);

            if (result == 0)
            {
                result = first.X.CompareTo(second.X);
            }

            return result;
        }
    }
}
