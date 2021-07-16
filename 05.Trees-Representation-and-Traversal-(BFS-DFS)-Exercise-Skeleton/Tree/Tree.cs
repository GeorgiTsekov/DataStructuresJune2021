namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] _children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in _children)
            {
                this.AddChild(child);
                child.AddParent(this);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            return GetAsString(0).TrimEnd();
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
            var result = new List<Tree<T>>();

            foreach (var leaf in leafNodes)
            {
                var node = leaf;
                var currentNodes = new List<Tree<T>>();

                while (node != null)
                {
                    currentNodes.Add(node);
                    node = node.Parent;
                }

                if (currentNodes.Count > result.Count)
                {
                    currentNodes.Reverse();
                    result = currentNodes;
                }
            }

            return result.LastOrDefault();
        }

        public List<T> GetLeafKeys()
        {
            var leafNodes = this.GetLeafNodes();

            return leafNodes.Select(x => x.Key).ToList();
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
            var leafNodes = this.GetMiddleNodes();

            return leafNodes.Select(x => x.Key).ToList();
        }

        private List<Tree<T>> GetMiddleNodes()
        {
            var midleNodes = new List<Tree<T>>();

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();

                if (node.Children.Count != 0 && node.Parent != null)
                {
                    midleNodes.Add(node);
                }

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return midleNodes;
        }

        public List<T> GetLongestPath()
        {
            var leafNodes = this.GetLeafNodes();
            var result = new List<T>();

            foreach (var leaf in leafNodes)
            {
                var node = leaf;
                var currentNodes = new List<T>();

                while (node != null)
                {
                    currentNodes.Add(node.Key);
                    node = node.Parent;
                }

                if (currentNodes.Count > result.Count)
                {
                    currentNodes.Reverse();
                    result = currentNodes;
                }
            }

            return result;
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var leafNodes = this.GetLeafNodes();
            var result = new List<List<T>>();

            foreach (var leaf in leafNodes)
            {
                var node = leaf;
                var currentSum = 0;
                var currentNodes = new List<T>();

                while (node != null)
                {
                    currentNodes.Add(node.Key);
                    currentSum += Convert.ToInt32(node.Key); //int.Parse(node.Key.ToString());
                    node = node.Parent;
                }

                if (currentSum == sum)
                {
                    currentNodes.Reverse();
                    result.Add(currentNodes);
                }
            }

            return result;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            var roots = new List<Tree<T>>();

            SubTreeDFS(this, sum, roots);

            return roots;
        }

        private int SubTreeDFS(Tree<T> node, int targetSum, List<Tree<T>> roots)
        {
            var currentSum = Convert.ToInt32(node.Key);

            foreach (var child in node.Children)
            {
                currentSum += SubTreeDFS(child, targetSum, roots);
            }

            if (currentSum == targetSum)
            {
                roots.Add(node);
            }

            return currentSum;
        }
    }
}
