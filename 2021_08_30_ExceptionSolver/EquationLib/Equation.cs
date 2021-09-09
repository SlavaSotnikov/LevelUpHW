namespace EquationLib
{
     public abstract class Equation
     {
        protected double[] _factors;

        #region Properties

        public abstract double this[char index]
        {
            get;
            set;
        }

        public abstract double this[int index]
        {
            get;
        }

        public abstract Roots RootsCount { get; }

        #endregion
     }
}
