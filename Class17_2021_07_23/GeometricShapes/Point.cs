using System;

namespace GeometricShapes
{
    class Point
    {
        #region Private Data

        protected int _coordinatePoint1X;
        protected int _coordinatePoint1Y;

        #endregion

        #region Properties

        public int CoordinateX
        {
            get 
            {
                return _coordinatePoint1X;
            }
            set 
            {
                if (IsValidCoordinate(value))
                {
                    _coordinatePoint1X = value; 
                } 
            }
        }

        public int CoordinateY
        {
            get
            {
                return _coordinatePoint1Y;
            }
            set 
            {
                if (IsValidCoordinate(value))
                {
                    _coordinatePoint1Y = value; 
                }
            }
        }

        #endregion

        #region Constructors

        public Point(int coordinateX, int coordinateY)
        {
            if (IsValidCoordinate(coordinateX))
            {
                _coordinatePoint1X = coordinateX; 
            }

            if (IsValidCoordinate(coordinateY))
            {
                _coordinatePoint1Y = coordinateY; 
            }
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return string.Format("{0},{1}", _coordinatePoint1X, _coordinatePoint1Y);
        }

        public void Move(int deltaX, int deltaY)
        {
            if (IsValidCoordinate(deltaX))
            {
                _coordinatePoint1X += deltaX;
            }

            if (IsValidCoordinate(deltaY))
            {
                _coordinatePoint1Y += deltaY;
            }
        }

        public static bool IsValidCoordinate(int coordinate)
        {
            return coordinate >= 0;
        }

        #endregion
    }
}
