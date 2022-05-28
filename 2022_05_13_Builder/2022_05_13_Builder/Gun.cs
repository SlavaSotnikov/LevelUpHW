using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_05_13_Builder
{
    internal class Gun
    {
        public int Power { get; private set; }
        public int Ammo { get; private set; }

        public Gun(int power, int ammo)
        {
            Power = power;
            Ammo = ammo;
        }
    }
}
