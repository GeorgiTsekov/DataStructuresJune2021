using System;

namespace ImplementQueue
{
    public class Queue<T>
    {
        public Node<T> Head { get; set; }

        public int Count { get; set; }

        public void Enqueue(T element)
        {
            var newHead = new Node<T>(element);

            if (this.Head is null)
            {
                this.Head = newHead;
            }
            else
            {
                var current = this.Head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newHead;
            }

            this.Count++;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new ArgumentNullException("bla bla bal");
            }
            var firstNode = this.Head;

            return firstNode.Value;
        }

        public T Dequeue()
        {
            if (this.Head == null)
            {
                throw new ArgumentNullException("No elements in the linkedList");
            }

            var oldHead = this.Head;

            this.Head = this.Head.Next;
            this.Count--;

            return oldHead.Value;
        }
    }
}
