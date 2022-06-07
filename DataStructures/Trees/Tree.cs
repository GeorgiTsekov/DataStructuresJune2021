using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class Tree<T>
    {
        public Node<T> Root { get; set; }

        public void DFS(Node<T> node, int level)
        {
            Console.Write(new string(' ', level));
            Console.WriteLine(node);
            Console.WriteLine();

            foreach (var child in node.Children)
            {
                DFS(child, level + 6);
            }
        } 

        public List<Node<T>> BFS(Node<T> root)
        {
            var list = new List<Node<T>>();
            var queue = new Queue<Node<T>>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node<T> node = queue.Dequeue();
                list.Add(node);
                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return list;
        }
    }
}
