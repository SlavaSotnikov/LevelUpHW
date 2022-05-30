using System;

namespace CovariantAndContravariant
{
    public delegate A Test();    // TODO: Did they do it on purpose? Forbidden upcast.

    public class A { }

    public class B : A { }

    public class C : B { }

    public class Program
    {
        static void Main()
        {
            Test test = Method2;
        }

        public static A Method() { return new A(); }
        public static B Method1() { return new B(); }
        public static C Method2() { return new C(); }
    }
}
