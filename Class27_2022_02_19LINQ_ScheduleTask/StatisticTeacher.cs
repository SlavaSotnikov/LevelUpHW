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
        public int Mun { get; set; }
        public int Max { get; set; }
        public int Average { get; set; }

        public StatisticTeacher(string teacherName, int min, int max, int average)
        {
            TeacherName = teacherName;
            Mun = min;
            Max = max;      
            Average = average;
        }
    }
}
