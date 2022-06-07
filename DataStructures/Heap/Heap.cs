using System;
using System.Collections.Generic;
using System.Text;

namespace Heap
{
    public class Heap<T> where T : IComparable<T>
    {
        private readonly List<T> heap;

        public Heap()
        {
            this.heap = new List<T>();
        }

        public int Size { get => this.heap.Count; }

        public T GetMax()
        {
            return this.heap[0];
        }

        public void Add(T element)
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
