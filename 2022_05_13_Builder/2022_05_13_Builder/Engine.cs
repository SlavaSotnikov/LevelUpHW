using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_05_13_Builder
{
    public class Engine
    {
        public EngineType EngineType { get; private set; }

        public int Power { get; private set; }

        public Engine(EngineType engineType, int power)
        {
            EngineType = engineType;
            Power = power;
        }
    }
}
