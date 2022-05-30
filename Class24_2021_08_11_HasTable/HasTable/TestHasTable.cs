using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasTable
{
    internal class TestHasTable<K, V> : IDictionary<K, V> 
    {
        private K[] _keys;
        private V[] _values;
        private int _amount;

        public TestHasTable(int capacity = 100)
        {
            _items = new T[capacity];
        }

        public void Add(T source)
        {
            if (source is KeyValuePair<Key, Value> key)
            {
                int index = key.Key.GetHashCode() % _items.Length;

                _items[index] = source;

                _amount++;
            }
        }

        public bool Exists(Key source)
        {
            Key key = null;

            int index = source.GetHashCode() % _items.Length;

            if (_items[index] is KeyValuePair<Key, Value> one)
            {
                key = one.Key;
            }

            return (key != null) && source.Equals(key);
        }

        public Value GetValue(Key source)
        {
            Value data = default;

            int index = source.GetHashCode() % _items.Length;

            if (_items[index] is KeyValuePair<Key, Value> one)
            {
                data = one.Value;
            }

            return data;
        }

        #region IDictionary

        public Value this[Key key]
        {
            get => GetValue(key);
            set => throw new NotImplementedException();
        }

        public ICollection<Key> Keys => throw new NotImplementedException();

        public ICollection<Value> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(Key key, Value value)
        {
            Add(new KeyValuePair<Key, Value>(key, value));
        }

        public void Add(KeyValuePair<Key, Value> item)
        {
            int index = item.Key.GetHashCode() % _items.Length;

            if (_items[index] is KeyValuePair<Key, Value>)
            {
                _items[index] = item;
            }

            _amount++;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<Key, Value> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(Key key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<Key, Value>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<Key, Value>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Key key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<Key, Value> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(Key key, [MaybeNullWhen(false)] out Value value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
