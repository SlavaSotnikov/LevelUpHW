using System;

namespace GeometricShapes
{
    class Trapeze : Rectangle
    {
        private int _coordX;
        private int _coordY;

        public int CoordX
        {
            get 
            { 
                return _coordX;
            }
        }

        public int CoordY
        {
            get 
            {
                return _coordY; 
            }
        }

        public Trapeze(Point one, Point two, int side1, int side2)
            : base(one, side1, side2)
        {
            _coordX = two.CoordinateX;
            _coordY = two.CoordinateY;
        }
    }
}
