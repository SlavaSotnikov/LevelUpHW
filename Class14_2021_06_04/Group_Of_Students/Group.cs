using System;

namespace Group_Of_Students
{
    struct Group : IStudentNumerable
    {
        public Student[] persons;

        public int countOfStudents;

        public Student this[int index]
        {
            get
            {
                return persons[index];
            }
        }

        public int Count
        {
            get
            {
                return persons.Length;
            }
        }

        public IStudentIterator CreateNumerator()
        {
            return new StudentNumerator(this);
        }
    }
}
