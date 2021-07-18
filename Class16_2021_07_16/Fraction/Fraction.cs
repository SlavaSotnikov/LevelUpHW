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
        #region Operations

        public static Fraction operator+(Fraction num1, Fraction num2)
        {
            Fraction result;

            if (num1._denominator != num2._denominator)
            {
                result = AddDifferentDenominators(num1, num2);
            }
            else
            {
                int sum = num1._numerator + num2._numerator;

                result = new Fraction(sum, num1._denominator);
            }

            return result;
        }

        public static Fraction AddDifferentDenominators(Fraction num1, Fraction num2)
        {
            int multNumerator1 = num1._numerator * num2._denominator;
            int multNumerator2 = num1._denominator * num2._numerator;

            int multDenominator1 = num1._denominator * num2._denominator;

            int numerator = multNumerator1 + multNumerator2;

            return new Fraction(numerator, multDenominator1);

        }

        public static Fraction operator -(Fraction num1, Fraction num2)
        {
            Fraction result;

            if (num1._denominator != num2._denominator)
            {
                result = SubtractDifferentDenominators(num1, num2);
            }
            else
            {
                int sum = num1._numerator - num2._numerator;

                result = new Fraction(sum, num1._denominator);
            }

            return result;
        }

        public static Fraction SubtractDifferentDenominators(Fraction num1, Fraction num2)
        {
            int multNumerator1 = num1._numerator * num2._denominator;
            int multNumerator2 = num1._denominator * num2._numerator;

            int multDenominator1 = num1._denominator * num2._denominator;

            int numerator = multNumerator1 - multNumerator2;

            return new Fraction(numerator, multDenominator1);

        }

        #endregion
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

        public Fraction(double number)
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

        public Fraction(float number)
            : this((double)number)
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
