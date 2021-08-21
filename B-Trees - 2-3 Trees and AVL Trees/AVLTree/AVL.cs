namespace AVLTree
{
    using System;

    public class AVL<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }

        public bool Contains(T item)
        {
            var node = this.Search(this.Root, item);
            return node != null;
        }

        public void Insert(T item)
        {
            this.Root = this.Insert(this.Root, item);
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.Root, action);
        }

        private Node<T> Insert(Node<T> node, T item)
        {
            if (node == null)
            {
                return new Node<T>(item);
            }

            int cmp = item.CompareTo(node.Value);
            if (cmp < 0)
            {
                node.Left = this.Insert(node.Left, item);
            }
            else if (cmp > 0)
            {
                node.Right = this.Insert(node.Right, item);
            }

            UpdateHeight(node);

            UpdateBalance(node);

            return node;
        }

        private Node<T> UpdateBalance(Node<T> node)
        {
            int balance = Height(node.Left) - Height(node.Right);
            if (balance < -1)
            {
                balance = Height(node.Right.Left) - Height(node.Right.Right);
                if (balance <= 0)
                {
                    return LeftRotation(node);
                }
                else
                {
                    node.Right = RightRotation(node.Right);
                    return LeftRotation(node);
                }
            }
            else if (balance > 1)
            {
                balance = Height(node.Left.Right) - Height(node.Left.Left);
                if (balance >= 0)
                {
                    return RightRotation(node);
                }
                else
                {
                    node.Left = LeftRotation(node.Left);
                    return RightRotation(node);
                }
            }

            return node;
        }

        private Node<T> LeftLeftRotation(Node<T> node)
        {
            return LeftRotation(node);
        }

        private Node<T> LeftRotation(Node<T> node)
        {
            var newNode = node.Right;
            node.Right = newNode.Left;
            newNode.Left = node;

            UpdateHeight(node);
            UpdateHeight(newNode);

            return newNode;
        }

        private Node<T> RightLeftRotation(Node<T> node)
        {
            node.Right = RightRightRotation(node.Right);
            return LeftLeftRotation(node);
        }

        private Node<T> RightRightRotation(Node<T> node)
        {
            return RightRotation(node);
        }

        private Node<T> RightRotation(Node<T> node)
        {
            var newNode = node.Left;
            node.Left = newNode.Right;
            newNode.Right = node;

            UpdateHeight(node);
            UpdateHeight(newNode);

            return newNode;
        }

        private Node<T> LeftRightRotation(Node<T> node)
        {
            node.Left = LeftLeftRotation(node.Left);
            return RightRightRotation(node);
        }

        private Node<T> Search(Node<T> node, T item)
        {
            if (node == null)
            {
                return null;
            }

            int cmp = item.CompareTo(node.Value);
            if (cmp < 0)
            {
                return Search(node.Left, item);
            }
            else if (cmp > 0)
            {
                return Search(node.Right, item);
            }

            return node;
        }

        private void EachInOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }

        private static int Height(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Height;
        }

        private static void UpdateHeight(Node<T> node)
        {
            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
        }
    }
}
