using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClass
{
    class Singletone2
    {
        private static Singletone2 _instance = new Singletone2();

        private Singletone2()
        {
            Console.WriteLine("s2");
        }

        public static Singletone2 GetInstanse()
        {
            return _instance;
        }
    }
}
