using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritage
{
    internal class A
    {
        public void F()
        {
            Console.WriteLine("A.F");
        }
    }

    internal class B : A
    {
        public new void F()
        {
            Console.WriteLine("B.F");
        }
    }

    internal class C : B
    {
        
    }

    internal class Program
    {
        static void Main()
        {
            //A objAB = new B();
            //objAB.F();

            //B objAB2 = (B) objAB;
            //objAB2.F();

            A objAC = new C();
            objAC.F();

            Console.ReadKey();
        }
    }
}
