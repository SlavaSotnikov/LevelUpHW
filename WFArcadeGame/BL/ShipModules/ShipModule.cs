using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public abstract class ShipModule
    {
        public int Armor { get; private set; }

        internal ShipModule(int armor)
        {
            Armor = armor;
        }
    }
}
