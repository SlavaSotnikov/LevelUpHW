using System;
using System.Collections;
using System.Collections.Generic;

namespace Class21_DoublyLinkedList
{
    internal class DoublyLinkedList<T> : IEnumerable<T>
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
                _current = _head;

                while (_current.Next != null)
                {
                    //source.CompareTo();    // TODO: Read IComparable.

                    if (source.CompareTo(_current.Data) == 0)
                    {
                        result = true;
                        break;
                    }

                    if (source.CompareTo(_current.Next.Data) == 0)
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

        public void Add(T data, Position source = Position.Back)
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
                        AddToFront(node);
                        break;

                    case Position.Back:
                        AddToBack(node);
                        break;

                    default:
                        break;
                }
            }
        }

        private void AddToBack(Entry node)
        {
            node.Previous = _tail;
            _tail.Next = node;
            _tail = node;
        }

        private void AddToFront(Entry node)
        {
            _head.Previous = node;
            node.Next = _head;
            _head = node;
        }

        public bool Insert(T element, T data)
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

        public bool Delete(T source)
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
                if (_current.Data.CompareTo(_temp.Data) < 0)
                {
                    while ((_current.Data.CompareTo(_temp.Data) < 0) && (_current.Previous != null))
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

        private IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new DLEnumerator(_head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #region Entry

        internal class Entry
        {
            public T Data { get; set; }
            public Entry Previous { get; set; }
            public Entry Next { get; set; }

            public Entry(T data)
            {
                Data = data;
            }
        }

        #endregion

        #region Enumerator

        private class DLEnumerator : IEnumerator<T>
        {
            private Entry _head;
            private bool _result = false;

            public DLEnumerator(Entry source)
            {
                _head = source;
            }

            public object Current{ get { return _head; } }

            T IEnumerator<T>.Current
            {
                get
                {
                    return _head.Data;
                }
            }

            public bool MoveNext()
            {
                if (_result == false)
                {
                    _result = true;
                }
                else
                {
                    if (_head.Next is null)
                    {
                        _result = false;
                    }

                    _head = _head.Next;
                }

                return _result;
            }

            public void Reset() {}

            public void Dispose() {}
        } 

        #endregion
    }
}
