using System;
using System.Collections.Generic;
namespace P05_BinarySearchTree
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private Node root;

        public BinarySearchTree()
        {
            this.root = null;
        }

        private BinarySearchTree(Node node)
        {
            this.Copy(node);
        }

        private void Copy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.Copy(node.Left);
            this.Copy(node.Right);
        }

        private class Node
        {
            public T Value { get; set; }

            public Node Left { get; set; }

            public Node Right { get; set; }

            public Node(T value)
            {
                this.Value = value;
            }
        }

        public void Insert(T value)
        {
            if (this.root == null)
            {
                this.root = new Node(value);
                return;
            }

            // the two nodes are used for the traversal of the tree
            Node parent = null;
            Node current = this.root;

            while (current != null)
            {
                int compare = current.Value.CompareTo(value);

                if (compare > 0) // current.Value > value
                {
                    parent = current;
                    current = current.Left;
                }
                else if (compare < 0) // current.Value < value
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    return;
                }
            }

            if (parent.Value.CompareTo(value) > 0) // parrent.Value > value
            {
                parent.Left = new Node(value);
            }
            else // parrent.Value < value
            {
                parent.Right = new Node(value);
            }
        }

        public bool Contains(T value)
        {
            Node current = this.root;

            while (current != null)
            {

                if (current.Value.CompareTo(value) > 0) // current.Value > value
                {
                    current = current.Left;
                }
                else if (current.Value.CompareTo(value) < 0) // current.Value < value
                {
                    current = current.Right;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public void DeleteMin()
        {
            if (this.root == null)
            {
                return;
            }

            if (this.root.Left == null && this.root.Right == null)
            {
                this.root = null;
                return;
            }

            Node parrent = null;
            Node current = this.root;


            while (current.Left != null)
            {
                parrent = current;
                current = current.Left;
            }

            if (current.Right != null)
            {
                parrent.Left = current.Right;
            }
            else
            {
                parrent.Left = null;
            }
        }

        public BinarySearchTree<T> Search(T item)
        {
            Node current = this.root;

            while (current != null)
            {
                if (current.Value.CompareTo(item) > 0) // current.Value > item
                {
                    current = current.Left;
                }
                else if (current.Value.CompareTo(item) < 0) // current.Value < item
                {
                    current = current.Right;
                }
                else // current.Value == item
                {
                    return new BinarySearchTree<T>(current);
                }
            }

            return null;
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            List<T> result = new List<T>();

            this.Range(this.root, result, startRange, endRange);

            return result;
        }

        private void Range(Node node, List<T> result, T start, T end)
        {
            if (node == null)
            {
                return;
            }

            //check if the value is within range
            int compareLow = node.Value.CompareTo(start);
            int compareHigh = node.Value.CompareTo(end);
            if (compareLow > 0) // node.Value > start
            {
                this.Range(node.Left, result, start, end);
            }
            if (compareLow >= 0 && compareHigh <= 0) // add value if within range
            {
                result.Add(node.Value);
            }
            if (compareHigh < 0) //node.Value < end
            {
                this.Range(node.Right, result, start, end);
            }


        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }
    }
}