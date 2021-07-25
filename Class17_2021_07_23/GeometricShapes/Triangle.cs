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

        public Triangle(Point one, Point two, Point three)
            : base(one, two)
        {
            if (IsValidCoordinate(three.CoordinateX))
            {
                _coordinatePoint3X = three.CoordinateX;
            }

            if (IsValidCoordinate(three.CoordinateY))
            {
                _coordinatePoint3Y = three.CoordinateY;
            }

        }

        #endregion
    }
}
