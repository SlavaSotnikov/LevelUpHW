using System;

namespace GeometricShapes
{
    class Point
    {
        #region Private Data

        protected int _x;
        protected int _y;

        #endregion

        #region Properties

        public int CoordinateX
        {
            get 
            {
                return _x;
            }
            set 
            {
                if (IsValidCoordinate(value))
                {
                    _x = value; 
                } 
            }
        }

        public int CoordinateY
        {
            get
            {
                return _y;
            }
            set 
            {
                if (IsValidCoordinate(value))
                {
                    _y = value; 
                }
            }
        }

        #endregion

        #region Constructors

        public Point(int coordinateX, int coordinateY)
        {
            if (IsValidCoordinate(coordinateX))
            {
                _x = coordinateX; 
            }

            if (IsValidCoordinate(coordinateY))
            {
                _y = coordinateY; 
            }
        }

        public Point(Point source)
            :this(source._x, source._y)
        {
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return string.Format("{0},{1}", _x, _y);
        }

        public void Move(int deltaX, int deltaY)
        {
            if (_x - deltaX >= 0)
            {
                _x += deltaX;
            }

            if (_y - deltaY >= 0)
            {
                _y += deltaY;
            }
        }

        public static bool IsValidCoordinate(int coordinate)
        {
            return coordinate >= 0;
        }

        #endregion
    }
}
