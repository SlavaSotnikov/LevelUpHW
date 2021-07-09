using System;

namespace GroupOfStudents
{
    class Group
    {
        #region Constants

        private const byte STUDENTS_AMOUNT = 10;
        private const byte DELETED_STUDENT = 1;

        #endregion

        #region Private Data

        private Student[] _students;
        private int _countOfStudents;

        #endregion

        #region Properties

        public int AmountOfStudents
        {
            get { return _countOfStudents; }
        }

        #endregion

        #region Accessors

        public Student GetStudentByPosition(int index)
        {
            return _students[index];
        }

        #endregion

        #region CRUD Operations

        public void AddStudent(Student person)
        {
            if (_countOfStudents >= _students.Length)
            {
                Array.Resize(ref _students, _students.Length + (_students.Length * 2));
            }

            _students[_countOfStudents] = new Student(person);
            ++_countOfStudents;
        } 

        public void EditStudent(Student person, int index)
        {
            index -= 1; // Adjust index
            if (index < 0 || index > _students.Length)
            {
                return; // Enum error.
            }

            _students[index] = new Student(person);
        }

        public void DeleteStudent(int index)
        {
            index -= 1; // Adjust index
            if (index < 0 || index > _students.Length)
            {
                return; // Enum error.
            }

            for (int i = index; i < _countOfStudents - 1; i++)
            {
                _students[i] = _students[i + 1];
            }

            _countOfStudents -= DELETED_STUDENT;
        }

        #endregion

        #region Constructors

        public Group(int capacity=STUDENTS_AMOUNT)
        {
            _students = new Student[capacity];
            _countOfStudents = 0;
        }

        public Group(Group source)
        {
            _countOfStudents = source._countOfStudents;
            _students = GetFullCopy(source._students);
        }

        #endregion

        #region Utilits

        public double GetGPA() // Grade Point Average.
        {
            double gpa = 0;

            for (int i = 0; i < _countOfStudents; i++)
            {
                gpa += _students[i].GetGPA();
            }

            return gpa / _countOfStudents;
        }

        private Student[] GetFullCopy(Student[] source)
        {
            Student[] destination = new Student[source.Length];

            Array.Copy(source, destination, source.Length);

            return destination;
        }

        #endregion
    }
}
