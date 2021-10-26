using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueList
{
    public class Queue : IEnumerable
    {
        private Entry _head = null;
        private Entry _tail = null;
        private Entry _node = null;

        public ulong Amount { get; private set; }

        public bool IsFool => Amount > 0 && _node == null;

        public void Enqueue(uint data)
        {
            try
            {
                _node = new Entry(data);
            }
            catch (Exception ex)
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

        public bool IsEmpty => _head == null;

        public IEnumerator GetEnumerator()
        {
            return new QueueEnumerator(_head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new QueueEnumerator(_head);
        }
    }

    public class Entry
    {
        public uint Data { get; set; }

        public Entry Next { get; set; }

        private decimal _weight;
        private decimal _weight1;
        private decimal _weight2;
        private decimal _weight3;

        public Entry(uint data)
        {
            Data = data;
            _weight = decimal.MaxValue;
            _weight1 = decimal.MaxValue;
            _weight2 = decimal.MaxValue;
            _weight3 = decimal.MaxValue;
        }
    }


}
