using System;

namespace EquationLib
{
    internal class Linear : Equation
    {
        #region Properties

        public override byte RootsCount
        {
            get
            {
                if (_factorA == 0 && _factorB == 0)
                {
                    throw new LinearEquationException("Every number is a solution." +
                            " In case factors A = 0 and B = 0.");
                }
                else if (_factorA == 0)
                {
                    throw new LinearEquationException("Not valid value! Factor 'A' != 0");
                }
                else
                {
                    _count = 1;
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

        public override double this[int index]
        {
            get
            {
                index -= 1;

                if (index >= RootsCount)
                {
                    throw new LinearEquationException($"There is only {RootsCount} root!");
                }

                _roots[0] = -_factorB / _factorA;

                return _roots[index];
            }
        }

        #endregion

        #region Constructor

        public Linear(double a, double b, 
                byte capacity = 1, byte count = 0)
            : base(a, b)
        {
            _roots = new double[capacity];
            _count = count;
        }

        #endregion
    }
}
