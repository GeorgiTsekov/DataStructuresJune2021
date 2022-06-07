using CommonDataStructurse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public BinarySearchTree(Node<T> root = null)
        {
            this.Root = root;
        }

        public Node<T> Root { get; set; }

        public void Insert(T value, Node<T> node)
        {
            if (node == null)
            {
                node = new Node<T>(value);
                this.Root = node;
                return;
            }

            if (node.Value.CompareTo(value) > 0)
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = new Node<T>(value);
                    return;
                }
                Insert(value, node.LeftChild);
            }
            else
            {
                if (node.RightChild == null)
                {
                    node.RightChild = new Node<T>(value);
                    return;
                }
                Insert(value, node.RightChild);
            }
        }

        public bool Contains(T value, Node<T> node)
        {
            if (node == null)
            {
                return false;
            }

            if (node.Value.CompareTo(value) == 0)
            {
                return true;
            }

            if (node.Value.CompareTo(value) > 0)
            {
                return Contains(value, node.LeftChild);
            }
            else
            {
                return Contains(value, node.RightChild);
            }
        }

        public Node<T> Search(T value, Node<T> node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value.CompareTo(value) == 0)
            {
                return node;
            }

            if (node.Value.CompareTo(value) > 0)
            {
                return Search(value, node.LeftChild);
            }
            else
            {
                return Search(value, node.RightChild);
            }
        }
    }
}
