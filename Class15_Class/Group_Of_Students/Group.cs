using System;

namespace Group_Of_Students
{
    class Group // TODO: Add search by Name, Id, EnterDate.
    {
        #region Constants

        private const byte STUDENTS_AMOUNT = 10;
        private const byte DELETED_STUDENT = 1;

        #endregion

        #region Private Data //TODO: Add Gorup Id. UnicueName property.

        private string _groupName;
        private Student[] _students;
        private int _countOfStudents;

        #endregion

        #region Properties

        public OperationStatus LastOperationStatus { get; private set; }

        public int AmountOfStudents
        {
            get { return _countOfStudents; }
        }

        public string GroupName
        {
            get 
            { 
                return _groupName;
            }
        }

        #endregion

        #region Accessors

        public Student GetStudentByPosition(int index)
        {
            return new Student(_students[index]);
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

        public void EditStudent(Student person, int id)
        {
            if (IsValidGroupId(id))
            {
                for (int i = 0; i < _countOfStudents; i++)
                {
                    if (_students[i].StudNumber == id)
                    {
                        _students[i] = new Student(person);

                        LastOperationStatus = OperationStatus.Ok;
                    }
                } 
            }
            else
            {
                LastOperationStatus = OperationStatus.Not_Found;

                return;
            }
        }

        public void DeleteStudent(int id)
        {
            if (!IsValidGroupId(id))
            {
                LastOperationStatus = OperationStatus.Not_Found;

                return;
            }

            for (int i = 0; i < _countOfStudents; i++)
            {
                if (_students[i].StudNumber == id)
                {
                    Array.Copy(_students, i + 1, _students, i, _students.Length - (i + 1));

                    _countOfStudents -= DELETED_STUDENT;

                    LastOperationStatus = OperationStatus.Ok;
                }
            }
        }

        public int[] SearchByName(string name)
        {
            int count = 0;

            int[] duplicate = new int[0];

            LastOperationStatus = OperationStatus.Not_Found;

            for (int i = 0; i < _countOfStudents; i++)
            {
                if (_students[i].Name == name)
                {
                    Array.Resize(ref duplicate, duplicate.Length + 1);
                    duplicate.SetValue(i, count);
                    ++count;

                    LastOperationStatus = OperationStatus.Ok;
                }
            }

            return duplicate;
        }

        public int SearchById(int id)    // TODO: What should we return? -1???
        {
            int index = -1;

            LastOperationStatus = OperationStatus.Not_Found;

            for (int i = 0; i < _countOfStudents; i++)
            {
                if (_students[i].StudNumber == id)
                {
                    index = i;
                    LastOperationStatus = OperationStatus.Ok;
                }
            }

            return index;
        }

        #endregion

        #region Constructors 

        public Group(int capacity=STUDENTS_AMOUNT) 
        {
            _groupName = string.Empty;    // TODO: Develop GroupName.
            _students = new Student[capacity];
            _countOfStudents = 0;
        }

        public Group(Group source)
        {
            _groupName = source._groupName;
            _students = GetFullCopy(source._students);
            _countOfStudents = source._countOfStudents;
        }

        public Group(params Student[] input)    // TODO: From Students[] to Group
        {
            _students = GetFullCopy(input);
            _countOfStudents = input.Length;   //????
        }

        #endregion

        #region Utilits

        public double GetGPA()    // Grade Point Average.
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

            for (int i = 0; i < source.Length; i++)
            {
                destination[i] = new Student(source[i]);
            }

            return destination;
        }

        public bool IsValidGroupId(int id)
        {
            bool result = false;

            for (int i = 0; i < _countOfStudents; i++)
            {
                if (_students[i].StudNumber == id)
                {
                    result = true;
                }
            }

            return result;
        }

        #endregion
    }
}
