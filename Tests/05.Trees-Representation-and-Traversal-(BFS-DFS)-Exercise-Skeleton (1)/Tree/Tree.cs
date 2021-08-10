namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this._children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.AddChild(child);
                child.AddParent(this);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this._children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            return this.GetAsString(0).Trim();
        }

        private string GetAsString(int indentation = 0)
        {
            var result = new string(' ', indentation) + this.Key + "\r\n";

            foreach (var child in this.Children)
            {
                result += child.GetAsString(indentation + 2);
            }

            return result;
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            var leafNodes = this.GetLeafNodes();
            var list = new List<T>();
            Tree<T> tree = leafNodes.FirstOrDefault();

            foreach (var leaf in leafNodes)
            {
                var currentNode = new List<T>();
                var node = leaf;

                while (node != null)
                {
                    currentNode.Add(node.Key);
                    node = node.Parent;
                }

                if (currentNode.Count > list.Count)
                {
                    currentNode.Reverse();
                    list = currentNode;
                    tree = leaf;
                }
            }

            return tree;

            //var queue = new Queue<Tree<T>>();

            //queue.Enqueue(this);

            //while (queue.Count != 0)
            //{
            //    var node = queue.Dequeue();

            //    foreach (var child in node.Children)
            //    {
            //        queue.Enqueue(child);
            //        if (child.Children.Count == 0)
            //        {
            //            return child;
            //        }
            //        break;
            //    }
            //}

            //return null;
        }

        public List<T> GetLeafKeys()
        {
            var leafNodes = this.GetLeafNodes();

            return leafNodes.Select(x => x.Key).ToList();

            //var result = new List<T>();
            //var queue = new Queue<Tree<T>>();
            //queue.Enqueue(this);

            //while (queue.Count != 0)
            //{
            //    var node = queue.Dequeue();

            //    foreach (var child in node.Children)
            //    {
            //        if (child.Children.Count == 0)
            //        {
            //            result.Add(child.Key);
            //        }

            //        queue.Enqueue(child);
            //    }
            //}

            //return result;
        }

        private List<Tree<T>> GetLeafNodes()
        {
            var leafNodes = new List<Tree<T>>();

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();

                if (node.Children.Count == 0)
                {
                    leafNodes.Add(node);
                }

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return leafNodes;
        }

        public List<T> GetMiddleKeys()
        {
            var result = new List<T>();
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();

                foreach (var child in node.Children)
                {
                    if (child.Children.Count > 0 && child.Parent != null)
                    {
                        result.Add(child.Key);
                    }

                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public List<T> GetLongestPath()
        {
            var leafNodes = this.GetLeafNodes();
            var result = new List<T>();

            foreach (var leaf in leafNodes)
            {
                var currentNode = new List<T>();
                var node = leaf;

                while (node != null)
                {
                    currentNode.Add(node.Key);
                    node = node.Parent;
                }

                if (currentNode.Count > result.Count)
                {
                    currentNode.Reverse();
                    result = currentNode;
                }
            }

            return result;


            //var result = new List<T>();
            //var queue = new Queue<Tree<T>>();
            //queue.Enqueue(this);
            //result.Add(this.Key);

            //while (queue.Count != 0)
            //{
            //    var node = queue.Dequeue();
            //    foreach (var child in node.Children)
            //    {
            //        queue.Enqueue(child);
            //        result.Add(child.Key);
            //        break;
            //    }
            //}
            //return result;
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var result = new List<List<T>>();
            var currentSum = 0;

            this.PathsWithSumDFS(this, ref currentSum, sum, result, new List<T>());

            return result;

            //var leafNodes = this.GetLeafNodes();

            //var result = new List<List<T>>();

            //foreach (var leaf in leafNodes)
            //{
            //    var node = leaf;
            //    var currentSum = 0;
            //    var currentNode = new List<T>();

            //    while (node != null)
            //    {
            //        currentNode.Add(node.Key);
            //        currentSum += Convert.ToInt32(node.Key);
            //        node = node.Parent;
            //    }

            //    if (currentSum == sum)
            //    {
            //        currentNode.Reverse();
            //        result.Add(currentNode);
            //    }
            //}

            //return result;

            //var result = new List<List<T>>();

            //var queue = new Queue<Tree<T>>();
            //queue.Enqueue(this);

            //while (queue.Count != 0)
            //{
            //    var currentSum = 0;
            //    var node = queue.Dequeue();
            //    var list = new List<T>();

            //    foreach (var child in node.Children)
            //    {
            //        if (child.Children.Count == 0)
            //        {
            //            var childNode = child;

            //            while (childNode.Parent != null)
            //            {
            //                list.Add(childNode.Key);
            //                currentSum += Convert.ToInt32(childNode.Key);
            //                childNode = childNode.Parent;
            //            }

            //            list.Add(childNode.Key);
            //            currentSum += Convert.ToInt32(childNode.Key);

            //            if (currentSum == sum)
            //            {
            //                list.Reverse();
            //                result.Add(list);
            //            }

            //            currentSum = 0;
            //            list = new List<T>();
            //        }

            //        queue.Enqueue(child);
            //    }
            //}

            //return result;
        }

        private void PathsWithSumDFS(
            Tree<T> node,
            ref int currentSum,
            int targetSum,
            List<List<T>> allPaths,
            List<T> currentPathValues)
        {
            currentPathValues.Add(node.Key);
            currentSum += Convert.ToInt32(node.Key);

            foreach (var child in node.Children)
            {
                this.PathsWithSumDFS(child, ref currentSum, targetSum, allPaths, currentPathValues);
            }

            if (currentSum == targetSum)
            {
                allPaths.Add(new List<T>(currentPathValues));
            }

            currentSum -= Convert.ToInt32(node.Key);
            currentPathValues.RemoveAt(currentPathValues.Count - 1);
        }

        private int SubTreesWithGivenSumDFS(
            Tree<T> node,
            int targetSum,
            List<Tree<T>> allTrees)
        {
            var currentSum = Convert.ToInt32(node.Key);
            foreach (var child in node.Children)
            {
                currentSum += this.SubTreesWithGivenSumDFS(child, targetSum, allTrees);
            }

            if (currentSum == targetSum)
            {
                allTrees.Add(node);
            }

            return currentSum;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            var result = new List<Tree<T>>();

            this.SubTreesWithGivenSumDFS(this, sum, result);

            return result;

            //var leafNodes = this.GetLeafNodes();
            //var result = new List<Tree<T>>();

            //foreach (var leaf in leafNodes)
            //{
            //    if (leaf.Children.Count == 0)
            //    {
            //        var leafNode = leaf;
            //        var currentSum = 0;

            //        if (Convert.ToInt32(leafNode.Key) == sum)
            //        {
            //            result.Add(leafNode);
            //            continue;
            //        }

            //        while (leafNode.Parent != null)
            //        {
            //            leafNode = leafNode.Parent;
            //            currentSum += Convert.ToInt32(leafNode.Key);
            //            foreach (var childTree in leafNode.Children)
            //            {
            //                currentSum += Convert.ToInt32(childTree.Key);
            //            }

            //            if (currentSum == sum)
            //            {
            //                if (!result.Contains(leafNode))
            //                {
            //                    result.Add(leafNode);
            //                }
            //            }
            //        }
            //    }
            //}

            //return result;

            //var result = new List<Tree<T>>();

            //var queue = new Queue<Tree<T>>();
            //queue.Enqueue(this);

            //while (queue.Count != 0)
            //{
            //    var currentSum = 0;
            //    var node = queue.Dequeue();

            //    foreach (var child in node.Children)
            //    {
            //        if (child.Children.Count == 0)
            //        {
            //            var childNode = child;

            //            if (Convert.ToInt32(childNode.Key) == sum)
            //            {
            //                result.Add(childNode);
            //                continue;
            //            }

            //            while (childNode.Parent != null)
            //            {
            //                childNode = childNode.Parent;
            //                currentSum += Convert.ToInt32(childNode.Key);
            //                foreach (var childTree in childNode.Children)
            //                {
            //                    currentSum += Convert.ToInt32(childTree.Key);
            //                }

            //                if (currentSum == sum)
            //                {
            //                    if (!result.Contains(childNode))
            //                    {
            //                        result.Add(childNode);
            //                    }
            //                }

            //                currentSum = 0;
            //            }
            //        }

            //        queue.Enqueue(child);
            //    }
            //}

            //return result;
        }
    }
}
