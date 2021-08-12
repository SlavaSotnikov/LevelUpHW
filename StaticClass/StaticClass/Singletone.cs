using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClass
{
    class Singletone
    {
        private int _a;

        private static int _objCount = 0;

        public Singletone(int a)
        {
            _a = a;

            ++_objCount;
        }

        public static int ObjCount
        {
            get
            {
                return _objCount;
            }
        }
    }
}
