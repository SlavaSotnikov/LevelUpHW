using System;

namespace EquationLib
{
    public class QuadraticEquationException : EquationException
    {
        Quadratic _source;

        public QuadraticEquationException()
        {
        }

        public QuadraticEquationException(string message)
            : base(message)
        {
            HelpLink = "https://en.wikipedia.org/wiki/Linear_equation";
        }

        public QuadraticEquationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
