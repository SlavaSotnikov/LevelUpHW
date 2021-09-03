using System;

namespace EquationLib
{
    public class Linear : Equation
    {
        #region Properties

        public override double X1
        {
            get
            {
                return _roots[0];
            }
        }

        public override byte Roots
        {
            get
            {
                return _count;
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
                throw new LinearEquationException("Every number is a solution. In case factors A = 0 and B = 0.");
            }
            else if (_factorA == 0)
            {
                throw new LinearEquationException("Not valid value! Factor 'A' != 0");
            }
            else
            {
                _roots[0] = -_factorB / _factorA;
                ++_count;
            }
        }

        #endregion

    }
}
