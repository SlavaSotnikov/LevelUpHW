using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Converter : ShipModule
    {
        public int Efficiency { get; private set; }

        internal Converter(int armor, int efficiency)
            :base(armor)
        {
            Efficiency = efficiency;
        }
    }
}
