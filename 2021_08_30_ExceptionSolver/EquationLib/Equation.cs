using System;

namespace EquationLib
{
     public abstract class Equation
     {
        #region Properties

        public abstract double this[int index]
        {
            get;
        }
                            
        public double A { set; get; }

        public double B { set; get; }

        public abstract byte RootsCount { get; }

        #endregion

        #region Constructors

        public Equation(double a, double b)
        {
            A = a;
            B = b;
        }

        #endregion
     }
}
