using System;

namespace GeometricShapes
{
    class Rectangle : Square
    {
        #region Private Data

         int _side2;

        public int Side2
        {
            get 
            {
                return _side2; 
            }
        }

        #endregion

        #region Constructors

        public Rectangle(Point one, int side1, int side2)
            : base(one, side1)
        {
            _side2 = side2;
        }

        #endregion
    }
}
