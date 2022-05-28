using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_05_13_Builder
{
    public abstract class Ship
    {
        public string SerialNumber  { get; set; }
        public Engine Engine { get; set; }
        public Gun Gun { get; set; }

        public override string ToString()
        {
            return $"Ship: {SerialNumber} Engine: {Engine.EngineType} Power: {Engine.Power}, " +
                    $"GunPower: {Gun.Power} Ammo: {Gun.Ammo}";
        }
    }
}
