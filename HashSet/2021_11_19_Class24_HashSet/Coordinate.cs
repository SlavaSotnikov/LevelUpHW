using System;

namespace _2021_11_19_Class24_HashSet
{
    internal class Coordinate : IComparable<Coordinate>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", X, Y);
        }

        public int CompareTo(Coordinate other)
        {
            int result = 0;

            if (Y < other.Y)
            {
                result = -1;
            }

            if (Y > other.Y)
            {
                result = 1;
            }

            if (result == 0)
            {
                if (X < other.X)
                {
                    result = -1;
                }

                if (X > other.X)
                {
                    result = 1;
                }
            }

            return result;
        }
    }
}
