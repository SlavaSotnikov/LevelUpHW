using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Schedule_Task
{
    internal struct StudentGroup
    {
        public Student Student { get; set; }
        public Group Group { get; set; }

        public StudentGroup(Student stud, Group grp)
        {
            Student = stud;
            Group = grp;
        }
    }
}
