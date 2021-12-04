using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal struct Coord
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Coord(Coord source)
        {
            X = source.X;
            Y = source.Y;
        }

        public override bool Equals(object obj)
        {
            bool result = false;

            if (obj is Coord source)
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
