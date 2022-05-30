using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementStack
{
    public class Stack<T>
    {
        public Node<T> Head { get; set; }

        public int Count { get; set; }

        public void Push(T element)
        {
            var newHead = new Node<T>(element);

            newHead.Next = this.Head;
            this.Head = newHead;
            this.Count++;
        }

        public T Pop()
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

        public T Peek()
        {
            if (this.Head == null)
            {
                throw new ArgumentNullException("No elements in the linkedList");
            }

            var oldHead = this.Head;

            return oldHead.Value;
        }
    }
}
