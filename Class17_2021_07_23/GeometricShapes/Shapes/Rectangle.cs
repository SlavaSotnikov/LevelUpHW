using System;

namespace GeometricShapes
{
    class Rectangle : Square
    {
        #region Private Data

        protected int _height;

        public int Height
        {
            get 
            {
                return _height; 
            }
        }

        #endregion

        #region Constructors

        public Rectangle(Point one, int side1, int height)
            : base(one, side1)
        {
            _height = height;
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

            points.SetValue(new Coordinate(CoordinateX + _wide, CoordinateY), 1);
            points.SetValue(new Coordinate(CoordinateX + _wide, CoordinateY + _height), 2);
            points.SetValue(new Coordinate(CoordinateX, CoordinateY + _height), 3);
            points.SetValue(new Coordinate(CoordinateX, CoordinateY), 4);

            return points;
        }

        public override void Resize(int mult)
        {
            base.Resize(mult);

            _height *= mult;
        }

        #endregion
    }
}
