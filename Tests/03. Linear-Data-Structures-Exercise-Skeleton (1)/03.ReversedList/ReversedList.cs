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
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

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
                this.items = this.Grow(this.items, this.Count);
            }

            this.items[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.items.Length; i++)
            {
                var currentItem = this.items[i];
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
                var currentItem = this.items[i];
                if (currentItem.Equals(item))
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
                this.items = this.Grow(this.items, this.Count);
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
            if (this.Contains(item))
            {
                this.RemoveAt(this.IndexOf(item));
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            this.Validate(index);

            for (int i = this.Count - index; i < this.Count; i++)
            {
                this.items[i - 1] = this.items[i];
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
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private T[] Grow(T[] currentItems, int itemCount)
        {
            var tempArray = new T[currentItems.Length * 2];

            Array.Copy(currentItems, tempArray, itemCount);

            return tempArray;
        }
    }
}