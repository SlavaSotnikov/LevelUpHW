using System;

namespace GeometricShapes
{
    class Square : Point
    {
        #region Private Data

        protected int _wide;

        #endregion

        #region Properties

        public int Wide
        {
            get
            {
                return _wide;
            }
        }

        #endregion

        #region Constructor

        public Square(Point one, int wide)
            : base(one)
        {
            _wide = wide;
        }

        #endregion

        #region Methods

        public override void Move(int deltaX, int deltaY)
        {
            base.Move(deltaX, deltaY);
        }

        public override Coordinate[] GetPoints()
        {
            Coordinate[] points = base.GetPoints();

            Array.Resize(ref points, points.Length + 4);

            points.SetValue(new Coordinate(CoordinateX + _wide, CoordinateY), 1);
            points.SetValue(new Coordinate(CoordinateX + _wide, CoordinateY + _wide), 2);
            points.SetValue(new Coordinate(CoordinateX, CoordinateY  + _wide), 3);
            points.SetValue(new Coordinate(CoordinateX, CoordinateY), 4);

            return points;
        }

        #endregion
    }
}
