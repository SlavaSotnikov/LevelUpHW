using System;

namespace GeometricShapes
{
    class PolyLine : Line
    {
        #region Private Data

        private Point[] _points;

        #endregion

        #region Constructor

        public PolyLine(Point one, Point two, params Point[] source)
            : base(one, two)
        {
            _points = new Point[source.Length];

            for (int i = 0; i < source.Length; i++)
            {
                _points[i] = new Point(source[i]);
            }
        }

        #endregion

        #region Methods

        public override void Move(int deltaX, int deltaY)
        {
            base.Move(deltaX, deltaY);

            for (int i = 0; i < _points.Length; i++)
            {
                _points[i].CoordinateX += deltaX;
                _points[i].CoordinateY += deltaY;
            }
        }

        public override Coordinate[] GetPoints()
        {
            Coordinate[] points = base.GetPoints();

            Array.Resize(ref points, points.Length + _points.Length);

            for (int i = 2; i < points.Length; i++)
            {
                points[i] = new Coordinate(_points[i - 2].CoordinateX, _points[i - 2].CoordinateY);
            }

            return points;
        }

        public override void Resize(double mult)
        {
        }

        #endregion
    }
}
