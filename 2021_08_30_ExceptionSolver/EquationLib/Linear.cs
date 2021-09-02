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

        public Linear(int a, int b)
            : base(a, b)
        {
        }

        public override void Run()
        {
            if (_factorA == 0)
            {

            }
            else if (_factorA == 0 && _factorB == 0)
            {

            }
            else
            {
                _x1 = -_factorB / _factorA;
            }
        }
    }
}
