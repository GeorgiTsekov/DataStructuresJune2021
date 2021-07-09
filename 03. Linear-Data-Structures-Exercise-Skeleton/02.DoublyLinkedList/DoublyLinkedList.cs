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
                this.head = this.tail = newNode;
                this.Count++;
                return;
            }

            this.head.Previous = newNode;
            this.head = this.head.Previous;
            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>(item, null, null);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
                this.Count++;
                return;
            }

            this.tail.Next = newNode;
            this.tail = this.tail.Next;
            this.Count++;
        }

        public T GetFirst()
        {
            ValidateCollection();

            var oldHead = this.head;
            return oldHead.Item;
        }

        public T GetLast()
        {
            ValidateCollection();

            var oldTail = this.tail;
            return oldTail.Item;
        }

        public T RemoveFirst()
        {
            ValidateCollection();

            var oldHead = this.head;
            this.head = this.head.Next;
            this.Count--;
            return oldHead.Item;
        }

        public T RemoveLast()
        {
            ValidateCollection();

            var oldTail = this.tail;
            this.tail = this.tail.Previous;
            this.Count--;
            return oldTail.Item;
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

        private void ValidateCollection()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}