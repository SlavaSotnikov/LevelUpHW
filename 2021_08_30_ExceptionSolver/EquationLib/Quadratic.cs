using System;

namespace EquationLib
{
    public class Quadratic : Equation
    {
        private double _factorC;

        public override double X1 
        {
            get 
            {
                return _roots[0];
            }
        }

        public double X2
        {
            get
            {
                if (_count == 1)
                {
                    throw new FieldAccessException("There is no second root!");
                }

                return _roots[1];
            }
        }

        public override byte Roots
        {
            get
            {
                return _count;
            }
        }

        public Quadratic(double a, double b, double c)
            : base(a, b)
        {
            _factorC = c;
            _roots = new double[2];
            _count = 0;
        }

        public override void Solve()
        {
            double discriminant = GetDiscriminant();

            if (discriminant > 0)
            {
                _roots[0] = (-_factorB + Math.Sqrt(discriminant)) / 2 * _factorA;
                ++_count;

                _roots[1] = (-_factorB - Math.Sqrt(discriminant)) / 2 * _factorA;
                ++_count;
            }
            else if (discriminant == 0)
            {
                _roots[0] = -_factorB / 2 * _factorA;
                ++_count;
            }
            else
            {
                throw new QuadraticEquationException("There are no roots in this equation!");
            }
        }

        public double GetDiscriminant()
        {
            if (_factorA == 0)
            {
                throw new QuadraticEquationException("Invalid value! The value 'a' mustn't be zero.");
            }

            return (_factorB * _factorB) - (4 * _factorA * _factorC);
        }
    }
}
