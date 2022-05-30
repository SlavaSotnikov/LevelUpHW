using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _2022_05_02_DinnerPhilosopher
{
    internal class Fork
    {
        private bool _isInUse = false;
        
        public bool IsInUse 
        { 
            get
            {
                return _isInUse;
            }
            set
            {
                _isInUse = value;
            }
        }

        public string Name { get; }

        public Fork(string name)
        {
            Name = name;
        }
    }
}
