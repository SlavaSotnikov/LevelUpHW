using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Gun : Assembler
    {
        internal Gun(int armor, int efficiency,int energyUse)
            : base(armor, efficiency, energyUse)
        {
        }
    }
}
