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
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this.items[i].Equals(item))
                {
                    return this.Count - i - 1;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.Validate(index);

            if (this.Count == this.items.Length)
            {
                this.items = DoubleArraySize(this.items);
            }

            for (int i = this.Count; i >= this.Count - index; i--)
            {
                this.items[i] = this.items[i - 1];

            }

            this.items[this.Count - index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            int index = -1;
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this.items[i].Equals(item))
                {
                    index = this.Count - 1 - i;
                    break;
                }
            }

            if (index >= 0)
            {
                for (int i = this.Count - index; i < this.Count; i++)
                {
                    this.items[i] = this.items[i + 1];
                }
                this.Count--;
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            this.Validate(index);

            for (int i = this.Count - index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.Count--;
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
    }
}