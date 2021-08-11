namespace _04.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            this.Root = root;
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => this.Root.Value;

        public bool Contains(T element)
        {
            throw new NotImplementedException();
        }

        public void Insert(T value, Node<T> node)
        {
            if (node == null)
            {
                node = new Node<T>(value, null, null);
                Root = node;
                return;
            }

            if (node.Value.CompareTo(value) > 0)
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = new Node<T>(value, null, null);
                    return;
                }
                Insert(value, node.LeftChild);
            }
            else
            {
                if (node.RightChild == null)
                {
                    node.RightChild = new Node<T>(value, null, null);
                    return;
                }
                Insert(value, node.RightChild);
            }
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            throw new NotImplementedException();
        }
    }
}
