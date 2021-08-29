using System.Collections;

namespace Generators
{
    interface IGenerator
    {
        IEnumerable GetSequence();
    }
}
