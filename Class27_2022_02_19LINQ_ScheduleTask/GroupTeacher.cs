using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Schedule_Task
{
    internal struct GroupTeacher
    {
        public Group Group { get; }
        public Teacher Teacher { get; }

        public GroupTeacher(Group group, Teacher teacher)
        {
            Group = group; 
            Teacher = teacher;
        }
    }
}
