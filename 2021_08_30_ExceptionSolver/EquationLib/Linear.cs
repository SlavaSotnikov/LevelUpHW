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
                byte rootsCount = 0;

                if (A == 0 && B == 0)
                {
                    throw new LinearEquationException("Every number is a solution." +
                            " In case factors A = 0 and B = 0.", this);
                }
                else if (A == 0)
                {
                    throw new LinearEquationException("Not valid value! Factor 'A' != 0", this);
                }
                else
                {
                    rootsCount = 1;
                }

                return rootsCount;
            }
        }

        public override double this[int index]
        {
            get
            {
                double result = 0.0;

                index -= 1;

                if (index >= RootsCount)
                {
                    throw new LinearEquationException($"There is only {RootsCount} root!", this);
                }

                try
                {
                    result = - B / A;
                }
                catch (DivideByZeroException ex)
                {

                    throw new LinearEquationException("Dividing by zero!", ex, this);
                }

                return result;
            }
        }

        #endregion

        #region Constructor

        public Linear(double a, double b)
            : base(a, b)
        {
        }

        #endregion
    }
}
