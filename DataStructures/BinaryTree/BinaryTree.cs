using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTree<T>
    {
        public BinaryTree(Node<T> root)
        {
            this.Root = root;
        }

        public Node<T> Root { get; set; }

        public string DFSInOrder(Node<T> node, int indent)
        {
            string result = $"{new string(' ', indent) }{node.Value}\n";

            if (node.LeftChild != null)
            {
                result += DFSInOrder(node.LeftChild, indent + 3);
            }

            if (node.RightChild != null)
            {
                result += DFSInOrder(node.RightChild, indent + 3);
            }

            return result;
        }

        public string DFSPreOrder(Node<T> node, int indent)
        {
            string result = "";

            if (node.LeftChild != null)
            {
                result += DFSPreOrder(node.LeftChild, indent + 3);
            }

            result += $"{new string(' ', indent) }{node.Value}\n";

            if (node.RightChild != null)
            {
                result += DFSPreOrder(node.RightChild, indent + 3);
            }

            return result;
        }

        public string DFSPostOrder(Node<T> node, int indent)
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

        public string BFS(Node<T> node)
        {
           var sb = new StringBuilder();
           var queue = new Queue<Node<T>>();

            queue.Enqueue(node);
            int indent = 0;
            while (queue.Count > 0)
            {
                Node<T> currentNode = queue.Dequeue();

                if (currentNode.LeftChild != null)
                {
                    queue.Enqueue(currentNode.LeftChild);
                    sb
                        .Append(new string(' ', indent + 3))
                        .Append(currentNode.LeftChild.Value)
                        .Append(Environment.NewLine);
                }

                if (currentNode.RightChild != null)
                {
                    queue.Enqueue(currentNode.RightChild);
                    sb
                        .Append(new string(' ', indent + 3))
                        .Append(currentNode.RightChild.Value)
                        .Append(Environment.NewLine);
                }
                sb
                    .Append(new string(' ', indent))
                    .Append(currentNode.Value)
                    .Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
