using System;

namespace EquationLib
{
    class Quadratic : Equation
    {
        #region Private Data

        private double _factorC;

        #endregion

        #region Properties

        public override byte RootsCount
        {
            get
            {
                return _count;
            }
        }

        public override double FactorA
        {
            set
            {
                _factorA = value;
            }
        }

        public override double FactorB
        {
            set
            {
                _factorB = value;
            }
        }

        public double FactorC
        {
            set
            {
                _factorC = value;
            }
        }

        public override double this[int index]
        {
            get
            {
                if (index - 1 >= RootsCount)
                {
                    throw new QuadraticEquationException($"There is only {RootsCount} root!");
                }

                return _roots[index - 1];
            }
        }

        #endregion

        #region Constructor

        public Quadratic(double a, double b, double c)
            : base(a, b)
        {
            _factorC = c;
            _roots = new double[2];
            _count = 0;
        }

        #endregion

        #region Member Functions

        public override void Solve()
        {
            double discriminant = GetDiscriminant();

            if (discriminant > 0)
            {
                _roots[0] = (-_factorB + Math.Sqrt(discriminant)) / 2 * _factorA;
                _roots[1] = (-_factorB - Math.Sqrt(discriminant)) / 2 * _factorA;

                _count = 2;
            }
            else if (discriminant == 0)
            {
                _roots[0] = -_factorB / 2 * _factorA;

                _count = 1;
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

        #endregion
    }
}
