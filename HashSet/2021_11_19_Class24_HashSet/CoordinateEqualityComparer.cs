using System.Collections.Generic;

namespace _2021_11_19_Class24_HashSet
{
    internal class CoordinateEqualityComparer : IEqualityComparer<Coordinate>
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
