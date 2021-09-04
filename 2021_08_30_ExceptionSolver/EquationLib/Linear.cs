using System;

namespace EquationLib
{
    class Linear : Equation
    {
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

        public override double this[int index]
        {
            get
            {
                if (index - 1 >= RootsCount)
                {
                    throw new LinearEquationException($"There is only {RootsCount} root!");
                }

                return _roots[index - 1];
            }
        }

        #endregion

        #region Constructor

        public Linear(double a, double b)
            : base(a, b)
        {
            _roots = new double[1];
            _count = 0;
        }

        #endregion

        #region Member Functions

        public override void Solve()
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
                _roots[0] = -_factorB / _factorA;
                _count = 1;
            }
        }

        #endregion

    }
}
