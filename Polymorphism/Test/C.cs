using System;

namespace Test
{
    class C : B
    {
        public new void F()
        {
            Console.WriteLine("C.F()");
        }
    }
}
