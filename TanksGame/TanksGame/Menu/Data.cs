using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public struct Data
    {
        public string Name { get; private set; }

        public string Country { get; private set; }

        public string Model { get; private set; }

        public Data(string name, string country, string model)
        {
            Name = name;
            Country = country;  
            Model = model;
        }
    }
}
