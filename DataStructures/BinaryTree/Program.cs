using System;

namespace BinaryTree
{
    class Program
    {
        static void Main()
        {
            var root = new Node<int>(1,
                new Node<int>(5,
                    new Node<int>(2),
                    new Node<int>(3)),
                new Node<int>(7,
                    new Node<int>(9),
                    new Node<int>(11))
                );

            var binaryTree = new BinaryTree<int>(root);
            Console.WriteLine(binaryTree.DFSInOrder(binaryTree.Root, 0));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(binaryTree.DFSPreOrder(binaryTree.Root, 0));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(binaryTree.DFSPostOrder(binaryTree.Root, 0));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(binaryTree.BFS(binaryTree.Root));
        }
    }
}
