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

        #region Methods

        public void SetSecondRadius(int deltaRadius)
        {
            if (IsValidRadius(deltaRadius))
            {
                _secondRadius += deltaRadius;
            }
        }

        public override void Move(int deltaX, int deltaY)
        {
            base.Move(deltaX, deltaY);
        }

        public override Coordinate[] GetPoints()
        {
            Coordinate[] points = base.GetPoints();

            points.SetValue(new Coordinate(_secondRadius, _secondRadius), 1);

            return points;
        }

        public override void Resize(int mult)
        {
            base.Resize(mult);

            _secondRadius *= mult;
        }

        #endregion
    }
}
