namespace GeometricShapes
{
    class Triangle : Line
    {
        #region Private Data

        protected int _coordinate3X;
        protected int _coordinate3Y;

        #endregion

        #region Properties

        public int Coordinate3X
        {
            get
            {
                return _coordinate3X;
            }
            set
            {
                if (IsValidCoordinate(value))
                {
                    _coordinate3X = value;
                }
            }
        }

        public int Coordinate3Y
        {
            get
            {
                return _coordinate3Y;
            }
            set
            {
                if (IsValidCoordinate(value))
                {
                    _coordinate3Y = value;
                }
            }
        }

        #endregion

        #region Constructors

        public Triangle(Point one, Point two, Point three)
            :base(one, two)
        {
            if (IsValidCoordinate(three.CoordinateX))
            {
                _coordinate3X = three.CoordinateX;
            }

            if (IsValidCoordinate(three.CoordinateY))
            {
                _coordinate3Y = three.CoordinateY;
            }
        }

        #endregion

        #region Methods

        public new void Move(int deltaX, int deltaY)
        {
            base.Move(deltaX, deltaY);

            if (IsValidDelta(_coordinate3X, deltaX))
            {
                _coordinate3X += deltaX;
            }

            if (IsValidDelta(_coordinate3Y, deltaY))
            {
                _coordinate3Y += deltaY;
            }
        }

        #endregion
    }
}
