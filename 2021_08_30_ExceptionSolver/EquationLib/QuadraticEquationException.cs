using System;

namespace EquationLib
{
    public class QuadraticEquationException : EquationException
    {
        public override string Describing
        {
            get
            {
                string result = string.Empty;

                if (_source is Quadratic eq)
                {
                    result = $"Pay attention to factors:" +
                        $" A = {eq.A}, B = {eq.B}, C = {eq.C}.";
                }

                return result;
            }
        }

        public QuadraticEquationException()
        {
        }

        public QuadraticEquationException(string message, Equation source)
            : base(message, source)
        {
            HelpLink = "https://en.wikipedia.org/wiki/Linear_equation";
        }

        public QuadraticEquationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
