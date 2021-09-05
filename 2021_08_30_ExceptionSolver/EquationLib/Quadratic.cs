using System;

namespace EquationLib
{
    internal class Quadratic : Equation
    {
        #region Private Data

        private double _factorC;

        #endregion

        #region Properties

        public override byte RootsCount
        {
            get
            {
                if (_factorA == 0)
                {
                    throw new QuadraticEquationException("Invalid value! The value 'a' mustn't be zero.");
                }

                double discriminant = GetDiscriminant();

                if (discriminant > 0)
                {
                    _count = 2;
                }
                else if (discriminant == 0)
                {
                    _count = 1;
                }
                else
                {
                    throw new QuadraticEquationException("There are no roots in this equation!");
                }

                return _count;
            }
        }

        public override double FactorA
        {
            set
            {
                _factorA = value;
            }
            get
            {
                return _factorA;
            }
        }

        public override double FactorB
        {
            set
            {
                _factorB = value;
            }
            get
            {
                return _factorB;
            }
        }

        public double FactorC
        {
            set
            {
                _factorC = value;
            }
            get
            {
                return _factorC;
            }
        }

        public override double this[int index]
        {
            get
            {
                index -= 1;

                if (index >= RootsCount)
                {
                    throw new QuadraticEquationException($"There is only {RootsCount} root!");
                }

                if (index == 0)
                {
                    _roots[0] = (-_factorB + Math.Sqrt(GetDiscriminant())) / 2 * _factorA; 
                }

                if (index == 1)
                {
                    _roots[1] = (-_factorB - Math.Sqrt(GetDiscriminant())) / 2 * _factorA; 
                }

                return _roots[index];
            }
        }

        #endregion

        #region Constructor

        public Quadratic(double a, double b, double c,
                byte capacity = 2, byte count = 0)
            : base(a, b)
        {
            _factorC = c;
            _roots = new double[capacity];
            _count = count;
        }

        #endregion

        #region Member Functions

        private double GetDiscriminant()
        {
            return (_factorB * _factorB) - (4 * _factorA * _factorC);
        }

        #endregion
    }
}
