using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Assembler : Converter
    {
        public int EnergyUse { get; private set; }

        internal Assembler(int armor, int efficiency, int energyUse)
            : base(armor, efficiency)
        {
            EnergyUse = energyUse;
        }
    }
}
