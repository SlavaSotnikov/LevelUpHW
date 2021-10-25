using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using StackBenchmark;

namespace Benchmark
{
    [MemoryDiagnoser]
    [RankColumn]
    public class TestStack
    {
        private readonly StackS _stackS = new StackS();
        private readonly StackG<int> _stackG = new StackG<int>();

        [Benchmark]
        public void TestStackS()
        {
            for (int i = 0; i < 100; i++)
            {
                _stackS.Push(i); 
            }
        }

        [Benchmark]
        public void TestStackG()
        {
            for (int i = 0; i < 100; i++)
            {
                _stackG.Push(i);
            }
        }
    }
}
