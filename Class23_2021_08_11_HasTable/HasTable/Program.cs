using System;
using System.Collections.Generic;

namespace HasTable
{
    internal class Program
    {
        static void Main()
        {
            ISet<Key> one = new TestHasTable
            {
                new Key("Jim"),
                new Key("Dodo"),
                new Key("Sam"),
                new Key("Bob")
            };

            //foreach (var item in one)
            //{
            //    Console.WriteLine("{0}", item.Data);
            //}

            //Console.WriteLine(one.Exists(new Key("Jim")));
            //Console.WriteLine(one.Exists(new Key("Bob")));
            //Console.WriteLine(one.Exists(new Key("Sam")));
            //Console.WriteLine(one.Exists(new Key("Dodo")));
            //Console.WriteLine(one.Exists(new Key("Dick")));

            //KVPair<Key, bool>[] dest = new KVPair<Key, bool>[100];

            //one.CopyTo(dest, 2);

            //one.Remove(new Key("Sam"));

            //one.TryGetValue(new Key("Sam"), out bool val);

            //bool res = one.Add(new Key("Sam"));


            Console.ReadKey();
        }
    }
}
