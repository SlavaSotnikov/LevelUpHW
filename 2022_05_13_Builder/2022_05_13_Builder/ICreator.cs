using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_05_13_Builder
{
    internal interface ICreator
    {
        Ship Ship { get; set; }

        void SetSerialNumber();
        void SetEngine();
        void SetGun();

        void GetShip();
    }
}
