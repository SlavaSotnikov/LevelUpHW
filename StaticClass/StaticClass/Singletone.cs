using System;

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
