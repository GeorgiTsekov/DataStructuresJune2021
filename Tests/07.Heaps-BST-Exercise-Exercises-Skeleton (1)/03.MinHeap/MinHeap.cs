namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> _elements;

        public MinHeap()
        {
            this._elements = new List<T>();
        }

        public int Size => this._elements.Count;

        public T Dequeue()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }

            var firstElement = this._elements[0];

            this.SwapElements(0, this.Size - 1);
            this._elements.RemoveAt(this.Size - 1);
            this.HeapifyDown(0);

            return firstElement;
        }

        private void HeapifyDown(int parentIndex)
        {
            int smallerChildIndex = this.FindSmallerChildIndex(parentIndex);
            while (smallerChildIndex != -1 && this._elements[smallerChildIndex].CompareTo(this._elements[parentIndex]) < 0)
            {
                SwapElements(smallerChildIndex, parentIndex);
                parentIndex = smallerChildIndex;
                smallerChildIndex = this.FindSmallerChildIndex(parentIndex);
            }
        }

        private int FindSmallerChildIndex(int parentIndex)
        {
            var leftChildIndex = parentIndex * 2 + 1;
            var rightChildIndex = parentIndex * 2 + 2;
            if (leftChildIndex >= this.Size)
            {
                return -1;
            }

            if (rightChildIndex >= this.Size)
            {
                return leftChildIndex;
            }

            var smallerChildIndex = this._elements[leftChildIndex].CompareTo(this._elements[rightChildIndex]) < 0 ? leftChildIndex : rightChildIndex;
            return smallerChildIndex;
        }

        public void Add(T element)
        {
            this._elements.Add(element);
            this.HeapifyUp(this.Size - 1);
        }

        private void HeapifyUp(int index)
        {
            var parentIndex = (index - 1) / 2;

            while (this._elements[index].CompareTo(this._elements[parentIndex]) < 0)
            {
                SwapElements(index, parentIndex);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private void SwapElements(int index, int parentIndex)
        {
            var smallerElement = this._elements[index];
            this._elements[index] = this._elements[parentIndex];
            this._elements[parentIndex] = smallerElement;
        }

        public T Peek()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }

            return this._elements[0];
        }
    }
}
