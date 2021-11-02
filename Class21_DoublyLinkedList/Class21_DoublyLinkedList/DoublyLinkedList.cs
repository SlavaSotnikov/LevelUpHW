using System;
using System.Collections;
using System.Collections.Generic;

namespace Class21_DoublyLinkedList
{
    internal class DoublyLinkedList<T> : IEnumerable
        where T : IComparable<T>
    {
        private Entry _head = null;
        private Entry _tail = null;
        private Entry _current = null;
        private Entry _temp = null;

        public bool IsEmpty => _head is null; 

        public bool IsExist(T source)
        {
            bool result = false;

            if (!IsEmpty)
            {
                Entry current = _head;

                while (current.Next != null)
                {
                    source.CompareTo(T);    // TODO: Read IComparable.

                    if (current.Data == source)
                    {
                        result = true;
                        break;
                    }

                    if (current.Next.Data == source)
                    {
                        result = true;
                        current = _current.Next;
                        break;
                    }

                    current = current.Next;
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

        public bool Insert(int element, int data)
        {
            bool result = false;

            if (IsExist(element))
            {
                Entry node = new Entry(data);

                if (_current == _tail)
                {
                    node.Previous = _current;
                    _current.Next = node; 
                }
                else
                {
                    node.Previous = _current;
                    node.Next = _current.Next;
                    _current.Next = node;
                    node.Next.Previous = node;
                }

                result = true;
            }

            return result;
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
                    _current.Previous = null;
                    _current.Next = null;
                }

                result = true;
            }

            return result;
        }

        public void Sort()
        {
            Entry index = _tail;
            _current = _tail;
            _temp = _current.Previous;

            for (; index.Previous != null; index = index.Previous )
            {
                if (_current.Data < _temp.Data)
                {
                    while ((_current.Data < _temp.Data) && (_current.Previous != null))
                    {
                        _current.Previous = _temp.Previous;
                        _temp.Next = _current.Next;
                        _current.Next = _temp;

                        if (_current.Previous != null)
                        {
                            _temp = _current.Previous;
                            _temp.Next = _current;
                        }
                        else
                        {
                            _temp.Previous = _current;
                        }
                    }

                    _current.Next.Previous = _current;

                    if (_temp.Next != null)
                    {
                        _temp.Next.Previous = _temp; 
                    }

                    while (_temp.Next != null)
                    {
                        _temp.Next.Previous = _temp;
                        _temp = _temp.Next;
                    }

                    while (index.Next != null)
                    {
                        index = index.Next;
                    }

                    _current = index;
                    _temp = _current.Previous;
                }
                else
                {
                    _current = _current.Previous;
                    _temp = _current.Previous;
                }
            }

            while (_tail.Next != null)    // Set _tail after sort.
            {
                _tail = _tail.Next;
            }

            while (_head.Previous != null)    // Set _head after sort.
            {
                _head = _head.Previous;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new DLEnumerator(_head);
        }

        public class Entry
        {
            public int Data { get; set; }
            public Entry Previous { get; set; }
            public Entry Next { get; set; }

            public Entry(int data)
            {
                Data = data;
            }
        }

        internal class DLEnumerator : IEnumerator<T>
        {
            private Entry _head;
            private Entry _temp;

            public DLEnumerator(Entry source)
            {
                _head = source;
                _temp = new Entry(0) { Next = _head };    // Try bool.
            }

            public object Current
            {
                get { return _temp; }
                set { _temp = (Entry)value; }
            }

            T IEnumerator<T>.Current 
            {
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                bool result = false;

                if (Current is Entry one && one.Next != null)
                {
                    Current = one.Next;
                    result = true;
                }

                return result;
            }

            public void Reset()
            {
                Current = _head;
            }
        }
    }
}
