using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class CoordinateComparer : IEqualityComparer<Coordinate>
    {
        public bool Equals(Coordinate first, Coordinate second)
        {
            return (first.X == second.X) && (first.Y == second.Y);
        }

        public int GetHashCode(Coordinate obj)
        {
            return (obj.Y << 8) + obj.X;
        }
    }
}
