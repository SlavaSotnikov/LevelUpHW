using System;

namespace EquationLib
{
    public abstract class Equation
    {
        #region Private Data

        protected int _factorA;
        protected int _factorB;
        protected double _x1;

        #endregion

        #region Properties

        public abstract double X1 { get; }

        #endregion

        #region Constructors

        public Equation(int a, int b)
        {
            _factorA = a;
            _factorB = b;
        }

        #endregion

        #region Member Functions

        public abstract void Run();

        #endregion

        #region Static Functions

        public static Equation SolveEquation(params int[] factor)
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
