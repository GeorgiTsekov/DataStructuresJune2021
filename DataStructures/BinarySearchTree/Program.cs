using CommonDataStructurse;
using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    class Program
    {
        static void Main()
        {
            var list = new List<int>();
            for (int i = 0; i < 1000000; i+=2)
            {
                list.Add(i);
            }

            var tree = new BinarySearchTree<int>();

            Insert(tree, 0, list.Count, list);

            Console.WriteLine($"FInd: {22222223}-> {tree.Contains(23, tree.Root)}");
            Console.WriteLine($"FInd: {22222224}-> {tree.Contains(24, tree.Root)}");
            Console.WriteLine();
            //Console.WriteLine(DFS.DFSInOrder(tree.Root, 0));
        }

        private static void Insert(BinarySearchTree<int> tree, int start, int end, List<int> list)
        {
            if (start >= end)
            {
                return;
            }

            var middle = (start + end) / 2;
            tree.Insert(list[middle], tree.Root);
            Insert(tree, start, middle - 1, list);
            Insert(tree, middle + 1, end, list);
        }
    }
}
