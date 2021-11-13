using System;
using System.Collections;
using System.Collections.Generic;

namespace TestHastTable
{
    internal class Program
    {
        static void Main()
        {
            Test test = new Test();


            test.TestDictionary(new Dictionary<string, int>(), 1000);


            test.TestDictionary(new SortedDictionary<string, int>(), 1000);


            test.TestDictionary(new SortedList<string, int>(), 1000);


            test.TestHashTable(new Hashtable(), 1000);
        }
    }
}
