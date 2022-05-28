using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_05_13_Builder
{
    internal class Plant
    {
        public Ship CreateShip(ICreator shipCreator)
        {
            shipCreator.GetShip();

            shipCreator.SetSerialNumber();
            shipCreator.SetEngine();
            shipCreator.SetGun();

            return shipCreator.Ship;
        }
    }
}
