using System.Collections;
using System.Collections.Generic;

namespace TestHastTable
{
    internal class Test
    {
        public void TestHashTable(Hashtable source, int iterations)
        {
            for (int i = 0; i < 1000; i++)
            {
                source[$"Key{i}"] = i;
            }

            foreach (var item in source)
            {
                if (item is DictionaryEntry node)
                {
                    string k = (string)node.Key;
                    int v = (int)node.Value;
                }
            }
        }

        public void TestDictionary(IDictionary<string, int> source, int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                source[$"Key{i}"] = i;
            }

            foreach (var item in source)
            {
                string key = item.Key;
                int value = item.Value;
            }
        }
    }
}
