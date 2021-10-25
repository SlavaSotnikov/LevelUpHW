using BenchmarkDotNet.Running;
using StackBenchmark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    internal class Program
    {
        static void Main()
        {
            BenchmarkRunner.Run<TestStack>();
        }
    }
}
