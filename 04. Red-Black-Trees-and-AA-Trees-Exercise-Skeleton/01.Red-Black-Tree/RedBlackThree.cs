namespace _01.Red_Black_Tree
{
    using System;
    using System.Collections.Generic;

    public class RedBlackTree<T> 
        : IBinarySearchTree<T> where T : IComparable
    {
        private const bool Red = true;
        private const bool Black = false;

        private Node root;

        public RedBlackTree()
        {
        }

        public int Count => this.root != null ? this.root.Count : 0;

        private int NodeCount(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + NodeCount(node.Left) + NodeCount(node.Right);
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
            this.root.Color = Black;
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = Insert(element, node.Right);
            }

            if (this.IsRed(node.Right) && !this.IsRed(node.Left))
            {
                node = this.RotateLeft(node);
            }
            if (this.IsRed(node.Left) && this.IsRed(node.Left.Left))
            {
                node = this.RotateRight(node);
            }
            if (this.IsRed(node.Left) && this.IsRed(node.Right))
            {
                this.SwapColors(node);
            }

            node.Count = NodeCount(node);

            return node;
        }

        private void SwapColors(Node node)
        {
            node.Color = Red;
            node.Left.Color = Black;
            node.Right.Color = Red;
        }

        private Node RotateRight(Node node)
        {
            var newNode = node.Left;
            node.Left = newNode.Right;
            newNode.Right = node;

            newNode.Color = node.Color;
            node.Color = Red;

            return newNode;
        }

        private Node RotateLeft(Node node)
        {
            var newNode = node.Right;
            node.Right = newNode.Left;
            newNode.Left = node;

            newNode.Color = node.Color;
            node.Color = Red;

            return newNode;
        }

        private bool IsRed(Node node)
        {
            if (node == null)
            {
                return false;
            }

            return node.Color == Red;
        }

        public T Select(int rank)
        {
            Node node = this.Select(rank, this.root);
            if (node == null)
            {
                throw new InvalidOperationException();
            }

            return node.Value;
        }

        private Node Select(int rank, Node node)
        {
            if (node == null)
            {
                return null;
            }

            int leftCount = this.NodeCount(node.Left);
            if (leftCount == rank)
            {
                return node;
            }

            if (leftCount > rank)
            {
                return this.Select(rank, node.Left);
            }

            return this.Select(rank - (leftCount + 1), node.Right);
        }

        public int Rank(T element)
        {
            return this.Rank(element, this.root);
        }

        private int Rank(T element, Node node)
        {
            if (node == null)
            {
                return 0;
            }

            int compare = element.CompareTo(node.Value);

            if (compare < 0)
            {
                return this.Rank(element, node.Left);
            }

            if (compare > 0)
            {
                return 1 + this.NodeCount(node.Left) + this.Rank(element, node.Right);
            }

            return this.NodeCount(node.Left);
        }

        public bool Contains(T element)
        {
            if (this.Count == 0)
            {
                return false;
            }

            var node = this.root;

            while (node != null)
            {
                if (node.Value.Equals(element))
                {
                    return true;
                }
                else if (node.Value.CompareTo(element) > 0)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }

            return false;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            if (this.Count == 0)
            {
                return null;
            }

            var node = this.root;

            while (node != null)
            {
                if (node.Value.Equals(element))
                {
                    var result = new RedBlackTree<T>();
                    result.Insert(node.Value);
                    return result;
                }
                else if (node.Value.CompareTo(element) > 0)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }

            return null;
        }

        public void DeleteMin()
        {
            this.root = DeleteMin(this.root);
        }

        private Node DeleteMin(Node node)
        {
            if (node.Left == null)
            {
                return node.Right;
            }

            node.Left = DeleteMin(node.Left);
            node.Count = NodeCount(node);

            return node;
        }

        public void DeleteMax()
        {
            this.root = this.DeleteMax(this.root);
        }

        private Node DeleteMax(Node node)
        {
            if (node.Right == null)
            {
                return node.Left;
            }

            node.Right = DeleteMax(node.Right);
            node.Count = NodeCount(node);

            return node;
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            return null;
        }

        public  void Delete(T element)
        {
            this.root = this.Delete(element, this.root);
        }

        private Node Delete(T element, Node node)
        {
            if (node == null)
            {
                return null;
            }

            int compare = element.CompareTo(node.Value);
            if (compare < 0)
            {
                node.Left = this.Delete(element, node.Left);
            }
            else if (compare > 0)
            {
                node.Right = this.Delete(element, node.Right);
            }
            else
            {
                if (node.Right == null)
                {
                    return node.Left;
                }
                else if (node.Left == null)
                {
                    return node.Right;
                }

                var copyNode = node;
                node = FindSmallestChild(copyNode.Right);
                node.Right = DeleteMin(node.Right);
                node.Left = copyNode.Left;
            }

            node.Count = NodeCount(node);

            return node;
        }

        private Node FindSmallestChild(Node node)
        {
            if (node.Left == null)
            {
                return node;
            }

            return FindSmallestChild(node.Left);
        }

        public T Ceiling(T element)
        {
            return this.Select(this.Rank(element) + 1);
        }

        public T Floor(T element)
        {
            return this.Select(this.Rank(element) - 1);
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, this.root);
        }

        private void EachInOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;
            }

            EachInOrder(action, node.Left);
            action(node.Value);
            EachInOrder(action, node.Right);
        }

        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Color = Red;
            }

            public T Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public bool Color { get; set; }
            public int Count { get; set; }
        }
    }
}