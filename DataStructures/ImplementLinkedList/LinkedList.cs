using System;

namespace ImplementLinkedList
{
    public class LinkedList<T>
    {
        public Node<T> Head { get; set; }

        public Node<T> Tail { get; set; }

        public int Count { get; set; }

        public void AddHead(T element)
        {
            var newHead = new Node<T>(element);
            newHead.Next = this.Head;

            if (this.Head == null)
            {
                this.Tail = newHead;
            }
            this.Head = newHead;
            this.Count++;
        }

        public void AddTail(T element)
        {
            var newTail = new Node<T>(element);
            if (this.Tail == null)
            {
                this.Head = newTail;
                this.Tail = newTail;
            }
            else
            {
                this.Tail.Next = newTail;
                this.Tail = newTail;
            }
            this.Count++;
        }

        public Node<T> RemoveFirst()
        {
            if (this.Head == null)
            {
                throw new ArgumentNullException("No elements in the linkedList");
            }
            var oldHead = this.Head;
            this.Head = this.Head.Next;
            if (this.Head == null)
            {
                this.Tail = null;
            }
            this.Count--;
            return oldHead;
        }

        public Node<T> RemoveLast()
        {
            if (this.Tail == null)
            {
                throw new ArgumentNullException("No elements in the linkedList");
            }
            var oldTail = this.Tail;
            var previousTail = this.Head;
            while (previousTail.Next != this.Tail)
            {
                previousTail = previousTail.Next;
            }

            previousTail.Next = null;
            this.Tail = previousTail;
            if (this.Tail == null)
            {
                this.Head = null;
            }
            this.Count--;
            return oldTail;
        }
    }
}
