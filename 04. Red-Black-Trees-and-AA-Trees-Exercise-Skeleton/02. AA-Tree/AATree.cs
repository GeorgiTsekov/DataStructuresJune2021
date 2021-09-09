namespace _02._AA_Tree
{
    using System;

    public class AATree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private Node<T> root;

        public int CountNodes()
        {
            return this.CountNodes(this.root);
        }

        private int CountNodes(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + CountNodes(node.Left) + CountNodes(node.Right);
        }

        public bool IsEmpty()
        {
            return this.root == null;
        }

        public void Clear()
        {
            this.root = null;
        }

        public void Insert(T element)
        {
            this.root = Insert(element, this.root);
        }

        private Node<T> Insert(T element, Node<T> node)
        {
            if (node == null)
            {
                node = new Node<T>(element);
            }
            else if (element.CompareTo(node.Element) < 0)
            {
                node.Left = Insert(element, node.Left);
            }
            else
            {
                node.Right = Insert(element, node.Right);
            }

            node = this.Skew(node);
            node = this.Split(node);

            return node;
        }

        private Node<T> Split(Node<T> node)
        {
            if (node.Right == null || node.Right.Right == null)
            {
                return node;
            }
            else if(node.Right.Right.Level == node.Level)
            {
                node = Promote(node);
            }

            return node;
        }

        private Node<T> Promote(Node<T> node)
        {
            var newNode = node.Right;
            node.Right = newNode.Left;
            newNode.Left = node;
            newNode.Level++;

            return newNode;
        }

        private Node<T> Skew(Node<T> node)
        {
            if (node.Left != null && node.Left.Level == node.Level)
            {
                node = RotateLeft(node);
            }

            return node;
        }

        private Node<T> RotateLeft(Node<T> node)
        {
            var newNode = node.Left;
            node.Left = newNode.Right;
            newNode.Right = node;

            return newNode;
        }

        public bool Search(T element)
        {
            if (this.IsEmpty())
            {
                return false;
            }

            var node = this.root;

            while (node != null)
            {
                if (node.Element.Equals(element))
                {
                    return true;
                }
                else if (node.Element.CompareTo(element) > 0)
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

        public void InOrder(Action<T> action)
        {
            this.InOrder(action, this.root);
        }

        private void InOrder(Action<T> action, Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            InOrder(action, node.Left);
            action(node.Element);
            InOrder(action, node.Right);
        }

        public void PreOrder(Action<T> action)
        {
            this.PreOrder(action, this.root);
        }

        private void PreOrder(Action<T> action, Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            action(node.Element);
            PreOrder(action, node.Left);
            PreOrder(action, node.Right);

        }

        public void PostOrder(Action<T> action)
        {
            this.PostOrder(action, this.root);
        }

        private void PostOrder(Action<T> action, Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            PostOrder(action, node.Left);
            PostOrder(action, node.Right);
            action(node.Element);

        }
    }
}