using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadOneFork
{
    internal class Aristotle : Philosopher
    {
        public Aristotle(Fork fork, string name, ILogger log) 
            : base(fork, name, log)
        {
        }
    }
}
