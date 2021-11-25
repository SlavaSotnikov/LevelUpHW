using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Comparer : IEqualityComparer<Coordinate>
    {
        public bool Equals(Coordinate first, Coordinate second)
        {
            bool result = (first.X == second.X) && (first.Y == second.Y);

            return result;
        }

        public int GetHashCode(Coordinate obj)
        {
            return (obj.Y << 8) + obj.X;
        }
    }
}
