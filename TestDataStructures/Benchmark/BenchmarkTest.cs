using System.Collections;
using System.Collections.Generic;
using TestDataStructures;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Benchmark
{
    [MemoryDiagnoser]
    [RankColumn]
    public class BenchmarkTest
    {
        private readonly DataStructure _test = new DataStructure();

        [Benchmark]
        public void TestDictionary()
        {
            _test.Test(new Dictionary<string, int>(), 10000);
        }

        [Benchmark]
        public void TestHashTable()
        {
            _test.TestHashTable(new Hashtable(), 10000);
        }

        //[Benchmark]
        //public void TestSortedDictionary()
        //{
        //    _test.Test(new SortedDictionary<string, int>(), 1000);
        //}

        //[Benchmark]
        //public void TestSortedList()
        //{
        //    _test.Test(new SortedList<string, int>(), 1000);
        //}
    }
}
