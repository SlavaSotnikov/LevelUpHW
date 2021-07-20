using System;

namespace Fraction
{
    class Fraction
    {
        #region Constants

        private int FACTOR = 10;
        private double ACCURACY = 0.0001;
        
        #endregion

        #region Private Data

        private int _numerator;
        private int _denominator = 1;

        #endregion

        public override string ToString()
        {
            return string.Format("{0}/{1}", _numerator, _denominator);
        }

        #region Operations

        public static Fraction operator +(Fraction num1, Fraction num2)
        {
            return new Fraction(num1._numerator * num2._denominator + num2._numerator
                    * num1._denominator, num1._denominator * num2._denominator);
        }

        public static Fraction operator -(Fraction num1, Fraction num2)
        {
            return num1 + new Fraction(-num2._numerator, num2._denominator);
        }

        public static Fraction operator *(Fraction num1, Fraction num2)
        {
            return new Fraction(num1._numerator * num2._numerator, 
                    num1._denominator * num2._denominator);
        }

        public static Fraction operator /(Fraction num1, Fraction num2)
        {
            return num1 * new Fraction(num2._denominator, num2._numerator);
        }

        public static Fraction operator ++(Fraction num1)
        {
            return new Fraction(num1._numerator + num1._denominator, num1._denominator);
        }

        public static Fraction operator --(Fraction num1)
        {
            return new Fraction(num1._numerator - num1._denominator, num1._denominator);
        }

        public static bool operator <(Fraction num1, Fraction num2)
        {
            GetCommonDenominator(num1, num2, out Fraction one, out Fraction two);

            return one._numerator < two._numerator;
        }

        public static bool operator >(Fraction num1, Fraction num2)
        {
            return !(num1 < num2);
        }

        public static bool operator <=(Fraction num1, Fraction num2)
        {
            GetCommonDenominator(num1, num2, out Fraction one, out Fraction two);

            return one._numerator <= two._numerator;
        }

        public static bool operator >=(Fraction num1, Fraction num2)
        {
            return !(num1 <= num2);
        }

        public static void GetCommonDenominator(Fraction num1, Fraction num2, 
                out Fraction one, out Fraction two)
        {
            one = new Fraction(num1._numerator * num2._denominator,
                    num1._denominator * num2._denominator);

            two = new Fraction(num1._denominator * num2._numerator,
                    num2._denominator * num1._denominator);
        }

        //     TODO: 0 - false, != 0 - true.
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

            if (_denominator != 0)
            {
                _denominator = denominator;
            }
        }

        public Fraction(Fraction source)
        {
            _numerator = source._numerator;
            _denominator = source._denominator;
        }

        //public Fraction(decimal number)    // TODO: Ask a question about three hares.
        //{
        //    int count = 1;

        //    while (number % 1 != 0)
        //    {
        //        number *= FACTOR;
        //        count *= FACTOR;
        //    }

        //    _numerator = (int)number;
        //    _denominator = count;
        //}

        //public Fraction(double number)
        //    : this((decimal)number)
        //{
        //}

        //public Fraction(float number)
        //    : this((decimal)number)
        //{
        //}

        public Fraction(double number)
        {
            double a = 1;
            double b = 1;

            while ((a / b) != number)
            {
                if ((a / b) < number)
                {
                    ++a;
                }
                else
                {
                    ++b;
                }
            }

            _numerator = (int)a;
            _denominator = (int)b;
        }

        //public Fraction(float number)
        //    : this((double)number)
        //{
        //}

        #endregion

        #region Normalize

        public int GetGCD()    // The Greatest common divisor. TODO: Make as static
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

        public void ApplyNormalize()    // TODO: Make private method.
        {
            int gcd = GetGCD();

            if (gcd > 1)
            {
                _numerator /= gcd;
                _denominator /= gcd;
            }
        }

        #endregion

    }
}
