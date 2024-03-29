﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasTable
{
    internal struct Value
    {
        public string Data { get; private set; } = string.Empty;

        public Value(string source)
        {
            Data = source;
        }

        public override int GetHashCode()
        {
            return Data[0] + Data[1] + Data[2];
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Value))
            {
                return false;
            }

            return Data == ((Value)obj).Data;
        }
    }
}
