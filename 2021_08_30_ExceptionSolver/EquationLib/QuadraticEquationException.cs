using System;

namespace EquationLib
{
    class QuadraticEquationException : EquationException
    {
        public QuadraticEquationException()
        {
        }

        public QuadraticEquationException(string message)
            : base(message)
        {
            this.HelpLink = "https://en.wikipedia.org/wiki/Linear_equation";
        }

        public QuadraticEquationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
