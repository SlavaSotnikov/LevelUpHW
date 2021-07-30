using System;

namespace GeometricShapes
{
    class Trapeze : Rectangle
    {
        #region Private Data

        private int _ground;

        #endregion

        #region Properties

        public int Ground
        {
            get 
            {
                return _ground; 
            }
        }

        #endregion

        #region Constructor

        public Trapeze(Point one, int side1, int side2, int ground)
            : base(one, side1, side2)
        {
            _ground = ground;
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
