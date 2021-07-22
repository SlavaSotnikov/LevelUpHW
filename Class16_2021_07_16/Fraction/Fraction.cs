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
            return GetLogicValue(num1) & GetLogicValue(num2);
        }

        public static bool operator &(Fraction num1, Fraction num2)
        {
            return GetLogicValue(num1) & GetLogicValue(num2);
        }

        public static bool operator ^(Fraction num1, Fraction num2)
        {
            return GetLogicValue(num1) ^ GetLogicValue(num2);
        }

        public static bool GetLogicValue(Fraction source)
        {
            bool result = false;

            if (source._numerator / source._denominator == 0)
            {
                result = true;
            }

            return result;
        }

        public static implicit operator double(Fraction source)
        {
            return (double)source._numerator / source._denominator;
        }

        public static implicit operator float(Fraction source)
        {
            return (float)source._numerator / source._denominator;
        }

        public static explicit operator int(Fraction source)
        {
            return source._numerator / source._denominator;
        }

        public static implicit operator Fraction(double source)
        {
            return new Fraction(source);
        }

        public static implicit operator Fraction(float source)
        {
            return new Fraction(source);
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
            int divisor = GetGCD(numerator, denominator);

            if (divisor > 1)
            {
                numerator /= divisor;
                denominator /= divisor;
            }

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
            double numerator = (int)number;
            double denominator = 1;

            while ((numerator / denominator) != number)   // TODO: We don't need to apply normalizing because of the algorithm. 
            {
                if ((numerator / denominator) < number)
                {
                    ++numerator;
                }
                else
                {
                    ++denominator;
                }
            }

            _numerator = (int)numerator;
            _denominator = (int)denominator;
        }

        public Fraction(float number)
            : this((double)number)
        {
        }

        #endregion

        #region Normalize

        private static Fraction ApplyNormalize(Fraction source)       // TODO: This is an initial fraction after math operations.
        {
            int numerator = source._numerator;
            int denominator = source._denominator;

            int divisor = GetGCD(numerator, denominator);

            if (divisor > 1)    
            {
                numerator /= divisor;
                denominator /= divisor;
            }

            return new Fraction(numerator, denominator);              // TODO: Return a new normalized fraction.
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
