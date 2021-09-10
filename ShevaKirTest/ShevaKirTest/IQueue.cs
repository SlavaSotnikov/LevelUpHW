using System;

namespace ShevaKirTest
{
    interface IQueue
    {
        void Put(object data);
        object GetData();
    }
}
