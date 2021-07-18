using System;

namespace Fraction
{
    class Fraction
    {
        #region Private Data

        private int _numerator;
        private int _denominator;

        #endregion

        public override string ToString()
        {
            return string.Format("{0}/{1}", _numerator, _denominator);
        }

        #region Constructors

        public Fraction(int numerator, int denominator = 1)
        {
            _numerator = numerator;
            _denominator = denominator;
        }

        public Fraction(int numerator)
        {
            _numerator = numerator;
        }

        public Fraction(float number)
        {
            int count = 0;

            while (number % 1 != 0)
            {
                number *= 10;
                ++count;
            }

            _numerator = (int)number;
            _denominator = Convert.ToInt32(Math.Pow(10, count));
        }

        public Fraction(double number)
            : this((float)number)
        {
        }

        #endregion

        #region Normalize

        public int GetGCD()    // The Greatest common divisor.
        {
            int num1 = _numerator;
            int num2 = _denominator;

            while (num1 != num2)
            {
                if (num1 > num2)
                {
                    num1 -= num2;
                }
                else
                {
                    num2 -= num1;
                }
            }

            return num1;
        }

        public void GetNormalize()
        {
            int GCD = GetGCD();

            _numerator /= GCD;
            _denominator /= GCD;
        }

        #endregion

    }
}
