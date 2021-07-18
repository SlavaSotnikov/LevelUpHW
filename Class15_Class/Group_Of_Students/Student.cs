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

        public string Country 
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

        public OperationStatus LastOperationStatus { get; private set; }    // TODO: Should we generate OperationStatus in each class?

        #endregion

        #region Accessors

        public int[] GetMarkBySubject(string subject)
        {
            if (!IsValidSubject(subject))
            {
                LastOperationStatus = OperationStatus.Not_Found;

                return new int[0];    // TODO: What should we return?
            }

            int count = 0;

            int[] duplicate = new int[0];

            for (int i = 0; i < _countOfMarks; i++)
            {
                if (_marks[i].Subject == subject)
                {
                    Array.Resize(ref duplicate, duplicate.Length + 1);
                    duplicate.SetValue(i, count);
                    ++count;

                    LastOperationStatus = OperationStatus.Ok;
                }
            }

            return duplicate;
        } 

        #endregion

        #region Indexers

        public Mark this[int index]
        {
            get
            {
                if (!IsValidPosition(index))    // TODO: What should we return?
                {
                    return new Mark();
                }

                return _marks[index]; 
            }
        }

        #endregion

        #region CRUD Operations

        public void AddMark(Mark input)
        {
            if (_countOfMarks >= _marks.Length)
            {
                Array.Resize(ref _marks, _marks.Length + (_marks.Length * 2));
            }

            _marks[_countOfMarks] = new Mark(input); //GetFullCopy(input);   TODO: Ctor or GetFullCopy()
            ++_countOfMarks;
        }

        public void DeleteMark(string subject) // TODO: Delete by Date, Subject.
        {
            if (!IsValidSubject(subject))
            {
                return; // Enum error.
            }
            
            for (int i = 0; i < _countOfMarks; i++)
            {
                if (_marks[i].Subject == subject)
                {
                    Array.Copy(_marks, i+1, _marks, i, _marks.Length - (i+1)); // Shift marks.
                }
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

        public Student(Student source)
            : this(source._name, source._lastName, source._studNum,  // TODO: Ask about Copy Constructors
                  source._country, source._enterDate )
        {
            _countOfMarks = source._countOfMarks;
            _marks = (Mark[])source._marks.Clone();   
        }

        public Student ZeroingCopy()
        {
            return new Student(_name, _lastName,
                    _studNum, _country, _enterDate, MARK_AMOUNT);    // Return???
        }

        #endregion

        #region Member Functions

        public static Mark GetFullCopy(Mark source)    // TODO: Copy Constructor for Struct???
        {
            Mark destination = new Mark()
            {
                Subject = source.Subject,
                Date = source.Date,
                Rate = source.Rate
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

        public float GetGPA() // Grade Point Average Method.
        {
            float gpa = 0;

            for (int i = 0; i < _countOfMarks; i++)
            {
                gpa += _marks[i].Rate;
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
            string subject = BL_Random.GetSubject(BL_Random.rnd.Next(0, 10));
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

        public bool IsValidSubject(string subject)
        {
            bool result = true;

            for (int i = 0; i < 10; i++)
            {
                if (!(BL_Random.GetSubject(i) == subject))
                {
                    result = false;
                }
            }

            return result;
        }

        #endregion
    }
}
