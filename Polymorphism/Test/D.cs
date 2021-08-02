using System;

namespace Test
{
    class D : C
    {
        public new void F()
        {
            Console.WriteLine("D.F()");
        }
    }
}
