using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityQueue
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private readonly List<T> heap;

        public PriorityQueue()
        {
            this.heap = new List<T>();
        }

        public int Size { get => this.heap.Count; }

        public T Peek()
        {
            return this.heap[0];
        }

        public T Dequeue()
        {
            T top = this.heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);

            return top;
        }

        private void HeapifyDown(int index)
        {
            int leftChildIndex = index * 2 + 1;
            int rightChildIndex = index * 2 + 2;
            int maxChildIndex = leftChildIndex;

            if (leftChildIndex >= heap.Count)
            {
                return;
            }

            if ((rightChildIndex < heap.Count) && heap[leftChildIndex].CompareTo(heap[rightChildIndex]) < 0)
            {
                maxChildIndex = rightChildIndex;
            }

            if (heap[index].CompareTo(heap[maxChildIndex]) < 0)
            {
                T temp = heap[index];
                heap[index] = heap[maxChildIndex];
                heap[maxChildIndex] = temp;
                HeapifyDown(maxChildIndex);
            }
        }

        public void Enqueue(T element)
        {
            this.heap.Add(element);
            Heapify(heap.Count - 1);
        }

        public string DFSInOrder(int index, int indent)
        {
            var result = new StringBuilder();
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;

            if (leftChild < heap.Count)
            {
                result
                    .Append(DFSInOrder(leftChild, indent + 3));
            }

            result
                .Append(new string(' ', indent))
                .Append(heap[index])
                .Append(Environment.NewLine);

            if (rightChild < heap.Count)
            {
                result
                    .Append(DFSInOrder(rightChild, indent + 3));
            }

            return result.ToString();
        }

        private void Heapify(int index)
        {
            if (index == 0)
            {
                return;
            }

            int parentIdnex = (index - 1) / 2;

            if (this.heap[index].CompareTo(heap[parentIdnex]) > 0)
            {
                T temp = heap[index];
                heap[index] = heap[parentIdnex];
                heap[parentIdnex] = temp;
                Heapify(parentIdnex);
            }
        }
    }
}
