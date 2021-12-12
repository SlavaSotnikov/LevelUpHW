using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMede
{
    internal abstract class Vehicle
    {
        public int AmountOfWheels { get; private set; }

        public abstract void Accelerate();

        public abstract void Brake();

        public Vehicle(int wheels)
        {
            AmountOfWheels = wheels;
        }
    }
}
