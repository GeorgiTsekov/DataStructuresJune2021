﻿namespace _02.LowestCommonAncestor
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

            return firstNodeAncestors.Intersect(secondNodeAncestors).FirstOrDefault();
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

        public IAbstractBinaryTree<T> Search(T element)
        {
            var node = this;
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
                    return node;
                }
            }

            return null;
        }
    }
}
