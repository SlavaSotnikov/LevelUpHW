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
                Add(ref root._right, info);
            }
            else
            {
                Add(ref root._left, info);
            }
        }

        public bool Delete(T data)
        {
            bool result = true;

            Node previous = _root;
            Node current = _root;

            // Find current & previous items.
            while ((current != null) && (current.Data.CompareTo(data) != 0))
            {
                previous = current;

                if (current.Data.CompareTo(data) < 0)
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

        public Node Search(T data)
        {
            return Search(_root, data); ;
        }

        private static Node Search(Node source, T data)
        {
            while ((source != null) && (source.Data.CompareTo(data) != 0))
            {
                if (source.Data.CompareTo(data) < 0)
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

            Console.Write("{0} ", root.Data);

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

            result.AppendFormat("{0}\n", root.Data);

            ToString(root._left, result, level+1);
        }

        public class Node
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
