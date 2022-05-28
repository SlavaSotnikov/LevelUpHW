using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_05_13_Builder
{
    internal class LightShipCreator : ICreator
    {
        public Ship Ship { get; set; }

        public void GetShip()
        {
            Ship = new LightShip();
        }

        public void SetSerialNumber()
        {
            Ship.SerialNumber = "LightShip LS - 1";
        }

        public void SetEngine()
        {
            Ship.Engine = new Engine(EngineType.Liquid, 25);
        }

        public void SetGun()
        {
            Ship.Gun = new Gun(power: 10, ammo: 100);
        }
    }
}
