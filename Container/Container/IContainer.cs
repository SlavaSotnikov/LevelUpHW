using System;

namespace Container
{
    interface IContainer
    {
        int Size { get; }

        new object this[int index] { get; set; }
    }
}
