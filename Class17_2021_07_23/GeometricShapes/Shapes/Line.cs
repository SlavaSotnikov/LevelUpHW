using System;

namespace GeometricShapes
{
    class Line : Point
    {
        #region Private Data

        protected int _coordinate2X;
        protected int _coordinate2Y;

        #endregion

        #region Properties

        public int Coordinate2X
        {
            get 
            { 
                return _coordinate2X;
            }
            set 
            {
                if (IsValidCoordinate(value))
                {
                    _coordinate2X = value;
                }
            }
        }

        public int Coordinate2Y
        {
            get
            { 
                return _coordinate2Y;
            }
            set 
            {
                if (IsValidCoordinate(value))
                {
                    _coordinate2Y = value;
                }
            }
        }

        #endregion

        #region Constructors

        public Line(Point one, Point two)
            : base(one)
        {
            if (IsValidCoordinate(two.CoordinateX))
            {
                _coordinate2X = two.CoordinateX;
            }

            if (IsValidCoordinate(two.CoordinateY))
            {
                _coordinate2Y = two.CoordinateY;
            }
        }

        #endregion

        #region Methods

        public override void Move(int deltaX, int deltaY)
        {
            base.Move(deltaX, deltaY);

            if (IsValidDelta(_coordinate2X, deltaX))
            {
                _coordinate2X += deltaX; 
            }

            if (IsValidDelta(_coordinate2Y, deltaY))
            {
                _coordinate2Y += deltaY; 
            }
        }

        public static bool IsValidDelta(int coordinate, int delta)
        {
            return (coordinate + delta) > 0;
        }

        public override void Resize(double mult)
        {
            base.Resize(mult);
        }

        public override Coordinate[] GetPoints()
        {
            Coordinate[] points = base.GetPoints();

            Array.Resize(ref points, points.Length + 1);
            points.SetValue(new Coordinate(Coordinate2X, Coordinate2Y), 1);

            return points;
        }

        #endregion


    }
}
