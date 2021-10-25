using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackBenchmark
{
    public class StackS
    {
        Entry _top;

        public void Push(object data)
        {
            Entry node = new Entry(data);

            if (_top == null)
            {
                _top = node;
            }

            node.Next = _top;
            _top = node;
        }

        public object Pop()
        {
            object result = null;

            if (_top == null)
            {
                return result;
            }

            result = _top.Data;
            _top = _top.Next;

            return result;
        }

        public bool IsEmpty 
        {
            get 
            {
                return _top == null;
            }
        }

        class Entry
        {
            public Entry Next { get; set; }

            public object Data {  get; private set; }

            public Entry(object data)
            {
                Next = null;
                Data = data;
            }
        }
    }
}
