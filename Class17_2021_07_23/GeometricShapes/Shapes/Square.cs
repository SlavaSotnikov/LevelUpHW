using System;

namespace GeometricShapes
{
    class Square : Point, IGeometrical
    {
        #region Private Data

        protected int _wide;

        #endregion

        #region Properties

        public override string Name
        {
            get
            {
                return _name;
            }
        }
        public int Wide
        {
            get
            {
                return _wide;
            }
        }

        #endregion

        #region Constructor

        public Square(Point one, int wide, string name = "Square")
            : base(one)
        {
            _wide = wide;

            _name = name;
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

        public override void Resize(double mult)
        {
            _wide = (int)Math.Round(mult * _wide);
        }
        #region IGeometrical

        public virtual double GetArea()
        {
            return _wide * _wide;
        }

        public virtual double GetPerimeter()
        {
            return _wide * 4;
        }

        #endregion
        #endregion
    }
}
