using System;

namespace GeometricShapes
{
    class PolyLine : Line
    {
        #region Private Data

        private Point[] _points;
        private int _amountOfPoints = 2;

        #endregion

        #region Accessors

        public Point this[int index]
        {
            get
            {
                return new Point(_points[index]);
            }
        }

        public int AmountOfPoints
        {
            get 
            {
                return _amountOfPoints; 
            }
        }

        #endregion

        #region Constructor

        public PolyLine(Point one, Point two, params Point[] source)
            : base(one, two)
        {
            _points = new Point[source.Length];

            for (int i = 0; i < source.Length; i++)
            {
                _points[i] = new Point(source[i]);
                ++_amountOfPoints;
            }
        }

        #endregion

        #region Methods

        public new void Move(int deltaX, int deltaY)
        {
            base.Move(deltaX, deltaY);

            for (int i = 2; i < _amountOfPoints; i++)
            {
                _points[i-2].CoordinateX += deltaX;
                _points[i-2].CoordinateY += deltaY;
            }
        }

        #endregion
    }
}
