using System;

namespace EquationLib
{
    internal class Linear : Equation
    {
        #region Properties

        public override Roots RootsCount
        {
            get
            {
                Roots rootsCount = 0;

                if (_factors[0] == 0 && _factors[1] == 0)
                {
                    throw new LinearEquationException("Every number is a solution." +
                            " In case factors A = 0 and B = 0.", this);
                }
                else if (_factors[0] == 0)
                {
                    throw new LinearEquationException("Not valid value! Factor 'A' != 0", this);
                }
                else
                {
                    rootsCount = Roots.One;
                }

                return rootsCount;
            }
        }

        public override double this[char index]
        {
            get
            {
                char source = char.ToUpper(index);

                double result = 0.0;

                switch (source)
                {
                    case 'A':
                        result = _factors[0];
                        break;
                    case 'B':
                        result = _factors[1];
                        break;
                    default:
                        break;
                }

                return result;
            }

            set
            {
                char source = char.ToUpper(index);

                switch (source)
                {
                    case 'A':
                        _factors[0] = value;
                        break;
                    case 'B':
                        _factors[1] = value;
                        break;
                    default:
                        break;
                }
            }
        }

        public override double this[int index]
        {
            get
            {
                double result = 0.0;

                index -= 1;

                if (index >= (int)RootsCount)
                {
                    throw new LinearEquationException($"There is only {RootsCount} root!", this);
                }

                try
                {
                    result = -_factors[1] / _factors[0];
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
        {
            _factors = new double[2];

            _factors[0] = a; 
            _factors[1] = b;
        }

        #endregion
    }
}
