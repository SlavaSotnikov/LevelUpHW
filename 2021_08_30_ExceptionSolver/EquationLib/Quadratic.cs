﻿using System;

namespace EquationLib
{
    internal class Quadratic : Equation
    {
        #region Properties

        public double C { get; set; }

        public override byte RootsCount
        {
            get
            {
                byte rootsCount = 0;

                if (A == 0)
                {
                    throw new QuadraticEquationException("Invalid value!" +
                            " The value 'a' mustn't be zero.");
                }

                double discriminant = GetDiscriminant();

                if (discriminant > 0)
                {
                    rootsCount = 2;
                }
                else if (discriminant == 0)
                {
                    rootsCount = 1;
                }
                else
                {
                    throw new QuadraticEquationException("There are no roots in this equation!");
                }

                return rootsCount;
            }
        }

        

        public override double this[int index]
        {
            get
            {
                double result = 0.0;

                index -= 1;

                if (index >= RootsCount)
                {
                    throw new QuadraticEquationException($"There is only {RootsCount} root!");
                }

                if (index == 0)
                {
                    result = (-B + Math.Sqrt(GetDiscriminant())) / 2 * A; 
                }

                if (index == 1)
                {
                    result = (-B - Math.Sqrt(GetDiscriminant())) / 2 * A; 
                }

                return result;
            }
        }

        #endregion

        #region Constructor

        public Quadratic(double a, double b, double c)
            : base(a, b)
        {
            C = c;
        }

        #endregion

        #region Member Functions

        private double GetDiscriminant()
        {
            return (B * B) - (4 * A * B);
        }

        #endregion
    }
}