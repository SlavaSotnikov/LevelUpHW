using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Schedule_Task
{
    internal struct Namesakes
    {
        public string Name { get; set; }
        public int Amount { get; set; }

        public Namesakes(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}
