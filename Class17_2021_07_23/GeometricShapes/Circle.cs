namespace GeometricShapes
{
    class Circle : Point
    {
        #region Private Data

        private int _radius;

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

        #region Radius Validator

        public bool IsValidRadius(int radius)
        {
            return !(radius > CoordinateY && radius > CoordinateX);
        }

        #endregion
    }
}
