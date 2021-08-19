using System;

namespace Group_Of_Students
{
    class StudentNumerator : IStudentIterator
    {
        IStudentNumerable aggregate;

        int index = 0;

        public StudentNumerator(IStudentNumerable a)
        {
            aggregate = a;
        }

        public bool HasNext()
        {
            return index < aggregate.Count;
        }

        public Student Next()
        {
            return aggregate[index++];
        }
    }
}
