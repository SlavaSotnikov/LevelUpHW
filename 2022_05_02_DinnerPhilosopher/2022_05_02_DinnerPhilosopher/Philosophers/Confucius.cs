using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_05_02_DinnerPhilosopher
{
    internal class Confucius : Philosopher
    {
        public Confucius(Fork left, Fork right, ILogger log)
            : base(left, right, log)
        {
        }
    }
}
