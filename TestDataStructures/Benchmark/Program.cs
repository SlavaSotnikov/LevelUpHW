﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;

namespace Benchmark
{
    internal class Program
    {
        static void Main()
        {
            BenchmarkRunner.Run<BenchmarkTest>();
        }
    }
}
