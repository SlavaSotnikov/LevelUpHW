using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_05_13_Builder
{
    internal class HeavyShipCreator : ICreator
    {
        public Ship Ship { get; set; }

        public void GetShip()
        {
            Ship = new HeavyShip();
        }

        public void SetSerialNumber()
        {
            Ship.SerialNumber = "HeavyShip HS - 1";
        }

        public void SetEngine()
        {
            Ship.Engine = new Engine(EngineType.Nuclear, 50);
        }

        public void SetGun()
        {
            Ship.Gun = new Gun(power: 20, ammo: 200);
        }
    }
}
