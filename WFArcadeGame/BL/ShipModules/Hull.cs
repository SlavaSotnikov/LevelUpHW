using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Hull : ShipModule
    {
        public List<ShipModule> Modules { get; set; }

        internal Hull(int armor, int moduleAmount)
            : base(armor)
        {
            Modules = new List<ShipModule>(moduleAmount);
        }
    }
}
