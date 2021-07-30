using System;

namespace GeometricShapes
{
    class Square : Point
    {
        #region Private Data

        protected int _wide;

        #endregion

        #region Properties

        public int Wide
        {
            get
            {
                return _wide;
            }
        }

        #endregion

        #region Constructor

        public Square(Point one, int wide)
            : base(one)
        {
            _wide = wide;
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
