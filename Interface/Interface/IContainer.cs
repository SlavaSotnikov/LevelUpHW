using System;

namespace Interface
{
    interface IContainer
    {
        int Size { get; }

        double this[int index] { get; set; }
    }
}
