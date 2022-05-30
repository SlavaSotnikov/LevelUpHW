using System;
using System.Collections;
using System.Collections.Generic;

namespace TestDataStructures
{
    public class DataStructure
    {
        static readonly Random rnd = new Random();

        public void TestHashTable(Hashtable source, int iterations)
        {
            int r = 0;

            for (int i = iterations; i > 0; i--)
            {
                r = rnd.Next(0, 10000);
                source[$"Key{r}"] = r;
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

        public void Test(IDictionary<string, int> source, int iterations)
        {
            int r = 0;

            for (int i = iterations; i > 0; i--)
            {
                r = rnd.Next(0, 10000);
                source[$"Key{r}"] = r;
            }

            foreach (var item in source)
            {
                string key = item.Key;
                int value = item.Value;
            }
        }
    }
}
