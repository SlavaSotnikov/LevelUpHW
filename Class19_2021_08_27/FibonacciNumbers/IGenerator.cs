using System.Collections;

namespace FibonacciNumbers
{
    interface IGenerator
    {
        IEnumerable GetSequence();
    }
}
