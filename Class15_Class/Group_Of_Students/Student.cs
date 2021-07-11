using System;
using System.Text;

namespace Group_Of_Students
{
    class Student
    {
        #region Constants

        private const byte MARK_AMOUNT = 10;
        private const byte DELETED_MARK = 1;

        #endregion

        #region Private Data

        private string _name;
        private string _lastName;
        private byte _age;
        private uint _studNum;
        private string _country;
        private DateTime _enterDate;
        private int _countOfMarks;
        private Mark[] _marks;

        #endregion

        #region Properties

        public string Name
        {
            get 
            { 
                return _name; 
            }
            set 
            { 
                _name = value;
            }
        }

        public string LastName
        {
            get
            { 
                return _lastName;
            }
            set 
            {
                _lastName = value; 
            }
        }

        public byte Age
        {
            get 
            { 
                return _age;
            }
            set
            {
                _age = value;
            }
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

        #region Indexers

        public Mark this[int index]
        {
            get
            {
                return _marks[index]; // Don't need to use new Mark() because of Value Type.
            }
        }

        #endregion

        #region CRUD Operations

        public void AddMark(Mark input) // Ask a question.
        {
            if (_countOfMarks >= _marks.Length)
            {
                Array.Resize(ref _marks, _marks.Length + (_marks.Length * 2));
            }

            _marks[_countOfMarks] = GetFullCopy(input);
            ++_countOfMarks;
        }

        public void DeleteMark(Mark source) // TODO: Delete by Date, Subject.
        {
            //index -= 1; // Adjust index
            //if (!IsValidPosition(index))
            //{
            //    return; // Enum error.
            //}

            for (int i = 0/*index*/; i < _countOfMarks - 1; i++)
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
            _name = name;
            _lastName = lastName;
            _studNum = studNum;
            _country = country;
            _enterDate = enterDate;
            _countOfMarks = 0;
            _marks = new Mark[capacity];
        }

        public Student(Student source) //TODO: Add to previos constr
        {
            _name = source._name;
            _lastName = source._lastName;
            _studNum = source._studNum;
            _country = source._country;
            _enterDate = source._enterDate;
            _countOfMarks = source._countOfMarks;
            _marks = (Mark[])source._marks.Clone();    // Clone
        }

        #endregion

        #region Utilits

        public static Mark GetFullCopy(Mark source)
        {
            Mark destination = new Mark()
            {
                Subject = source.Subject,
                Date = source.Date,
                Value = source.Value
            };

            return destination;
        }

        

        public void InitRandomMarks()
        {
            for (int i = 0; i < MARK_AMOUNT; i++)
            {
                AddMark(GetRandomMark()); 
            }
        }

        public double GetGPA() // Grade Point Average Method.
        {
            double gpa = 0;

            for (int i = 0; i < _countOfMarks; i++)
            {
                gpa += _marks[i].Value;
            }

            return gpa / _countOfMarks;
        }

        public string GetShortName()
        {
            StringBuilder shortName = new StringBuilder(_lastName + " ");
            shortName.Append(Name[0] + ".");

            return shortName.ToString();
        }

        public static Mark GetRandomMark()
        {
            string subject = BL_Random.GetRandomSubject(BL_Random.rnd.Next(0, 10));
            DateTime date = BL.GetRandomEnterDate();
            byte value = (byte)BL_Random.rnd.Next(2, 6);

            Mark rndMark = new Mark(subject, date, value);

            return rndMark;
        }

        public static DateTime GetRandomMarkDate()
        {
            DateTime start = new DateTime(2016, 1, 9);
            int range = (DateTime.Today - start).Days;

            return start.AddDays(BL_Random.rnd.Next(range));
        }

        private bool IsValidPosition(int index)
        {
            return index < 0 || index > _countOfMarks;
        }

        public bool IsAge(byte age) // TODO: Ask a question about Member Functions.
        {
            bool result = true;

            if (age < 15 || age > 100)
            {
                result = false;
            }

            return result;
        }

        #endregion
    }
}
