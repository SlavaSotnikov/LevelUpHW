using System;

namespace GeometricShapes
{
    class Square : Point
    {
        #region Private Data

        protected int _side;

        #endregion

        #region Properties

        public int Side
        {
            get
            {
                return _side;
            }
        }

        #endregion

        #region Constructor

        public Square(Point one, int length)
            : base(one)
        {
            _side = length;
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
