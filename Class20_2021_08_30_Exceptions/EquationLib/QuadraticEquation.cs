using System;

namespace EquationLib
{
    public class QuadraticEquation
    {
        private int _factorA;
        private int _factorB;
        private int _factorC;
        private double _x1;
        private double _x2;

        public double X1 
        {
            get
            {
                return _x1;
            }
        }
        public double X2 
        {
            get
            {
                return _x2;
            }
        }

        public QuadraticEquation(int a, int b, int c)
        {
            _factorA = a;
            _factorB = b;
            _factorC = c;
        }

        public void Run()
        {
            int discriminant = GetDiscriminant();

            if (discriminant > 0)
            {
                _x1 = (-_factorB + Math.Sqrt(discriminant)) / 2 * _factorA;
                _x2 = (-_factorB - Math.Sqrt(discriminant)) / 2 * _factorA;
            }
            else if (discriminant == 0)
            {
                _x1 = -_factorB / 2 * _factorA;
                _x2 = -_factorB / 2 * _factorA;    // How can I throw an Exception here?
            }
            else
            {
                throw new FieldAccessException("There are no roots in this equation!");
            }
        }

        public int GetDiscriminant()
        {
            if (_factorA == 0)
            {
                throw new FactorArgumentException("Anappropriate value! The value 'a' mustn't be zero.");
            }

            return (_factorB * _factorB) - (4 * _factorA * _factorC);
        }
    }
}
