using System;
using System.Collections.Generic;
using System.Text;

namespace Heap
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> heap;

        public PriorityQueue()
        {
            this.heap = new List<T>();
        }

        public int Size => this.heap.Count;

        public T Peek()
        {
            return heap[0];
        }

        public T Dequeue()
        {
            var top = heap[0];
            heap[0] = heap[this.heap.Count - 1];
            heap.RemoveAt(this.heap.Count - 1);

            this.HeapifyDown(0);

            return top;
        }

        private void HeapifyDown(int index)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int maxChildIndex = leftChildIndex;

            if (leftChildIndex >= this.heap.Count)
            {
                return;
            }

            if ((rightChildIndex < this.heap.Count) && this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
            {
                maxChildIndex = rightChildIndex;
            }

            if (this.heap[index].CompareTo(this.heap[maxChildIndex]) < 0)
            {
                var oldChild = this.heap[maxChildIndex];
                this.heap[maxChildIndex] = this.heap[index];
                this.heap[index] = oldChild;
                this.HeapifyDown(maxChildIndex);
            }
        }

        public void Add(T element)
        {
            this.heap.Add(element);
            this.Heapify(this.heap.Count - 1);
        }

        private void Heapify(int index)
        {
            if (index == 0)
            {
                return;
            }
            int parentIndex = (index - 1) / 2;

            if (this.heap[index].CompareTo(this.heap[parentIndex]) > 0)
            {
                var oldParent = this.heap[parentIndex];

                this.heap[parentIndex] = this.heap[index];
                this.heap[index] = oldParent;
                this.Heapify(parentIndex);
            }
        }
    }
}
