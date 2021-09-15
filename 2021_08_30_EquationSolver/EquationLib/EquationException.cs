using System;

namespace EquationLib
{
    public class EquationException : Exception  
    {
        protected Equation _source;    // TODO: Added Equation reference.

        public virtual string Describing { get; }

        public EquationException()
           : this($"Pay attention to factors!!!", (Equation)null)
        {
        }

        public EquationException(string message, Equation source)
            : base(message) 
        {
            _source = source;
        }

        public EquationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
