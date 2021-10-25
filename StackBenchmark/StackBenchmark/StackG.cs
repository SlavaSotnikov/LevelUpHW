using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackBenchmark
{
    public class StackG<T>
    {
        Entry _top;

        public void Push(T data)
        {
            Entry node = new Entry(data);

            if (_top == null)
            {
                _top = node;
            }

            node.Next = _top;
            _top = node;
        }

        public T Pop()
        {
            if (_top == null)
            {
            }

            T result = _top.Data;
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

            public T Data { get; private set; }

            public Entry(T data)
            {
                Next = null;
                Data = data;
            }
        }
    }
}
