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

        public Line(Point first, Point second)
            : base(first)
        {
            if (IsValidCoordinate(second.CoordinateX))
            {
                _coordinatePoint2X = second.CoordinateX;
            }

            if (IsValidCoordinate(second.CoordinateY))
            {
                _coordinatePoint2Y = second.CoordinateY;
            }
        }

        #endregion
    }
}
