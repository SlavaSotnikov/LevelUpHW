using System;

namespace ConnectedList
{
    internal class Program
    {
        static void Main()
        {
            MyList<int> my = new MyList<int>();
            my.Add(1);
            my.Add(2);
            my.Add(3);
            my.Add(4);

            Console.ReadKey();
        }
    }

    public class MyList<T>
    {
        private Entry<T> _head;
        private Entry<T> _tail;

        public int Amount { get; private set; }

        public MyList()
        {
        }

        public void Add(T data)
        {
            Entry<T> node = new Entry<T>(data);

            if (_head == null)
            {
                _head = node;
            }
            else
            {
                _tail.Next = node;
            }
            _tail = node;

            ++Amount;
        }

        private class Entry<T>
        {
            public T Data { get; private set; }
            public Entry<T> Next { get; set; }

            public Entry(T data)
            {
                Data = data;
            }
        }
    }
}
