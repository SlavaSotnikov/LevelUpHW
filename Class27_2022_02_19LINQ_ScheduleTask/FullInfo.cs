using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Schedule_Task
{
    internal struct FullInfo
    {
        public int RecordBookNumber { get; }
        public string StudentName { get; }
        public string GroupName { get; }
        public string TeacherName { get; }

        public FullInfo(int number, string studName, string groupName, string teacherName)
        {
            RecordBookNumber = number;
            StudentName = studName;
            GroupName = groupName;
            TeacherName = teacherName;
        }
    }
}
