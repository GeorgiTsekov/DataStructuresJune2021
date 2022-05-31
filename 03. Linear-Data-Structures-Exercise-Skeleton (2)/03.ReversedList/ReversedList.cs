namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.Validate(index);
                return this.items[this.Count - index - 1];
            }
            set
            {
                this.Validate(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.Count == this.items.Length)
            {
                this.items = DoubleArraySize(this.items);
            }

            this.items[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            foreach (var currentItem in this.items)
            {
                if (currentItem.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(items))
                {
                    return this.Count - i - 1;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            var isTrue = false;

            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (isTrue)
                {
                    break;
                }

                if (this.items[i].Equals(item))
                {
                    isTrue = RemoveElementByIndexAndUseNextElementInThisIndex(isTrue, i);
                }
            }

            return isTrue;
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Validate(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private T[] DoubleArraySize(T[] items)
        {
            var newItems = new T[items.Length * 2];

            Array.Copy(items, newItems, this.Count);

            return newItems;
        }

        private bool RemoveElementByIndexAndUseNextElementInThisIndex(bool isTrue, int i)
        {
            for (int j = this.Count - 1; j >= 0; j--)
            {
                if (j == 1)
                {
                    this.items[j] = this.items[0];
                }
                else
                {
                    Array.Resize(ref this.items, this.Count--);

                    isTrue = true;
                }
            }

            return isTrue;
        }
    }
}