using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Arcade_Game
{
    internal struct Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            bool result = false;

            if (obj is Coordinate source)
            {
                result = (X == source.X) && (Y == source.Y);
            }

            return result;
        }

        public override int GetHashCode()
        {
            return (Y << 8) + X;
        }
    }
}
