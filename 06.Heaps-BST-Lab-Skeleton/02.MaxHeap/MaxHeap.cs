namespace _02.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> heap;

        public MaxHeap()
        {
            this.heap = new List<T>();
        }
        public int Size => this.heap.Count;

        public void Add(T element)
        {
            this.heap.Add(element);
            this.Heapify(heap.Count - 1);
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

        public T Peek()
        {
            return heap[0];
        }
    }
}
