using System;

namespace EquationLib
{
    class Quadratic : Equation
    {
        private double _factorC;
        private double _x2;

        public override double X1
        {
            get
            {
                return _x1;
            }
        }
        
        public double X2
        {
            get
            {
                return _x2;
            }
        }

        public Quadratic(double a, double b, double c)
            : base(a, b)
        {
            _factorC = c;
            _x2 = 0.0;
        }

        public override void Solve()
        {
            double discriminant = GetDiscriminant();

            if (discriminant > 0)
            {
                _x1 = (-_factorB + Math.Sqrt(discriminant)) / 2 * _factorA;
                _x2 = (-_factorB - Math.Sqrt(discriminant)) / 2 * _factorA;
            }
            else if (discriminant == 0)
            {
                _x1 = -_factorB / 2 * _factorA;
                _x2 = -_factorB / 2 * _factorA;    // TODO: How can I throw an Exception here?
            }
            else
            {
                throw new FieldAccessException("There are no roots in this equation!");
            }
        }

        public double GetDiscriminant()
        {
            if (_factorA == 0)
            {
                //throw new FactorArgumentException("Anappropriate value! The value 'a' mustn't be zero.");
            }

            return (_factorB * _factorB) - (4 * _factorA * _factorC);
        }
    }
}
