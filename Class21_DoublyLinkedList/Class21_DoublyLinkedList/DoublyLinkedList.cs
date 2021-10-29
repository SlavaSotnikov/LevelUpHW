using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class21_DoublyLinkedList
{
    internal class DoublyLinkedList
    {
        private Entry _head = null;
        private Entry _tail = null;
        private Entry _current = null;

        public bool IsEmpty => _head is null;

        public bool IsExist(int source)    // TODO: How about a Property?
        {
            bool result = false;

            if (!IsEmpty)
            {
                _current = _head;

                while (_current.Next != null)
                {
                    if (_current.Data == source)
                    {
                        result = true;
                        break;
                    }

                    if (_current.Next.Data == source)
                    {
                        result = true;
                        _current = _current.Next;
                        break;
                    }

                    _current = _current.Next;
                } 
            }

            return result;
        }

        public void Add(int data, Position source)
        {
            Entry node = new Entry(data);

            if (IsEmpty)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                switch (source)
                {
                    case Position.Front:
                        _head.Previous = node;
                        node.Next = _head;
                        _head = node;
                        break;

                    case Position.Back:
                        node.Previous = _tail;
                        _tail.Next = node;
                        _tail = node;
                        break;

                    default:
                        break;
                }
            }
        }

        public bool Delete(int source)
        {
            bool result = false;

            if (IsExist(source))
            {
                if (_current == _head)
                {
                    _head = _head.Next;
                    _head.Previous = null;
                    _current.Next = null;
                }
                else if (_current == _tail)
                {
                    _tail = _tail.Previous;
                    _tail.Next = null;
                    _current.Previous = null;
                }
                else 
                {
                    _current.Next.Previous = _current.Previous;
                    _current.Previous.Next = _current.Next;
                    _current.Previous = null;    // TODO: What about GC?
                    _current.Next = null;
                }

                result = true;
            }

            return result;
        }

        public void Sort()
        {
            _current = _tail;
            Entry temp = _current.Previous;

            if (_current.Data < temp.Data)
            {
                while ((_current.Data < temp.Data) && (_current.Previous != null))
                {
                    _current.Previous = temp.Previous;
                    temp.Next = _current.Next;
                    _current.Next = temp;

                    if (_current.Previous != null)
                    {
                        temp = _current.Previous;
                        temp.Next = _current;
                    }
                    else
                    {
                        temp.Previous = _current;
                    }

                }

                _current.Next.Previous = _current;

                while (_tail.Next != null)
                {
                    _tail = _tail.Next;
                } 
            }
        }

        private class Entry
        {
            public int Data { get; set; }
            public Entry Previous { get; set; }
            public Entry Next { get; set; }

            public Entry(int data)
            {
                Data = data;
            }
        }
    }
}
