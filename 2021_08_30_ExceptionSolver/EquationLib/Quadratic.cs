using System;

namespace EquationLib
{
    internal class Quadratic : Equation
    {
        #region Properties

        public override Roots RootsCount
        {
            get
            {
                Roots rootsCount = Roots.None;

                if (_factors[0] == 0)
                {
                    throw new QuadraticEquationException("Invalid value!" +
                            " The value 'A' mustn't be zero.", this);
                }

                double discriminant = GetDiscriminant();

                if (discriminant > 0)
                {
                    rootsCount = Roots.Two;
                }
                else if (discriminant == 0)
                {
                    rootsCount = Roots.One;
                }
                else
                {
                    throw new QuadraticEquationException("There are no roots in this equation!", this);
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
                    case 'C':
                        result = _factors[2];
                        break;
                    default:
                        throw new QuadraticEquationException($"There is no {source} factor!", this);
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
                    case 'C':
                        _factors[2] = value;
                        break;
                    default:
                        throw new QuadraticEquationException($"There is no {source} factor!", this);
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
                    throw new QuadraticEquationException($"There is only {RootsCount} root!", this);
                }

                if (index == 0)
                {
                    result = (-_factors[1] + Math.Sqrt(GetDiscriminant())) / 2 * _factors[0]; 
                }

                if (index == 1)
                {
                    result = (-_factors[1] - Math.Sqrt(GetDiscriminant())) / 2 * _factors[0]; 
                }

                return result;
            }
        }

        #endregion

        #region Constructor

        public Quadratic(double a, double b, double c)
        {
            _factors = new double[3];

            _factors[0] = a;
            _factors[1] = b;
            _factors[2] = c;
        }

        #endregion

        #region Member Functions

        private double GetDiscriminant()
        {
            return (_factors[1] * _factors[1])
                    - (4 * _factors[0] * _factors[2]);
        }

        #endregion
    }
}
