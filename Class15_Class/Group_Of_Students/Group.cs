using System;

namespace Group_Of_Students
{
    class Group
    {
        private Student[] _students;
        private int _countOfStudents;

        public int GetCountOfStudents()
        {
            return _countOfStudents;
        }

        public void SetCountOfStudents(int input)
        {
            _countOfStudents = input;
        }

        public Student[] GetStudent()
        {
            return _students;
        }

        public void AddStudent(Student person)
        {
            if (_countOfStudents >= _students.Length)
            {
                Array.Resize(ref _students, _students.Length + 10);
            }

            _students[_countOfStudents] = person;
            ++_countOfStudents;
        }

        public Group(int capacity)
        {
            _students = new Student[capacity];
        }
    }
}
