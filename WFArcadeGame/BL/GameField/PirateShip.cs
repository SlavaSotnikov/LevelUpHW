using System.Collections.Generic;

namespace BL
{
    internal class PirateShip : Ship
    {
        internal PirateShip(int ore, ObjectView view, params ShipModule[] module)
            : base(ore, view)
        {
        }
    }
}
