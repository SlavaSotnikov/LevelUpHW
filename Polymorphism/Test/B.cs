using System;

namespace Test
{
    class B : A
    {
        public new void F()
        {
            Console.WriteLine("B.F()");
        }
    }
}
