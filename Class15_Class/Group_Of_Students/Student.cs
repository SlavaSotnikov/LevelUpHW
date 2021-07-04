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

        public string GetName()
        {
            return _name;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public uint GetStudNumber()
        {
            return _studNum;
        }

        public DateTime GetEnterDate()
        {
            return _enterDate;
        }

        public Student(string name, string lastName, uint studNum,
                DateTime enterDate, byte[] marks)
        {
            _name = name;
            _lastName = lastName;
            _studNum = studNum;
            _enterDate = enterDate;
            _marks = marks;
        }
    }
}
