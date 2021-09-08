﻿using System;

namespace EquationLib
{
    public class EquationException : Exception    // TODO: Add Equation reference
    {
        public EquationException()
        {
        }

        public EquationException(string message)
            : base(message) 
        {
        }

        public EquationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}