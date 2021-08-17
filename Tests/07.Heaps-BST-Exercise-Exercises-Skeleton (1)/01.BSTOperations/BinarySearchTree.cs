namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            Root = root;
        }

        public Node<T> Root { get; private set; }

        public int Count { get; private set; }

        public bool Contains(T element)
        {
            if (this.Count == 0)
            {
                return false;
            }

            Node<T> node = this.Root;
            while (node != null)
            {
                if (node.Value.CompareTo(element) > 0)
                {
                    node = node.LeftChild;
                }
                else if (node.Value.CompareTo(element) < 0)
                {
                    node = node.RightChild;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public void Insert(T element)
        {
            if (this.Count == 0)
            {
                this.Root = new Node<T>(element);
                this.Count++;
                return;
            }

            Node<T> parentNode = null;
            var node = this.Root;
            while (node != null)
            {
                parentNode = node;

                if (node.Value.CompareTo(element) > 0)
                {
                    node = node.LeftChild;
                }
                else
                {
                    node = node.RightChild;
                }
            }

            if (parentNode.Value.CompareTo(element) > 0)
            {
                parentNode.LeftChild = new Node<T>(element);
            }
            else
            {
                parentNode.RightChild = new Node<T>(element);
            }

            this.Count++;
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            if (this.Count == 0)
            {
                return null;
            }

            Node<T> node = this.Root;
            while (node != null)
            {
                if (node.Value.CompareTo(element) > 0)
                {
                    node = node.LeftChild;
                }
                else if (node.Value.CompareTo(element) < 0)
                {
                    node = node.RightChild;
                }
                else
                {
                    return new BinarySearchTree<T>(node);
                }
            }

            return null;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, this.Root);
        }

        private void EachInOrder(Action<T> action, Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(action, node.LeftChild);
            action(node.Value);
            this.EachInOrder(action, node.RightChild);
        }

        public List<T> Range(T lower, T upper)
        {
            var result = new List<T>();

            return Range(lower, upper, this.Root, result);
        }

        private List<T> Range(T startRange, T endRange, Node<T> node, List<T> result)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value.CompareTo(startRange) >= 0)
            {
                Range(startRange, endRange, node.LeftChild, result);
            }

            if (node.Value.CompareTo(startRange) >= 0 && node.Value.CompareTo(endRange) <= 0)
            {
                result.Add(node.Value);
            }

            if (node.Value.CompareTo(endRange) <= 0)
            {
                Range(startRange, endRange, node.RightChild, result);
            }

            return result;
        }

        public void DeleteMin()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            Node<T> parentNode = null;
            Node<T> node = this.Root;
            while (node != null)
            {
                if (node.LeftChild == null && node.RightChild != null)
                {
                    parentNode = node;

                    node = node.RightChild;
                    break;
                }
                else
                {
                    if (node.LeftChild != null)
                    {
                        parentNode = node;
                    }

                    node = node.LeftChild;
                }
            }

            if (parentNode.LeftChild != null)
            {
                parentNode.LeftChild = null;
            }
            else if (parentNode.RightChild != null)
            {
                var rightChild = parentNode.RightChild;
                parentNode.RightChild = null;
                parentNode.Value = rightChild.Value;
            }
            this.Count--;
        }

        public void DeleteMax()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            this.Root.RightChild = this.DeleteMax(this.Root.RightChild);
        }

        private Node<T> DeleteMax(Node<T> node)
        {
            if (node.RightChild == null)
            {
                this.Count--;
                return node.LeftChild;
            }

            node.RightChild = this.DeleteMax(node.RightChild);
            return node;
        }

        public int GetRank(T element)
        {
            throw new NotImplementedException();
        }
    }
}
