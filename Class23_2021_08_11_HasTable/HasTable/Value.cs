using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasTable
{
    internal struct Value
    {
        private string _source;

        public Value(string source)
        {
            _source = source;
        }

        public override int GetHashCode()
        {
            return _source[0] + _source[1] + _source[2];
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Value))
            {
                return false;
            }

            return _source == ((Value)obj)._source;
        }
    }
}
