using System;
using System.Numerics;

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


        #region Properties

        public int Numerator
        {
            get
            {
                return _numerator;
            }
        }

        public int Denonminator
        {
            get 
            { 
                return _denominator;
            }
        }

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

        public static Fraction operator +(Fraction num1, AnotherFraction num2)
        {
            return new Fraction(num1._numerator * num2.Denonminator + num2.Numerator
                    * num1._denominator, num1._denominator * num2.Denonminator);
        }

        public static Fraction operator -(Fraction num1, Fraction num2)
        {
            return num1 + new Fraction(-num2._numerator, num2._denominator);
        }

        public static Fraction operator -(Fraction num1, AnotherFraction num2)
        {
            return num1 + new Fraction(-num2.Numerator, num2.Denonminator);
        }

        public static Fraction operator *(Fraction num1, Fraction num2)
        {
            return new Fraction(num1._numerator * num2._numerator, 
                    num1._denominator * num2._denominator);
        }

        public static Fraction operator *(Fraction num1, AnotherFraction num2)
        {
            return new Fraction(num1._numerator * num2.Numerator,
                    num1._denominator * num2.Denonminator);
        }

        public static Fraction operator /(Fraction num1, Fraction num2)
        {
            return num1 * new Fraction(num2._denominator, num2._numerator);
        }

        public static Fraction operator /(Fraction num1, AnotherFraction num2)
        {
            return num1 * new Fraction(num2.Denonminator, num2.Numerator);
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

        public static bool operator |(Fraction num1, Fraction num2)
        {
            return (bool)num1 & (bool)num2;
        }

        public static bool operator &(Fraction num1, Fraction num2)
        {
            return (bool)num1 & (bool)num2;
        }

        public static bool operator ^(Fraction num1, Fraction num2)
        {
            return (bool)num1 ^ (bool)num2;
        }

        public static implicit operator double(Fraction source)
        {
            return (double)source._numerator / source._denominator;
        }

        public static explicit operator float(Fraction source)
        {
            return (float)source._numerator / source._denominator;
        }

        public static explicit operator int(Fraction source)
        {
            return source._numerator / source._denominator;
        }

        public static explicit operator bool(Fraction source)
        {
            return source._numerator == 0;
        }

        public static explicit operator Fraction(AnotherFraction source)
        {
            return new Fraction(source.Numerator, source.Denonminator);
        }

        #endregion

        #region Constructors

        public Fraction(int numerator, int denominator = 1)
        {
            ApplyNormalize(ref numerator, ref denominator);

            _numerator = numerator;

            if (_denominator != 0)
            {
                _denominator = denominator;
            }
        }

        public Fraction(Fraction source)
            :this(source._numerator, source._denominator)
        {
        }

        public Fraction(double number)
        {
            int count = 1;

            while (Math.Abs(number % 1) > ACCURACY)
            {
                number *= FACTOR;
                count *= FACTOR;
            }

            _numerator = (int)number;
            _denominator = count;
        }

        public Fraction(float number)
            : this((double)number)
        {
        }

        #endregion

        #region Normalize

        private static void ApplyNormalize(ref int numerator, ref int denominator)     
        {
            int divisor = GetGCD(numerator, denominator);

            if (divisor > 1)    
            {
                numerator /= divisor;
                denominator /= divisor;
            }
        }

        // The Greatest common divisor.
        public static int GetGCD(int source1, int source2)
        {
            while (source1 != source2)    
            {
                if (source1 > source2)
                {
                    source1 -= source2;
                }
                else
                {
                    source2 -= source1;
                }
            }

            return source1;
        }

        #endregion

    }
}
