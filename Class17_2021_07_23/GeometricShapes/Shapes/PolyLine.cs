using System;

namespace GeometricShapes
{
    class PolyLine : Line
    {
        #region Private Data

        private Point[] _points;

        #endregion

        #region Indexer

        public Point this[int index]
        {
            get
            {
                return new Point(_points[index]);
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
            }
        }

        #endregion
    }
}
