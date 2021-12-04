using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Generator : Converter
    {
        internal Generator(int armor, int efficiency)
            : base(armor, efficiency)
        {
        }
    }
}
