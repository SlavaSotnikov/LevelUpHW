using System;

namespace GeometricShapes
{
    class Circle : Point, IGeometrical
    {
        #region Private Data

        protected int _radius;

        #endregion

        #region Properties

        public override string Name
        {
            get
            {
                return _name;
            }
        }
        public int Radius
        {
            get
            {
                return _radius;
            }

            set
            {
                if (IsValidRadius(value))
                {
                    _radius = value;
                }
            }
        }

        #endregion

        #region Constructors

        public Circle(Point source, int radius, string name = "Circle")
            : base(source)
        {
            if (IsValidRadius(radius))
            {
                _radius = radius;
            }

            _name = name;
        }

        #endregion

        #region Methods

        public void SetSize(int deltaRadius)
        {
            if (IsValidRadius(deltaRadius))
            {
                _radius += deltaRadius;
            }
        }

        public override Coordinate[] GetPoints()
        {
            Coordinate[] points = base.GetPoints();

            points[0].Radius = _radius;

            return points;
        }


        public virtual double GetArea()
        {
            return Math.PI * Math.Pow(_radius, 2);
        }

        public virtual double GetPerimeter()
        {
            return 2 * Math.PI * _radius;
        }

        public override void Resize(double mult)
        {
            _radius = (int)Math.Round(mult * _radius);
        }

        #endregion

        #region Radius Validator

        public bool IsValidRadius(int radius)
        {
            return !(radius > CoordinateY && radius > CoordinateX);
        }


        #endregion
    }
}
