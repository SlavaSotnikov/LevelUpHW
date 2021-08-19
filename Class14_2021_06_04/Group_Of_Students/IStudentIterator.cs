using System;
using System.Collections;

namespace Group_Of_Students
{
    interface IStudentIterator
    {
        bool HasNext();

        Student Next();
    }
}
