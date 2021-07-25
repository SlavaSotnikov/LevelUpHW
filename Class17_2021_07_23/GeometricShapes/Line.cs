using System;

namespace GeometricShapes
{
    class Line : Point
    {
        #region Private Data

        protected int _coordinatePoint2X;
        protected int _coordinatePoint2Y;

        #endregion

        #region Properties

        public int CoordinatePoint2X
        {
            get
            {
                return _coordinatePoint2X;
            }
            set
            {
                if (IsValidCoordinate(value))
                {
                    _coordinatePoint2X = value;
                }
            }
        }

        public int CoordinatePoint2Y
        {
            get
            {
                return _coordinatePoint2Y;
            }
            set
            {
                if (IsValidCoordinate(value))
                {
                    _coordinatePoint2Y = value;
                }
            }
        }

        #endregion

        #region Constructors

        public Line(int coordinatePoint1X, int coordinatePoint1Y,
                int coordinatePoint2X, int coordinatePoint2Y)
            : base(coordinatePoint1X, coordinatePoint1Y)
        {
            if (IsValidCoordinate(coordinatePoint2X))
            {
                _coordinatePoint2X = coordinatePoint2X;
            }

            if (IsValidCoordinate(coordinatePoint2Y))
            {
                _coordinatePoint2Y = coordinatePoint2Y;
            }
        }

        #endregion
    }
}
