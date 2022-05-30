using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Class22_BinaryTree_2021_11_01
{
    internal class Tree<K, V> : IDictionary<K, V>
        where K : IComparable<K>
        where V : ICloneable
    {
        private Node _root = null;
        private int _amount = 0;
        
        #region IDictionary

        public ICollection<K> Keys 
        {
            get => GetKeys(_root);
        }

        public ICollection<V> Values
        {
            get => GetValues(_root);
        }

        private List<K> GetKeys(Node root)
        {
            Stack<Node> stack = new Stack<Node>(_amount);
            stack.Push(root);

            List<K> keys = new List<K>(_amount);

            bool flag = true;

            while (stack.Count > 0)
            {
                Node node = stack.Pop();

                if (flag)
                {
                    keys.Add(node.Key);
                    flag = false;
                }

                if (node._right != null)
                {
                    stack.Push(node._right);
                    keys.Add(node._right.Key);
                }

                if (node._left != null)
                {
                    stack.Push(node._left);
                    keys.Add(node._left.Key);
                }
            }

            return keys;
        }

        private List<V> GetValues(Node root)
        {
            Stack<Node> stack = new Stack<Node>(_amount);
            stack.Push(root);

            List<V> values = new List<V>(_amount);

            bool flag = true;

            while (stack.Count > 0)
            {
                Node node = stack.Pop();

                if (flag)
                {
                    values.Add(node.Info);
                    flag = false;
                }

                if (node._right != null)
                {
                    stack.Push(node._right);
                    values.Add(node._right.Info);
                }

                if (node._left != null)
                {
                    stack.Push(node._left);
                    values.Add(node._left.Info);
                }
            }

            return values;
        }

        public int Count => _amount;

        public bool IsReadOnly => false;

        public V this[K key] 
        { 
            get => Search(key).Info; 
            set => Search(key).Info = (V)value.Clone();
        }

        public bool ContainsKey(K key)
        {
            return Search(key) != null;
        }

        public bool Remove(K key)
        {
            return Delete(key);
        }

        public bool TryGetValue(K key, out V value)
        {
            Node node = Search(key);
            bool found = false;

            if (node is null)
            {
                value = default;
            }
            else
            {
                value = node.Info;
                found = true;
            }

            return found;
        }

        public void Add(KeyValuePair<K, V> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            _amount = 0;
        }

        public bool Contains(KeyValuePair<K, V> item)
        {
            return Search(item.Key) != null;
        }

        public void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<K, V> item)
        {
            Delete(item.Key);

            return Search(item.Key) != null;
        }

        private Node _iter = null;

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            if (_iter is null)
            {
                _iter = _root;
            };

            yield return new KeyValuePair<K, V>(_iter.Key, _iter.Info);

            if (_iter._left != null)
            {
                foreach (KeyValuePair<K, V> i in PreOrder(_iter._left))
                {
                    yield return i;
                }
            }

            if (_iter._right != null)
            {
                foreach (KeyValuePair<K, V> i in PreOrder(_iter._right))
                {
                    yield return i;
                }
            }
        }

        public IEnumerable<K> PreOrder(Node root)
        {
            if (_iter is null)
            {
                _iter = root;
            };

            yield return _iter.Key;

            if (_iter._left != null)
            {
                foreach (K i in PreOrder(_iter._left))
                {
                    yield return i;
                }
            }
                
            if (_iter._right != null)
            {
                foreach (K i in PreOrder(_iter._right))
                {
                    yield return i;
                }
            }
        }

        internal struct KeyValuePair
        {
            private K _key;
            private V _value;

            public KeyValuePair(K key, V value)
            {
                _key = key;
                _value = value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        public void Add(K key, V info)
        {
            Add(ref _root, key, info);
            ++_amount;
        }

        private static void Add(ref Node root, K key, V info)
        {
            if (root is null)
            {
                root = new Node(key, info);
                return;
            }
            else
            {
                if (root.Key.CompareTo(key) < 0)
                {
                    Add(ref root._right,key, info);

                    if (CalculateHeight(root._right) - CalculateHeight(root._left) > 1)
                    {
                        if (CalculateHeight(root._right._right) < CalculateHeight(root._right._left))
                        {
                            TurnRight(ref root._right);
                        }

                        TurnLeft(ref root);
                    }
                }
                else
                {
                    Add(ref root._left, key, info);

                    if (CalculateHeight(root._left) - CalculateHeight(root._right) > 1)
                    {
                        if (CalculateHeight(root._left._left) < CalculateHeight(root._left._right))
                        {
                            TurnLeft(ref root._left);
                        }

                        TurnRight(ref root);
                    }
                }
            }
            
            SetBalance(root);
        }

        #region Delete

        public bool Delete(K key)
        {
            bool result = true;

            Node previous = _root;
            Node current = _root;

            // Find current & previous items.
            while ((current != null) && (current.Key.CompareTo(key) != 0))
            {
                previous = current;

                if (current.Key.CompareTo(key) < 0)
                {
                    current = current._right;
                }
                else
                {
                    current = current._left;
                }
            }

            // First case.
            if ((current._left is null) && (current._right is null))
            {
                if (previous._left == current)
                {
                    previous._left = null;
                }
                else
                {
                    previous._right = null;
                }

                result = true;
            }

            // Second case.
            else if (current._right is null)
            {
                if (previous._right == current)
                {
                    previous._right = current._left;
                }
                else
                {
                    previous._left = current._left;
                }

                result = true;
            }

            // Second case.
            else if (current._left is null)
            {
                if (previous._right == current)
                {
                    previous._right = current._right;
                }
                else
                {
                    previous._left = current._right;
                }

                result = true;
            }

            // Third case.
            else if ((current._right != null) && (current._left != null))
            {
                Node objective = current;
                Node prevCurr = current;

                current = current._right;

                while (current._left != null)    // Find min.
                {
                    prevCurr = current;
                    current = current._left;
                }

                if (objective != _root)
                {
                    if (previous._left == objective)
                    {
                        previous._left = current;
                    }
                    else
                    {
                        previous._right = current;
                    }
                }
                else
                {
                    _root = current;
                }

                if (current._right is null)
                {

                    current._left = objective._left;

                    if (objective._right != current)
                    {
                        current._right = objective._right;
                    }
                    prevCurr._left = null;
                }
                else
                {
                    current._left = objective._left;

                    if (prevCurr != objective)
                    {
                        prevCurr._left = current._right;
                        current._right = prevCurr;
                    }

                }

                result = true;

            }

            return result;
        } 

        #endregion

        public Node Search(K key)
        {
            return Search(_root, key); ;
        }

        private static Node Search(Node source, K data)
        {
            while ((source != null) && (source.Key.CompareTo(data) != 0))
            {
                if (source.Key.CompareTo(data) < 0)
                {
                    source = source._right;
                }
                else
                {
                    source = source._left;
                }
            }

            return source;
        }

        public void Print()
        {
            Print(_root);
        }

        private static void Print(Node root)
        {
            if (root is null)
            {
                return;
            }

            Print(root._left);

            Console.Write("{0} ", root.Key);

            Print(root._right);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            ToString(_root, result);

            return result.ToString();
        }

        public static void ToString(Node root, StringBuilder result, int level=0)
        {
            if (root is null)
            {
                return;
            }

            ToString(root._right, result, level+1);

            for (int i = 0; i < level; i++)
            {
                result.Append("\t");
            }

            result.AppendFormat("{0}\n", root.Key);

            ToString(root._left, result, level+1);
        }

        public int GetHeight()
        {
            return CalculateHeight(_root);
        }

        private static int CalculateHeight(Node source)
        {
            int result = 0;

            if (source is null)
            {
                return result;
            }

            int heightL = CalculateHeight(source._left);
            int heightR = CalculateHeight(source._right);

            if (heightL > heightR)
            {
                result = heightL + 1;
            }
            else
            {
                result = heightR + 1;
            }

            return result;
        }

        private static void SetBalance(Node source)
        {
            if (source != null)
            {
                source._balance = CalculateHeight(source._right)
                        - CalculateHeight(source._left);
            }
        }

        private static void TurnLeft(ref Node root)
        {
            Node rightTree = null;
            Node rightTreeLeft = null;

            rightTree = root._right;
            rightTreeLeft = rightTree._left;

            rightTree._left = root;
            root._right = rightTreeLeft;
            root = rightTree;

            SetBalance(root._left);
            SetBalance(root);
        }

        private static void TurnRight(ref Node root)
        {
            Node leftTree = null;
            Node leftTreeRight = null;

            leftTree = root._left;
            leftTreeRight = leftTree._right;

            leftTree._right = root;
            root._left = leftTreeRight;
            root = leftTree;

            SetBalance(root._right);
            SetBalance(root);
        }

        

        public class Node
        {
            public Node _left = null;
            public Node _right = null;
            public int _balance = 0;

            public K Key { get; private set; }
            public V Info { get; set; }

            public Node(K key, V info)
            {
                Key = key;
                Info = info;
            }
        }

        
    }
}
