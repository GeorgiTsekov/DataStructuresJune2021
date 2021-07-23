namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            if (this.LeftChild != null)
            {
                this.LeftChild.Parent = this;
            }
            this.RightChild = rightChild;
            if (this.RightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            var firstNodeAncestors = this.GetAncestors(this.Search(first));
            var secondNodeAncestors = this.GetAncestors(this.Search(second));

            var result = firstNodeAncestors.Intersect(secondNodeAncestors).FirstOrDefault();

            return result;
        }

        private List<T> GetAncestors(IAbstractBinaryTree<T> node)
        {
            var list = new List<T>();

            while (node != null)
            {
                list.Add(node.Value);
                node = node.Parent;
            }

            return list;
        }

        private IAbstractBinaryTree<T> Search(T element)
        {
            var node = this;
            while (node != null)
            {
                if (IsGreater(node.Value, element))
                {
                    node = node.LeftChild;
                }
                else if (IsSmaller(node.Value, element))
                {
                    node = node.RightChild;
                }
                else
                {
                    return node;
                }
            }

            return null;
        }

        private bool IsSmaller(T value, T element)
        {
            return value.CompareTo(element) < 0;
        }

        private bool IsGreater(T value, T element)
        {
            return value.CompareTo(element) > 0;
        }
    }
}
