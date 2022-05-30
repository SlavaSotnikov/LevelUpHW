using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Battery : ShipModule
    {
        public int Capacity { get; private set; }

        internal Battery(int armor, int capacity)
            : base(armor)
        {
            Capacity = capacity;
        }
    }
}
