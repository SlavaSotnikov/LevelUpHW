﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationLib
{
    public class FactorArgumentException : Exception
    {
        #region Constructors

        public FactorArgumentException()
        {
        }

        public FactorArgumentException(string message)
            : base(message)
        {
        }

        public FactorArgumentException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion
    }
}
