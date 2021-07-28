using System;

namespace GeometricShapes
{
    class Ellipse : Circle
    {
        #region Private Data

        private int _secondRadius;

        #endregion

        #region Properties

        public int SecondRadius
        {
            get
            {
                return _secondRadius;
            }
        }

        #endregion

        #region Constructors

        public Ellipse(Point one, int radius, int secondRadius)
            : base(one, radius)
        {
            if (IsValidRadius(secondRadius))
            {
                _secondRadius = secondRadius;
            }
        }

        #endregion

        #region MyRegion

        public void SetSecondRadius(int deltaRadius)
        {
            if (IsValidRadius(deltaRadius))
            {
                _secondRadius += deltaRadius;
            }
        }

        #endregion
    }
}
