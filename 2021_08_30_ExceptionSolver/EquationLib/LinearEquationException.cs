using System;

namespace EquationLib
{
    public class LinearEquationException : EquationException
    {
        public override string Describing 
        { 
            get
            {
                string result = string.Empty;

                if (_source is Linear eq)
                {
                    result = $"Pay attention to factors:" +
                        $" A = {eq['A']}, B = {eq['B']}.";
                }

                return result;
            }
        }

        public LinearEquationException()
        {
        }

        public LinearEquationException(string message, Equation source)
            : base(message, source)
        {
            HelpLink = "https://en.wikipedia.org/wiki/Linear_equation";
        }

        public LinearEquationException(string message, Exception innerException, Equation source)
            : base(message, innerException)
        {
        }
    }
}
