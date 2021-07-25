namespace GeometricShapes
{
    class Triangle : Line
    {
        #region Private Data

        protected int _coordinatePoint3X;
        protected int _coordinatePoint3Y;

        #endregion

        #region Properties

        public int CoordinatePoint3X
        {
            get
            {
                return _coordinatePoint3X;
            }
            set
            {
                if (IsValidCoordinate(value))
                {
                    _coordinatePoint3X = value;
                }
            }
        }

        public int CoordinatePoint3Y
        {
            get
            {
                return _coordinatePoint3Y;
            }
            set
            {
                if (IsValidCoordinate(value))
                {
                    _coordinatePoint3Y = value;
                }
            }
        }

        #endregion

        #region Constructors

        public Triangle(int coordinatePoint1X, int coordinatePoint1Y,
                int coordinatePoint2X, int coordinatePoint2Y, int coordinatePoint3X, int coordinatePoint3Y)
            : base(coordinatePoint1X, coordinatePoint1Y, coordinatePoint2X, coordinatePoint2Y)
        {
            _coordinatePoint3X = coordinatePoint3X;
            _coordinatePoint3Y = coordinatePoint3Y;
        }

        #endregion
    }
}
