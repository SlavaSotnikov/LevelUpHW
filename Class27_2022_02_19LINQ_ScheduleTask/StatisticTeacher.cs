using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Schedule_Task
{
    internal struct StatisticTeacher
    {
        public string TeacherName { get; set; }
        public string GroupName { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public double Average { get; set; }

        public StatisticTeacher(string teacherName, string grName,int min, int max, double average)
        {
            TeacherName = teacherName;
            Min = min;
            Max = max;      
            Average = average;
            GroupName = grName;
        }
    }
}
