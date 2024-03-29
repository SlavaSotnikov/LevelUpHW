﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace HasTable
{
    internal class TestHasTable : IDictionary<Key, bool>, ISet<Key>
    {
        private Key[] _items;
        private int _amount;

        public TestHasTable(int capacity = 100)
        {
            _items = new Key[capacity];
        }

        public void Add(Key key)
        {
            int index = key.GetHashCode() % _items.Length;

            _items[index] = key;

            _amount++;
        }

        public bool Exists(Key key)
        {
            int index = key.GetHashCode() % _items.Length;

            return (_items[index] != null) && key.Equals(_items[index]);
        }

        private IEnumerable<Key> GetKeys()    // TODO: Try yield.
        {
            //List<Key> keys = new List<Key>();

            foreach (var item in this)
            {
                //keys.Add(item);
                yield return item;
            }

            //return keys;
        }

        private List<bool> GetValues()
        {
            List<bool> values = new List<bool>();

            foreach (var item in this)
            {
                values.Add(true);
            }

            return values;
        }

        #region IDictionary

        public bool this[Key key]
        {
            get => Exists(key);
            set => throw new NotSupportedException(); 
        }

        public ICollection<Key> Keys => new List<Key>(GetKeys());

        public ICollection<bool> Values => GetValues();

        public int Count => _amount;

        public bool IsReadOnly => false;

        public void Add(Key key, bool value)
        {
            Add(key);
        }

        public void Add(KVPair<Key, bool> item)
        {
            Add(item.Key);
        }

        public void Clear()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                _items[i] = null;
            }
        }

        public bool Contains(KVPair<Key, bool> item)
        {
            return Exists(item.Key);
        }

        public bool ContainsKey(Key key)
        {
            return Exists(key);
        }

        public void CopyTo(KVPair<Key, bool>[] array, int arrayIndex)
        {
            arrayIndex -= 1;

            foreach (Key item in this)
            {
                array[++arrayIndex] = new KVPair<Key, bool>(item, true);
            }
        }

        public bool Remove(Key key)
        {
            bool result = false;

            if (key != null)
            {
                int index = key.GetHashCode() % _items.Length;

                if (_items[index] != null && key.Equals(_items[index]))
                {
                    _items[index] = null;
                    result = true;
                } 
            }

            return result;
        }

        public bool Remove(KVPair<Key, bool> item)
        {
            return Remove(item.Key);
        }

        public bool TryGetValue(Key key, out bool value)
        {
            bool result = false;
            value = false;

            if (key != null)
            {
                int index = key.GetHashCode() % _items.Length;

                if (_items[index] != null && key.Equals(_items[index]))
                {
                    value = true;
                    result = true;
                } 
            }

            return result;
        }

        public IEnumerator<Key> GetEnumerator()
        {
            //for (int i = 0; i < _items.Length; i++)
            //{
            //    yield return _items[i];
            //}

            return new HasTableIterator<Key>(_amount, _items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #region System.Collections.Generic.KeyValuePair

        public void Add(KeyValuePair<Key, bool> item)
        {
            Add(item.Key);
        }

        public bool Contains(KeyValuePair<Key, bool> item)
        {
            return Exists(item.Key);
        }

        public void CopyTo(KeyValuePair<Key, bool>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<Key, bool> item)
        {
            throw new NotImplementedException();
        }

        IEnumerator<KeyValuePair<Key, bool>> IEnumerable<KeyValuePair<Key, bool>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region ISet

        bool ISet<Key>.Add(Key item)
        {
            if (Exists(item))
            {
                return false; 
            }

            Add(item);

            return true;
        }

        public void UnionWith(IEnumerable<Key> other)
        {
            foreach (var item in other)
            {
                if (Exists(item))
                {
                    continue;
                }

                Add(item);
            }
        }

        public void IntersectWith(IEnumerable<Key> other)
        {
            List<Key> common = new List<Key>();
            int amount = 0;

            foreach (var item in other)
            {
                if (Exists(item))
                {
                    common.Add(item);
                    ++amount;
                }
            }

            Clear();

            for (int i = 0; i < amount; i++)
            {
                Add(common[i]);
            }
        }

        public void ExceptWith(IEnumerable<Key> other)
        {
            foreach (var item in other)
            {
                if (Exists(item))
                {
                    Remove(item);
                }
            }
        }

        public void SymmetricExceptWith(IEnumerable<Key> other)
        {
            foreach (var item in other)
            {
                if (Exists(item))
                {
                    Remove(item);
                }
                else
                {
                    Add(item);
                }
            }
        }

        public bool IsSubsetOf(IEnumerable<Key> other)
        {
            bool result = true;

            foreach (var item in this)    // TODO: foreach other.
            {
                if (!Exists(item))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public bool IsSupersetOf(IEnumerable<Key> other)    // TODO: Refactor
        {
            bool result = true;

            foreach (var item in other)
            {
                if (!Exists(item))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public bool IsProperSupersetOf(IEnumerable<Key> other)
        {
            return IsSubOrSuper(other);
        }

        public bool IsProperSubsetOf(IEnumerable<Key> other)
        {
            return !IsSubOrSuper(other);
        }

        private bool IsSubOrSuper(IEnumerable<Key> other)
        {
            int thisAmount = 0;
            int otherAmount = 0;

            foreach (var item in this)
            {
                ++thisAmount;
            }

            foreach (var item in other)
            {
                ++otherAmount;
            }

            return thisAmount > otherAmount;
        }

        public bool Overlaps(IEnumerable<Key> other)
        {
            bool result = false;

            foreach (var item in other)
            {
                if (Exists(item))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public bool SetEquals(IEnumerable<Key> other)
        {
            bool result = true;

            foreach (var item in other)
            {
                if (!Exists(item))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public bool Contains(Key item)
        {
            return Exists(item);
        }

        public void CopyTo(Key[] array, int arrayIndex)
        {
            arrayIndex -= 1;

            foreach (Key item in this)
            {
                array[++arrayIndex] = item;
            }
        }

        #endregion

        #region HasTableEnumerator

        internal class HasTableIterator<T> : IEnumerator<T>
        {
            private readonly T[] _keys;
            private readonly int _amount;
            private T _current;
            private int _innerAmount;
            private int _currentIndex = 0;

            public HasTableIterator(int amount, params T[] keys)
            {
                _keys = keys;
                _amount = amount;
                _innerAmount = 0;
            }

            public T Current => _current;

            object IEnumerator.Current => throw new NotImplementedException();

            public bool MoveNext()
            {
                bool result = false;

                if (_innerAmount >= _amount)
                {
                    return false;
                }

                for (; _currentIndex < _keys.Length; _currentIndex++)
                {
                    if (_keys[_currentIndex] != null)
                    {
                        _current = _keys[_currentIndex];
                        _currentIndex++;
                        _innerAmount++;
                        result = true;
                        break;
                    }
                }

                return result;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public void Dispose() { }
        }

        #endregion
    }

    public struct KVPair<K, V>
    {
        public K Key { get; private set; }
        public V Info { get; private set; }

        public KVPair(K key, V info)
        {
            Key = key;
            Info = info;
        }
    }
}
