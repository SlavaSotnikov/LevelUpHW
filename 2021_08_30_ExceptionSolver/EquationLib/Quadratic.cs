using System;

namespace EquationLib
{
    internal class Quadratic : Equation
    {
        #region Properties

        public double C { get; set; }

        public override Roots RootsCount
        {
            get
            {
                Roots rootsCount = Roots.None;

                if (A == 0)
                {
                    throw new QuadraticEquationException("Invalid value!" +
                            " The value 'a' mustn't be zero.", this);
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
                    result = (-B + Math.Sqrt(GetDiscriminant())) / 2 * A; 
                }

                if (index == 1)
                {
                    result = (-B - Math.Sqrt(GetDiscriminant())) / 2 * A; 
                }

                return result;
            }
        }

        #endregion

        #region Constructor

        public Quadratic(double a, double b, double c)
            : base(a, b)
        {
            C = c;
        }

        #endregion

        #region Member Functions

        private double GetDiscriminant()
        {
            return (B * B) - (4 * A * B);
        }

        #endregion
    }
}
