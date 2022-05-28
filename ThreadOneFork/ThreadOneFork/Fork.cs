using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadOneFork
{
    internal class Fork
    {
        private bool _isInUse = false;

        public bool IsInUse
        {
            get
            {
                if (WhichPhilosopher != null)
                {
                    _isInUse = true;
                }

                return _isInUse;
            }
        }

        public string Name { get; }

        public Philosopher WhichPhilosopher { get; set; }

        public Fork(string name)
        {
            Name = name;
            WhichPhilosopher = null;
        }
    }
}
