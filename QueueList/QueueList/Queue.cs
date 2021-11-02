using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueList
{
    internal class Queue<T> : IEnumerable<T>
    {
        private Entry _head = null;
        private Entry _tail = null;
        private Entry _node = null;

        public ulong Amount { get; private set; }

        public bool IsFool => Amount > 0 && _node == null;

        public void Enqueue(T data)
        {
            try
            {
                _node = new Entry(data);
            }
            catch (Exception ex)    // TODO: Ask about IsFool property;
            {
                throw new NoObjectException("A new object wasn't created!", ex);    
            }

            if (_head == null)
            {
                _head = _node;
                _tail = _node;
            }
            else
            {
                _tail.Next = _node;
                _tail = _node;
            }

            ++Amount;
        }

        public Entry Dequeue()
        {
            if (IsEmpty)
            {
                throw new MissingMemberException("No objects.");
            }

            Entry result = _head;
            _head = _head.Next;

            --Amount;

            return result;
        }

        #region IEnumerable

        private IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new QueueEnumerator(_head);
        }

        #endregion

        public void Reverse()
        {
            Entry prev = _head;
            Entry curr = _head;
            Entry head = _head;

            curr = curr.Next;
            head = curr.Next;
            prev.Next = null;

            while (curr.Next != null)
            {
                curr.Next = prev;
                prev = curr;
                curr = head;

                if (head.Next == null)
                {
                    curr.Next = prev;
                    break;
                }

                head = head.Next;
            }

            _head = curr;
        }

        

        public bool IsEmpty => _head is null;

        #region Entry

        internal class Entry
        {
            public T Data { get; set; }

            public Entry Next { get; set; }

            internal Entry(T data)
            {
                Data = data;
            }
        }

        #endregion

        #region Enumerator

        private class QueueEnumerator : IEnumerator<T>
        {
            private Entry _current;

            public QueueEnumerator(Entry head)
            {
                _current = head;
            }

            public object Current { get { return _current; } }

            T IEnumerator<T>.Current
            {
                get { return _current.Data; }
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                bool result = false;

                if (_current.Next != null)
                {
                    _current = _current.Next;
                    result = true;
                }

                return result;
            }

            public void Dispose() {}
        } 

        #endregion
    }
}
