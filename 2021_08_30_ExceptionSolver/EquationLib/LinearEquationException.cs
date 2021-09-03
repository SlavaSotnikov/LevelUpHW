using System;

namespace EquationLib
{
    public class LinearEquationException : EquationException
    {
        public LinearEquationException()
        {
        }

        public LinearEquationException(string message)
            : base(message)
        {
            this.HelpLink = "https://en.wikipedia.org/wiki/Linear_equation";
        }

        public LinearEquationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
