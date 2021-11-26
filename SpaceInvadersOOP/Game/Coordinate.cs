using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Coordinate(Coordinate source)
        {
            X = source.X;
            Y = source.Y;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //public int CompareTo(Coordinate other)
        //{
        //    int result = 0;

        //    if (Y < other.Y)
        //    {
        //        result = -1;
        //    }

        //    if (Y > other.Y)
        //    {
        //        result = 1;
        //    }

        //    if (result == 0)
        //    {
        //        if (X < other.X)
        //        {
        //            result = -1;
        //        }

        //        if (X > other.X)
        //        {
        //            result = 1;
        //        }
        //    }

        //    return result;
        //}
    }
}
