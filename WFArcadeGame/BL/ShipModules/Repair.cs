using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Repair : Gun
    {
        public int RepairTime { get; private set; }

        internal Repair(int armor, int efficiency, int energyUse, int repairTime)
            : base(armor, efficiency, energyUse)
        {
            RepairTime = repairTime;
        }
    }
}
