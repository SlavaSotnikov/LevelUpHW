using System;

namespace EquationLib
{
    public class LinearEquationException : EquationException
    {
        Equation _source;

        public LinearEquationException()
        {
        }

        public LinearEquationException(string message, Equation source)
            : base(message)
        {
            HelpLink = "https://en.wikipedia.org/wiki/Linear_equation";
            _source = source;
        }

        public LinearEquationException(string message, Exception innerException, Equation source)
            : base(message, innerException)
        {
            _source = source;
        }
    }
}
