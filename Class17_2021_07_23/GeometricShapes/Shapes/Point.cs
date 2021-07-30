using System;

namespace GeometricShapes
{
    class Point
    {
        #region Private Data

        protected int _coordinateX;
        protected int _coordinateY;

        #endregion

        #region Properties

        public int CoordinateX
        {
            get 
            {
                return _coordinateX;
            }
            set 
            {
                if (IsValidCoordinate(value))
                {
                    _coordinateX = value; 
                } 
            }
        }

        public int CoordinateY
        {
            get
            {
                return _coordinateY;
            }
            set 
            {
                if (IsValidCoordinate(value))
                {
                    _coordinateY = value; 
                }
            }
        }

        #endregion

        #region Constructors

        public Point(int coordinateX, int coordinateY)
        {
            if (IsValidCoordinate(coordinateX))
            {
                _coordinateX = coordinateX; 
            }

            if (IsValidCoordinate(coordinateY))
            {
                _coordinateY = coordinateY; 
            }
        }

        public Point(Point source)
            :this(source._coordinateX, source._coordinateY)
        {
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return string.Format("{0},{1}", _coordinateX, _coordinateY);
        }

        public void Move(int deltaX, int deltaY)
        {
            _coordinateX += deltaX;
            _coordinateY += deltaY;
        }

        public static bool IsValidCoordinate(int coordinate)
        {
            return coordinate >= 0;
        }

        #endregion
    }
}
