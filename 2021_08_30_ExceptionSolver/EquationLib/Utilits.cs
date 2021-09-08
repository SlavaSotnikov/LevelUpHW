using System;

namespace EquationLib
{
    public class Utilits
    {
        public static Equation FindEquation(params double[] factor)
        {
            Equation result = null;

            if (factor.Length == 2)
            {
                result = new Linear(factor[0], factor[1]);
            }

            if (factor.Length == 3)
            {
                result = new Quadratic(factor[0], factor[1], factor[2]);
            }

            return result;
        }
    }
}
