using System;

namespace Group_Of_Students
{
    struct Student
    {
        public string name;
        public string lastName;
        public int studNum;
        public DateTime enterDate;
        public byte[] marks;

        public string Name 
        {
            get
            {
                return name;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
        }
    }
}
