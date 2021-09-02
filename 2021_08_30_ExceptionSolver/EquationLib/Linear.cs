using System;

namespace EquationLib
{
    class Linear : Equation
    {
        public override double X1
        {
            get
            {
                return _x1;
            }
        }

        public Linear(double a, double b)
            : base(a, b)
        {
            _x1 = 0;
        }

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
                _x1 = -_factorB / _factorA;
            }
        }
    }
}
