using System;
using System.Collections;

namespace Group_Of_Students
{
    interface IStudentNumerable
    {
        IStudentIterator CreateNumerator();
        int Count
        {
            get;
        }

        Student this[int index] 
        {
            get;
        }
    }
}
