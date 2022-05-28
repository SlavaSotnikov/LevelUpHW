﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_05_02_DinnerPhilosopher
{
    internal class AristotleCreator : Creator
    {
        public AristotleCreator(ILogger log)
            : base(log) { }

        public override Philosopher Create()
        {
            return new Aristotle(null, null, _logger);
        }
    }
}
