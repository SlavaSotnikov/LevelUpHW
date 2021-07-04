using System;

namespace Student_Class
{
    class Student
    {
        public string _name;
        public string _lastName;
        public uint _studNum;
        public DateTime _enterDate;

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
                DateTime enterDate)
        {
            _name = name;
            _lastName = lastName;
            _studNum = studNum;
            _enterDate = enterDate;
        }
    }
}
