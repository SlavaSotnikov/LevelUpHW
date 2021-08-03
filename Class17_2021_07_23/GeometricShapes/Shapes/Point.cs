using System;

namespace GeometricShapes
{
    class Point : Figure
    {
        #region Constructors

        public Point(int coordinateX, int coordinateY)
        {
            if (IsValidCoordinate(coordinateX))
            {
                _point.X = coordinateX; 
            }

            if (IsValidCoordinate(coordinateY))
            {
                _point.Y = coordinateY; 
            }
        }

        public Point(Point source)
            :this(source._point.X, source._point.Y)
        {
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return string.Format("{0},{1}", _point.X, _point.Y);
        }

        public override void Move(int deltaX, int deltaY)
        {
            _point.X += deltaX;
            _point.Y += deltaY;
        }

        public static bool IsValidCoordinate(int coordinate)
        {
            return coordinate >= 0;
        }

        public override Coordinate[] GetPoints()
        {
            Coordinate[] result = new Coordinate[1];

            result[0] = new Coordinate(_point.X, _point.Y);

            return result;
        }

        public override void Resize(int mult)
        {
        }

        #endregion
    }
}
