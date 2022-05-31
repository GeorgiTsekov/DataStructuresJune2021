namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item, null, null);
            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = newNode;
                this.Count++;
                return;
            }
            //var oldHead = this.head;
            //oldHead.Previous = newNode;
            //this.head = newNode;
            //this.head.Next = oldHead;

            this.head.Previous = newNode;
            this.head = this.head.Previous;
            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>(item, null, null);
            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = newNode;
                this.Count++;
                return;
            }

            this.tail.Next = newNode;
            this.tail = this.tail.Next;
            this.Count++;
        }

        public T GetFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.head.Item;
        }

        public T GetLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.tail.Item;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var oldNode = this.head;
            this.head = this.head.Next;

            this.Count--;
            return oldNode.Item;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var oldNode = this.tail;
            this.tail = this.tail.Previous;

            this.Count--;
            return oldNode.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;

            while (node != null)
            {
                yield return node.Item;

                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}