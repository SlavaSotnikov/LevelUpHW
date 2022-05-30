using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2022_05_02_DinnerPhilosopher
{
    internal abstract class Creator
    {
        protected ILogger _logger;
        protected Semaphore _waiter;

        public Creator(ILogger log, Semaphore waiter)
        {
            _logger = log;
            _waiter = waiter;
        }

        public abstract Philosopher Create();
    }
}
