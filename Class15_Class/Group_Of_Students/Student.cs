using System;
using System.Text;

namespace Group_Of_Students
{
    class Student
    {
        private const byte MARK_AMOUNT = 10;
        private const byte DELETED_MARK = 1;

        private string _name;
        private string _lastName;
        private uint _studNum;
        private DateTime _enterDate;
        private byte[] _marks;
        private int _countOfMarks;

        private string _country;

        public string Country
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

        public static bool IsValidateCountry(string country)
        {
            bool result = true;

            if (country.ToLower() != "ukraine" && country.ToLower() != "ukr")
            {
                result = false;
            }

            return result;
        }

        public int GetAmountOfMarks()
        {
            return _countOfMarks;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetLastName(string lastName)
        {
            _name = lastName;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public void SetStudNumber(uint studNumber)
        {
            _studNum = studNumber;
        }

        public uint GetStudNumber()
        {
            return _studNum;
        }

        public void SetEnterDate(DateTime date)
        {
            _enterDate = date;
        }

        public DateTime GetEnterDate()
        {
            return _enterDate;
        }

        public void AddMark(int index, byte mark)
        {
            if (_countOfMarks >= _marks.Length)
            {
                Array.Resize(ref _marks, _marks.Length + (_marks.Length * 2));
            }

            _marks[index] = mark;
            ++_countOfMarks;
        }

        public void InitRandomMarks()
        {
            for (int i = 0; i < MARK_AMOUNT; i++)
            {
                byte mark = (byte)BL_Random.rnd.Next(2, 6);

                AddMark(i, mark);
            }
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

        public byte GetMarkByPosition(int index)
        {
            return _marks[index];
        }

        public Student(string name, string lastName, uint studNum, string country,
                DateTime enterDate, int capacity=MARK_AMOUNT)
        {
            _name = name;
            _lastName = lastName;
            _studNum = studNum;
            _country = country;
            _enterDate = enterDate;
            _countOfMarks = 0;
            _marks = new byte [capacity];
        }

        public Student(Student source)
        {
            _name = source._name;
            _lastName = source._lastName;
            _studNum = source._studNum;
            _country = source._country;
            _enterDate = source._enterDate;
            _countOfMarks = source._countOfMarks;
            _marks = GetFullCopy(source._marks);    // Clone?
        }

        public static byte[] GetFullCopy(byte[] source)
        {
            byte[] destination = new byte[source.Length];

            Array.Copy(source, destination, source.Length);

            return destination;
        }

        // Grade Point Average Method.
        public int GetGPA()
        {
            int gpa = 0;

            for (int i = 0; i < _marks.Length; i++)
            {
                gpa += _marks[i];
            }

            return gpa;
        }

        public string GetShortName()
        {
            StringBuilder shortName = new StringBuilder(_lastName + " ");
            shortName.Append(_name[0] + ".");

            return shortName.ToString();
        }
    }
}
