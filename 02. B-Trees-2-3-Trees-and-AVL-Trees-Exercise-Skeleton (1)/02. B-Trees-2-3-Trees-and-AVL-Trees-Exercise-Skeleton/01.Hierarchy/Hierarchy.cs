namespace _01.Hierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;

    public class Hierarchy<T> : IHierarchy<T>
    {
        private class Node
        {
            public T Value { get; set; }

            public Node Parent;

            public List<Node> Children { get; set; }

            public Node(T value)
            {
                this.Value = value;
                this.Children = new List<Node>();
            }
        }

        private readonly Node root;

        private readonly Dictionary<T, Node> nodesByValue;

        public Hierarchy(T value)
        {
            this.nodesByValue = new Dictionary<T, Node>();
            this.root = new Node(value);
            this.nodesByValue.Add(value, this.root);

        }

        public int Count => nodesByValue.Count;

        public void Add(T parentValue, T childValue)
        {
            if (!nodesByValue.ContainsKey(parentValue) || nodesByValue.ContainsKey(childValue))
            {
                throw new ArgumentException();
            }

            var childNode = new Node(childValue);
            this.nodesByValue.Add(childValue, childNode);
            childNode.Parent = this.nodesByValue[parentValue];
            this.nodesByValue[parentValue].Children.Add(childNode);
        }

        public void Remove(T element)
        {
            if (element.Equals(this.root.Value))
            {
                throw new InvalidOperationException();
            }

            if (!this.nodesByValue.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            var node = this.nodesByValue[element];
            var parentNode = node.Parent;

            parentNode.Children.Remove(node);
            parentNode.Children.AddRange(node.Children);
            foreach (var child in node.Children)
            {
                this.nodesByValue[child.Value].Parent = parentNode;
            }

            this.nodesByValue.Remove(element);
        }

        public IEnumerable<T> GetChildren(T element)
        {
            if (!this.Contains(element))
            {
                throw new ArgumentException();
            }

            var children = this.nodesByValue[element].Children.Select(x => x.Value);

            return children;
        }

        public T GetParent(T element)
        {
            if (!this.Contains(element))
            {
                throw new ArgumentException();
            }

            var parentNode = this.nodesByValue[element].Parent;
            return parentNode != null ? parentNode.Value : default;
        }

        public bool Contains(T element)
        {
            return this.nodesByValue.ContainsKey(element);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            //return this.nodesByValue.Keys.Intersect(other);
            var list = new List<T>();
            foreach (var item in this.nodesByValue.Keys)
            {
                if (other.nodesByValue.ContainsKey(item))
                {
                    list.Add(item);
                }
            }

            return list;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var queue = new Queue<Node>();
            queue.Enqueue(this.root);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();

                yield return node.Value;

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}