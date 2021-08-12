using System;

namespace StaticClass
{
    class Singletone3
    {
        private static Singletone3 _instanse = null;

        private Singletone3()
        {
            Console.WriteLine("s3");
        }

        public static Singletone3 GetInstanse()
        {

            if (_instanse == null)
            {
                _instanse = new Singletone3(); 

            }

            return _instanse;
        }
    }
}
