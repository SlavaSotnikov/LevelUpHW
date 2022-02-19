using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Schedule_Task
{
    class Person
    {
        // порядковый номер персоны (~INN)
        public int ID
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public override int GetHashCode()
        {
            return ID >> 4;
        }

        public override bool Equals(object obj)
        {
            bool result = false;

            if (obj is Person)
            {
                Person obj1 = (Person)obj;

                if (obj1.ID == ID)
                {
                    result = true;
                }
            }

            return result;
        }

        public override string ToString()
        {
            return string.Format("[{0,2}] - {1} {2}", ID, FirstName, LastName);
        }
    }
}
