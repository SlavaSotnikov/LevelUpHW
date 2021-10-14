using System;

namespace CovariantAndContravariant
{
    public delegate void Test(C obj);

    public class A { }

    public class B : A { }

    public class C : B { }

    public class Program
    {
        static void Main()
        {
            Test test = Method;
        }

        public static void Method(A obj)  { }
        public static void Method1(B obj) { }
        public static void Method2(C obj) { }
    }
}
