using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class22_BinaryTree_2021_11_01
{
    internal class Tree<T>
        where T : IComparable<T>
    {
        private Node _root = null;

        public void Add(T info)
        {
            Add(ref _root, info);
        }

        private static void Add(ref Node root, T info)
        {
            if (root is null)
            {
                root = new Node(info);
                return;
            }

            if (root.Data.CompareTo(info) < 0)
            {
                Add(ref root._left, info);
            }
            else
            {
                Add(ref root._right, info);
            }
        }

        private class Node
        {
            public Node _left = null;
            public Node _right = null;

            public T Data { get; private set; }

            public Node(T info)
            {
                Data = info;
            }
        }
    }
}
