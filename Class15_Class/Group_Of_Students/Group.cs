using System;
using System.Collections;
using System.Text;

namespace Group_Of_Students
{
    class Group : IList
    {
        #region Constants

        private const byte STUDENTS_AMOUNT = 10;
        private const byte DELETED_STUDENT = 1;
        private const byte ONE_LEVEL = 1;

        #endregion

        #region Private Data 

        private string _groupName;
        private Student[] _students;
        private int _amountOfStudents;
        private int _groupGPA;

        #endregion

        #region Properties

        public OperationStatus LastOperationStatus { get; private set; }

        public int AmountOfStudents
        {
            get { return _amountOfStudents; }
        }

        public string GroupName
        {
            get 
            { 
                return _groupName;
            }
        }

        public int GroupGPA
        {
            get 
            {
                return _groupGPA;
            }
        }

        #region IList properties

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return true;
            }
        }

        public int Count 
        {
            get
            {
                return _amountOfStudents;
            }
        }

        public object SyncRoot
        {
            get
            {
                return this;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public object this[int index]
        {
            get
            {
                return _students[index];
            }
            set
            {
                _students[index] = new Student(value as Student);    // TODO: Ask a question about this indexer.
            }
        }


        #endregion

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
            if (_amountOfStudents >= _students.Length)
            {
                Array.Resize(ref _students, _students.Length + (_students.Length * 2));
            }

            _students[_amountOfStudents] = new Student(person);
            ++_amountOfStudents;
        } 

        public void EditStudent(Student person, int id)
        {
            if (IsValidGroupId(id))
            {
                for (int i = 0; i < _amountOfStudents; i++)
                {
                    if (_students[i].Id == id)
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

            for (int i = 0; i < _amountOfStudents; i++)
            {
                if (_students[i].Id == id)
                {
                    Array.Copy(_students, i + 1, _students, i, _students.Length - (i + 1));

                    _amountOfStudents -= DELETED_STUDENT;

                    LastOperationStatus = OperationStatus.Ok;
                }
            }
        }

        public int[] SearchByLastName(string lastName)
        {
            int count = 0;

            int[] duplicate = new int[0];

            LastOperationStatus = OperationStatus.Not_Found;
             
            for (int i = 0; i < _amountOfStudents; i++)
            {
                if (_students[i].LastName == lastName)
                {
                    if (count >= duplicate.Length)
                    {
                        Array.Resize(ref duplicate, duplicate.Length + 1);
                    }

                    duplicate[count] = i;
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

            for (int i = 0; i < _amountOfStudents; i++)
            {
                if (_students[i].Id == id)
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
            _groupName = BL.GetGroupName();
            _students = new Student[capacity];
            _amountOfStudents = 0;
            _groupGPA = 0;
        }

        public Group(Group source)
        {
            _groupName = source._groupName;
            _students = GetFullCopy(source._students);
            _amountOfStudents = source._amountOfStudents;
            _groupGPA = source._groupGPA;
        }

        public Group(params Student[] input)    // TODO: From Students[] to Group
        {
            _students = GetFullCopy(input);
            _amountOfStudents = input.Length;   // TODO:????
        }

        public Group(string name, Student[] students, int amount)
        {
            _groupName = name;
            _students = students;
            _amountOfStudents = amount;
        }

        #endregion

        #region Member Functions

        public Group GoToNextLevel()
        {
            Student[] zeroing = new Student[_amountOfStudents];

            for (int i = 0; i < _amountOfStudents; i++)
            {
                zeroing[i] = _students[i].ZeroingCopy();
            }

            string newName = NextLevelName(_groupName);

            Group nextLevel = new Group(newName, zeroing, _amountOfStudents);

            return nextLevel;
        }

        public float GetGPA()    // Grade Point Average.
        {
            float gpa = 0;

            for (int i = 0; i < _amountOfStudents; i++)
            {
                gpa += _students[i].GetGPA();
            }

            return gpa / _amountOfStudents;
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

            for (int i = 0; i < _amountOfStudents; i++)
            {
                if (_students[i].Id == id)
                {
                    result = true;
                }
            }

            return result;
        }

        public static string NextLevelName(string source)
        {
            StringBuilder newName = new StringBuilder(source);

            for (int i = 0; i < newName.Length; i++)
            {
                if (char.IsDigit(newName[i]))
                {
                    int nextGroup = Convert.ToInt32(newName[i]) + ONE_LEVEL;
                    newName[i] = Convert.ToChar(nextGroup);
                    break;
                }
            }

            return newName.ToString();
        }

        #region IList Members

        public int Add(object person)
        {
            if (_amountOfStudents < _students.Length)
            {
                _students[_amountOfStudents] = person as Student;
                ++_amountOfStudents;

                return (_amountOfStudents - 1);
            }
            else
            {
                Array.Resize(ref _students, _students.Length + (_students.Length * 2));

                return -1;
            }
        }

        public bool Contains(object person)
        {
            bool result = false;

            if (person is Student one)
            {
                for (int i = 0; i < _amountOfStudents; i++)
                {
                    if (_students[i].Id == one.Id)
                    {
                        result = true;
                        break;
                    }
                } 
            }

            return result;
        }

        public void Clear()
        {
            _amountOfStudents = 0;
        }

        public int IndexOf(object person)
        {
            int result = -1;

            if (person is Student one)
            {
                for (int i = 0; i < _amountOfStudents; i++)
                {
                    if (_students[i].Id == one.Id)
                    {
                        result = i;
                        break;
                    }
                } 
            }

            return result;
        }

        public void Insert(int index, object person)
        {
            if ((_amountOfStudents + 1 <= _students.Length) 
                    && (index < _amountOfStudents) && (index >= 0))
            {
                ++_amountOfStudents;

                for (int i = _amountOfStudents - 1; i > index; i--)
                {
                    _students[i] = _students[i - 1];
                }
            }

            _students[index] = new Student(person as Student);
        }

        public void Remove(object person)
        {
            RemoveAt(IndexOf(person));
        }

        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < _amountOfStudents))
            {
                for (int i = index; i < _amountOfStudents - 1; i++)
                {
                    _students[i] = _students[i + 1];
                }

                --_amountOfStudents;
            }
        }

        public void CopyTo(Array destination, int index)
        {
            for (int i = 0; i < _amountOfStudents; i++)
            {
                destination.SetValue(_students[i], index++);
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }


        #endregion

        #endregion
    }
}
