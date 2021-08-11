namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value
            , IAbstractBinaryTree<T> leftChild
            , IAbstractBinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            return DFSPreOrder(this, 0);
        }

        public string DFSPreOrder(IAbstractBinaryTree<T> node, int indent)
        {
            string result = $"{new string(' ', indent) }{node.Value}\r\n";
            if (node.LeftChild != null)
            {
                result += DFSPreOrder(node.LeftChild, indent + 2);
            }
            if (node.RightChild != null)
            {
                result += DFSPreOrder(node.RightChild, indent + 2);
            }

            return result;
        }
        public string DFSInOrder(IAbstractBinaryTree<T> node, int indent)
        {
            string result = "";
            if (node.LeftChild != null)
            {
                result += DFSInOrder(node.LeftChild, indent + 3);
            }

            result += $"{new string(' ', indent) }{node.Value}\n";

            if (node.RightChild != null)
            {
                result += DFSInOrder(node.RightChild, indent + 3);
            }

            return result;
        }

        public string DFSPostOrder(IAbstractBinaryTree<T> node, int indent)
        {
            string result = "";
            if (node.LeftChild != null)
            {
                result += DFSPostOrder(node.LeftChild, indent + 3);
            }

            if (node.RightChild != null)
            {
                result += DFSPostOrder(node.RightChild, indent + 3);
            }

            result += $"{new string(' ', indent) }{node.Value}\n";
            return result;
        }

        public List<IAbstractBinaryTree<T>> InOrder()
        {
            throw new NotImplementedException();
        }

        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            throw new NotImplementedException();
        }

        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            throw new NotImplementedException();
        }

        public void ForEachInOrder(Action<T> action)
        {
            throw new NotImplementedException();
        }
    }
}
