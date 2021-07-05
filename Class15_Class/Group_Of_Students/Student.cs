using System;
namespace Group_Of_Students
{
    class Student
    {
        private string _name;
        private string _lastName;
        private uint _studNum;
        private DateTime _enterDate;
        private byte[] _marks;

        private bool ValidateName(string input)
        {
            bool result = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                {
                    continue;
                }
                else
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public void SetName(string name)
        {
            if (ValidateName(name))
            {
                _name = name;
            }
            else
            {
                _name = "Invalid Name!";
            }

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

        public void SetMarks(byte[] input)
        {
            _marks = input;
        }

        public byte[] GetMarks()
        {
            return _marks;
        }

        public Student(string name, string lastName, uint studNum,
                DateTime enterDate, int capacity)
        {
            _name = name;
            _lastName = lastName;
            _studNum = studNum;
            _enterDate = enterDate;
            _marks = new byte [capacity];
        }
    }
}
