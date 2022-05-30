using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2022_05_02_DinnerPhilosopher
{
    internal class Aristotle : Philosopher
    {
        public Aristotle(Fork left, Fork right, ILogger log, Semaphore sem)
            : base(left, right, log, sem)
        {
        }
    }
}
