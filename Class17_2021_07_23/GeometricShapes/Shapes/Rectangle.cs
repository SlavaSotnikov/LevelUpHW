using System;

namespace GeometricShapes
{
    class Rectangle : Square
    {
        #region Private Data

        protected int _height;

        public int Height
        {
            get 
            {
                return _height; 
            }
        }

        #endregion

        #region Constructors

        public Rectangle(Point one, int side1, int height)
            : base(one, side1)
        {
            _height = height;
        }

        #endregion

        #region Methods

        public new void Move(int deltaX, int deltaY)
        {
            base.Move(deltaX, deltaY);
        }

        #endregion
    }
}
