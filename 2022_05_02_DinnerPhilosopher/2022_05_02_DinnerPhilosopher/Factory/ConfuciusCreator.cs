using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2022_05_02_DinnerPhilosopher
{
    internal class ConfuciusCreator : Creator
    {
        public ConfuciusCreator(ILogger log, Semaphore sem)
            : base(log, sem) {}

        public override Philosopher Create()
        {
            return new Confucius(null, null, _logger, _waiter);
        }
    }
}
