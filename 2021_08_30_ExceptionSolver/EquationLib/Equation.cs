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

        public abstract double this[int index]
        {
            get;
        }

        public abstract double FactorA { set; get; }
        public abstract double FactorB { set; get; }

        public abstract byte RootsCount { get; }

        #endregion

        #region Constructors

        public Equation(double a, double b)
        {
            _factorA = a;
            _factorB = b;
        }

        #endregion
     }
}
