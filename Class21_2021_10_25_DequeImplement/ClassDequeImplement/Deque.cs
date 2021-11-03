﻿using System;

namespace ClassDequeImplement
{
    internal class Deque
    {
        private Entry _head = null;
        private Entry _tail = null;

        public bool IsEmpty => _head is null;

        public void Add(int data, Position source = Position.Back)
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
            _tail.Previous = node;
            node.Next = _tail;
            _tail = node;
        }

        private void AddToFront(Entry node)
        {
            _head.Next = node;
            node.Previous = _head;
            _head = node;
        }

        public Entry Get(Position source = Position.Back)
        {
            if (IsEmpty)
            {
                throw new NoObjectException("Deque is empty.");
            }

            Entry result = null;

            switch (source)
            {
                case Position.Front:
                    result = _head;
                    _head = _head.Previous;
                    if (_head != null)
                    {
                        _head.Next = null; 
                    }
                    else
                    {
                        _tail = null;
                    }

                    break;
                case Position.Back:
                    result = _tail;
                    _tail = _tail.Next;
                    if (_tail != null)
                    {
                        _tail.Previous = null; 
                    }
                    else
                    {
                        _head = null;
                    }

                    break;
                default:
                    break;
            }

            return result;
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
    }
}
