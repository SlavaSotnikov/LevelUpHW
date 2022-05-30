using System;
using System.Collections.Generic;

namespace HasTable
{
    internal class Program
    {
        static void Main()
        {
            TestHasTable<string, string> one = new();

            //one.Add(KeyValuePair.Create(new Key("Bob"), new Value("123")));
            //one.Add(KeyValuePair.Create(new Key("Rob"), new Value("345")));
            //one.Add(KeyValuePair.Create(new Key("Den"), new Value("666")));
            //one.Add(KeyValuePair.Create(new Key("Zac"), new Value("999")));

            //one[new Key("Bob")] = new Value("222");

            //Console.WriteLine(one.GetValue(new Key("Zac")).Data);

            Console.ReadKey();
        }
    }
}
