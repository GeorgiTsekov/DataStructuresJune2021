namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
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
            return this.GetAsString(0).TrimEnd();
        }

        private string GetAsString(int indentation = 0)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(new string(' ', indentation) + this.Key + Environment.NewLine);

            foreach (var child in this.Children)
            {
                sb.Append(child.GetAsString(indentation + 2));
            }

            return sb.ToString();
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            return this.GetLeftNode();
        }

        private Tree<T> GetLeftNode()
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node.Children.Count == 0)
                {
                    return node;
                }

                queue.Enqueue(node.Children.FirstOrDefault());
            }

            return null;
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

            while (queue.Count > 0)
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
            var middleNodes = this.GetMiddleNodes();

            return middleNodes.Select(x => x.Key).ToList();
        }

        private List<Tree<T>> GetMiddleNodes()
        {
            var middleNodes = new List<Tree<T>>();

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node.Children.Count > 0 && node.Parent != null)
                {
                    middleNodes.Add(node);
                }

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return middleNodes;
        }

        public List<T> GetLongestPath()
        {
            var leafNodes = this.GetLeafNodes();
            var result = new List<T>();

            foreach (var leaf in leafNodes)
            {
                var node = leaf;
                var currentPath = new List<T>();

                while (node != null)
                {
                    currentPath.Add(node.Key);
                    node = node.Parent;
                }

                if (currentPath.Count > result.Count)
                {
                    currentPath.Reverse();
                    result = currentPath;
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
                    currentSum += Convert.ToInt32(node.Key);
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

            this.SubTreeSumDFS(this, sum, roots);

            return roots;
        }

        private int SubTreeSumDFS(Tree<T> node, int targetSum, List<Tree<T>> roots)
        {
            var sum = Convert.ToInt32(node.Key);

            foreach (var currentNode in node.Children)
            {
                sum += this.SubTreeSumDFS(currentNode, targetSum, roots);
            }

            if (targetSum == sum)
            {
                roots.Add(node);
            }

            return sum;
        }
    }
}
