using System;

namespace GeometricShapes
{
    class Circle : Point
    {
        #region Private Data

        protected int _radius;

        #endregion

        #region Properties

        public int Radius
        {
            get
            {
                return _radius;
            }

            set
            {
                if (IsValidRadius(value))
                {
                    _radius = value;
                }
            }
        }

        #endregion

        #region Constructors

        public Circle(Point source, int radius)
            : base(source)
        {
            if (IsValidRadius(radius))
            {
                _radius = radius;
            }
        }

        #endregion

        #region Methods

        public void SetSize(int deltaRadius)
        {
            if (IsValidRadius(deltaRadius))
            {
                _radius += deltaRadius;
            }
        }

        public override Coordinate[] GetPoints()
        {
            Coordinate[] points = base.GetPoints();

            points[0].Radius = _radius;

            return points;
        }

        public override void Resize(int mult)
        {
            _radius *= mult;
        }

        #endregion

        #region Radius Validator

        public bool IsValidRadius(int radius)
        {
            return !(radius > CoordinateY && radius > CoordinateX);
        }

        #endregion
    }
}
