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

        public override string Name
        {
            get
            {
                return _name;
            }
        }

        #endregion

        #region Constructors

        public Rectangle(Point one, int side1, int height, string name = "Rectangle")
            : base(one, side1)
        {
            _height = height;
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

            points.SetValue(new Coordinate(CoordinateX + _wide, CoordinateY), 1);
            points.SetValue(new Coordinate(CoordinateX + _wide, CoordinateY + _height), 2);
            points.SetValue(new Coordinate(CoordinateX, CoordinateY + _height), 3);
            points.SetValue(new Coordinate(CoordinateX, CoordinateY), 4);

            return points;
        }

        public override void Resize(double mult)
        {
            base.Resize(mult);

            _height = (int)Math.Round(mult * _height);
        }

        public override double GetArea()
        {
            return _wide * _height;
        }

        public override double GetPerimeter()
        {
            return (_wide + _height) * 2;
        }

        #endregion
    }
}
