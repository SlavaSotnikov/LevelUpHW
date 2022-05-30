using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Schedule_Task
{
    internal struct GroupStud
    {
        public string GroupName { get; }
        public int Amount { get; }

        public GroupStud(string name, int amount)
        {
            GroupName = name;
            Amount = amount;
        }
    }
}
