using System;

namespace EquationLib
{
     public abstract class Equation
    {
        #region Private Data

        protected double _factorA;
        protected double _factorB;
        protected double[] _roots;
        protected byte _count;


        #endregion

        #region Properties

        public abstract double X1 { get; }

        public abstract byte Roots { get; }

        #endregion

        #region Constructors

        public Equation(double a, double b)
        {
            _factorA = a;
            _factorB = b;
        }

        #endregion

        #region Member Functions

        public abstract void Solve();

        #endregion

        #region Static Functions

        public static Equation FindEquation(params int[] factor)
        {
            Equation result = null;

            if (factor.Length == 2)
            {
                result = new Linear(factor[0], factor[1]);
            }

            if (factor.Length == 3)
            {
                result = new Quadratic(factor[0], factor[1], factor[2]);
            }

            return result;
        }

        #endregion
    }
}
