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

        public static Fraction operator +(Fraction num1, Fraction num2)
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
            int addNumerator1 = num1._numerator * num2._denominator;
            int addNumerator2 = num1._denominator * num2._numerator;

            int multDenominator1 = num1._denominator * num2._denominator;

            int numerator = addNumerator1 + addNumerator2;

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
            int addNumerator1 = num1._numerator * num2._denominator;
            int addNumerator2 = num1._denominator * num2._numerator;

            int multDenominator1 = num1._denominator * num2._denominator;

            int numerator = addNumerator1 - addNumerator2;

            return new Fraction(numerator, multDenominator1);

        }

        public static Fraction operator *(Fraction num1, Fraction num2)
        {
            int multNumerator1 = num1._numerator * num2._numerator;
            int multNumerator2 = num1._denominator * num2._denominator;

            return new Fraction(multNumerator1, multNumerator2);
        }

        public static Fraction operator /(Fraction num1, Fraction num2)
        {
            int multNumerator = num1._numerator * num2._denominator;
            int multDenominator = num1._denominator * num2._numerator;

            return new Fraction(multDenominator, multNumerator);
        }

        public static Fraction operator ++(Fraction num1)
        {
            Fraction num2 = new Fraction(1, 1);
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

        public static Fraction operator --(Fraction num1)
        {
            Fraction num2 = new Fraction(1, 1);
            Fraction result;

            if (num1._denominator != num2._denominator)
            {
                result = SubtractDifferentDenominators(num1, num2);
            }
            else
            {
                int diff = num1._numerator - num2._numerator;

                result = new Fraction(diff, num1._denominator);
            }

            return result;
        }

        public static bool operator <(Fraction num1, Fraction num2)
        {
            bool result = false;

            if (num1._denominator != num2._denominator)
            {
                result = CompareDifferentDenominators(num1, num2);
            }
            else
            {
                result = num1._numerator < num2._numerator;
            }

            return result;
        }

        public static bool operator <=(Fraction num1, Fraction num2)
        {
            bool result = false;

            if (num1._denominator != num2._denominator)
            {
                result = CompareDifferentDenominators(num1, num2);
            }
            else
            {
                result = num1._numerator <= num2._numerator;
            }

            return result;
        }

        public static bool operator >=(Fraction num1, Fraction num2)
        {
            bool result = false;

            if (num1._denominator != num2._denominator)
            {
                result = CompareDifferent(num1, num2);
            }
            else
            {
                result = num1._numerator >= num2._numerator;
            }

            return result;
        }

        public static bool CompareDifferentDenominators(Fraction num1, Fraction num2)
        {
            bool result = false;

            int addNumerator1 = num1._numerator * num2._denominator;
            int addNumerator2 = num1._denominator * num2._numerator;

            int multDenominator1 = num1._denominator * num2._denominator;
            int multDenominator2 = num2._denominator * num1._denominator;

            Fraction one = new Fraction(addNumerator1, multDenominator1);
            Fraction two = new Fraction(addNumerator2, multDenominator2);

            if (one._numerator <= two._numerator)
            {
                result = true;
            }

            return result;
        }

        public static bool operator >(Fraction num1, Fraction num2)
        {
            bool result = false;

            if (num1._denominator != num2._denominator)
            {
                result = CompareDifferent(num1, num2);
            }
            else
            {
                result = num1._numerator > num2._numerator;
            }

            return result;
        }

        public static bool CompareDifferent(Fraction num1, Fraction num2)
        {
            bool result = false;

            int addNumerator1 = num1._numerator * num2._denominator;
            int addNumerator2 = num1._denominator * num2._numerator;

            int multDenominator1 = num1._denominator * num2._denominator;
            int multDenominator2 = num2._denominator * num1._denominator;

            Fraction one = new Fraction(addNumerator1, multDenominator1);
            Fraction two = new Fraction(addNumerator2, multDenominator2);

            if (one._numerator >= two._numerator)
            {
                result = true;
            }

            return result;
        }

        //public static Fraction operator |(Fraction num1, Fraction num2)
        //{
            
        //}

        //public static Fraction operator &(Fraction num1, Fraction num2)
        //{

        //}

        //public static Fraction operator ^(Fraction num1, Fraction num2)
        //{

        //}

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

        public void ApplyNormalize()
        {
            int GCD = GetGCD();

            _numerator /= GCD;
            _denominator /= GCD;
        }

        #endregion

    }
}
