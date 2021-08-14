using System;

namespace GeometricShapes
{
    class Trapeze : Rectangle
    {
        #region Private Data

        private int _ground;

        #endregion

        #region Properties

        public int Ground
        {
            get 
            {
                return _ground; 
            }
        }

        #endregion

        #region Constructor

        public Trapeze(Point one, int side1, int side2, int ground)
            : base(one, side1, side2)
        {
            _ground = ground;
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
            points.SetValue(new Coordinate(CoordinateX + _wide, CoordinateY + _ground), 2);
            points.SetValue(new Coordinate(CoordinateX, CoordinateY + _height), 3);
            points.SetValue(new Coordinate(CoordinateX, CoordinateY), 4);

            return points;
        }

        public override void Resize(double mult)
        {
            base.Resize(mult);

            _ground = (int)Math.Round(mult * _ground);
        }

        public override double GetArea()
        {
            return (_wide + _ground) / 2 * _height;
        }

        public override double GetPerimeter()
        {
            return _wide + _height + _ground + _height / Math.Sin(45);
        }

        #endregion
    }
}
