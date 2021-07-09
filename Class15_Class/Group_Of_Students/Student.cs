using System;
using System.Text;

namespace GroupOfStudents
{
    class Student
    {
        #region Constants

        private const byte MARK_AMOUNT = 10;
        private const byte DELETED_MARK = 1;

        #endregion

        #region Pravate Data

        private string _name;
        private string _lastName;
        private uint _studNum;
        private string _country;
        private DateTime _enterDate;
        private int _countOfMarks;
        private byte[] _marks;

        #endregion

        #region Properties

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public uint StudNumber
        {
            get { return _studNum; }
            set { _studNum = value; }
        }

        public string Country // There is a check.
        {
            get
            {
                return _country;
            }
            set
            {
                if (!IsValidateCountry(_country))
                {
                    return;
                }

                _country = value;
            }
        }

        public DateTime EnterDate
        {
            get { return _enterDate; }
            set { _enterDate = value; }
        }

        public int AmountOfMarks
        {
            get { return _countOfMarks; }
        }

        #endregion

        #region Accessors
       
        public byte GetMarkByPosition(int index)
        {
            return _marks[index];
        }

        #endregion

        #region CRUD Operations

        public void AddMark(int index, byte mark) // Ask a question.
        {
            if (_countOfMarks >= _marks.Length)
            {
                Array.Resize(ref _marks, _marks.Length + (_marks.Length * 2));
            }

            _marks[index] = mark;
            ++_countOfMarks;
        }

        public void EditMark(int index, byte newMark)
        {
            if (index < 0 || index > _marks.Length)
            {
                return; // Enum error.
            }

            _marks[index] = newMark;
        }

        public void DeleteMark(int index, byte deleteMark)
        {
            index -= 1; // Adjust index
            if (index < 0 || index > _marks.Length)
            {
                return; // Enum error.
            }

            for (int i = index; i < _countOfMarks - 1; i++)
            {
                _marks[i] = _marks[i + 1];
            }

            // Just modify the countOfMarks.
            _countOfMarks -= DELETED_MARK;
        }

        #endregion

        #region Constructors

        public Student(string name, string lastName, uint studNum, string country,
                DateTime enterDate, int capacity = MARK_AMOUNT)
        {
            Name = name;
            _lastName = lastName;
            _studNum = studNum;
            _country = country;
            _enterDate = enterDate;
            _countOfMarks = 0;
            _marks = new byte[capacity];
        }

        public Student(Student source)
        {
            Name = source.Name;
            _lastName = source._lastName;
            _studNum = source._studNum;
            _country = source._country;
            _enterDate = source._enterDate;
            _countOfMarks = source._countOfMarks;
            _marks = GetFullCopy(source._marks);    // Clone?
        }

        #endregion

        #region Utilits

        public static bool IsValidateCountry(string country)
        {
            bool result = true;

            if (country.ToLower() != "ukraine" && country.ToLower() != "ukr")
            {
                result = false;
            }

            return result;
        }

        public void InitRandomMarks()
        {
            for (int i = 0; i < MARK_AMOUNT; i++)
            {
                byte mark = (byte)BL_Random.rnd.Next(2, 6);

                AddMark(i, mark);
            }
        }

        public static byte[] GetFullCopy(byte[] source) // Ask a question.
        {
            byte[] destination = new byte[source.Length];

            Array.Copy(source, destination, source.Length);

            return destination;
        }

        public double GetGPA() // Grade Point Average Method.
        {
            double gpa = 0;

            for (int i = 0; i < _countOfMarks; i++)
            {
                gpa += _marks[i];
            }

            return gpa / _countOfMarks;
        }

        public string GetShortName()
        {
            StringBuilder shortName = new StringBuilder(_lastName + " ");
            shortName.Append(Name[0] + ".");

            return shortName.ToString();
        }

        #endregion
    }
}
