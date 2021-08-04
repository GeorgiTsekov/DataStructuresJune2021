namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T value)
        {
            this.Value = value;
            this.Parent = null;
            this._children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this._children.Add(child);
            }
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            throw new NotImplementedException();
        }

        public ICollection<T> OrderDfs()
        {
            throw new NotImplementedException();
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var node = FindNode(this, parentKey);
            if (node == null)
            {
                node._children.Add(child);
            }
        }

        private Tree<T> FindNode(Tree<T> root, T searchedValue)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node.Value.Equals(searchedValue))
                {
                    return node;
                }

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public void RemoveNode(T nodeKey)
        {
            throw new NotImplementedException();
        }

        public void Swap(T firstKey, T secondKey)
        {
            throw new NotImplementedException();
        }
    }
}
