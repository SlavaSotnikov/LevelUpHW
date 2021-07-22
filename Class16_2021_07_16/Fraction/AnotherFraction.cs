namespace Fraction
{
    class AnotherFraction
    {
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

        public static AnotherFraction operator ++(AnotherFraction num1)
        {
            return new AnotherFraction(num1.Numerator + num1.Denonminator, num1.Denonminator);
        }

        public static AnotherFraction operator --(AnotherFraction num1)
        {
            return new AnotherFraction(num1.Numerator - num1.Denonminator, num1.Denonminator);
        }

        public static explicit operator AnotherFraction(Fraction source)
        {
            return new AnotherFraction(source.Numerator, source.Denonminator);
        }

        #region Constructors

        public AnotherFraction(int numerator, int denominator = 1)
        {
            _numerator = numerator;

            if (_denominator != 0)
            {
                _denominator = denominator;
            }
        }

        public AnotherFraction(AnotherFraction source)
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

        public AnotherFraction(double number)
        {
            double numerator = (int)number;
            double denominator = 1;

            while ((numerator / denominator) != number)
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

        public AnotherFraction(float number)
            : this((double)number)
        {
        }

        #endregion
    }
}
