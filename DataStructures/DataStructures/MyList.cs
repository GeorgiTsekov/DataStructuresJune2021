using System;

namespace ImplementList
{
    public class MyList<T>
    {
        private T[] array;
        private int index = 0;

        public MyList(int initialCapacity = 4)
        {
            array = new T[initialCapacity];
        }

        public int Count => this.index;

        public int InternalArrayCount => this.array.Length;

        public T this[int i]
        {
            get
            {
                this.ValidateIndex(i);
                return array[i];
            }
            set
            {
                this.ValidateIndex(i);
                array[i] = value;
            }
        }

        public void Add(T element)
        {
            if (index == array.Length)
            {
                this.array = DoubleArraySize(this.array);
            }
            array[this.index] = element;
            index++;
        }

        public bool Remove(T element)
        {
            var isTrue = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (isTrue)
                {
                    break;
                }

                if (this.array[i].Equals(element))
                {
                    isTrue = RemoveElementByIndexAndUseNextElementInThisIndex(isTrue, i);
                }
            }

            return isTrue;
        }

        public bool RemoveAt(int index)
        {
            this.ValidateIndex(index);

            var isTrue = false;

            for (int i = 0; i < this.array.Length; i++)
            {
                if (isTrue)
                {
                    break;
                }
                if (i == index)
                {
                    isTrue = RemoveElementByIndexAndUseNextElementInThisIndex(isTrue, i);
                }
            }

            return isTrue;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.array.Length; i++)
            {
                if (this.array[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        private bool RemoveElementByIndexAndUseNextElementInThisIndex(bool isTrue, int i)
        {
            for (int j = i; j < this.array.Length; j++)
            {
                if (j < this.array.Length - 1)
                {
                    this.array[j] = this.array[j + 1];
                }
                else
                {
                    Array.Resize(ref this.array, this.index--);

                    isTrue = true;
                }
            }

            return isTrue;
        }

        private T[] DoubleArraySize(T[] array)
        {
            var newArr = new T[this.array.Length * 2];
            for (int i = 0; i < array.Length; i++)
            {
                newArr[i] = array[i];
            }

            return newArr;
        }

        private void ValidateIndex(int index)
        {
            if (this.array.Length <= index && index < 0)
            {
                throw new ArgumentException("this index is out of range");
            }
        }
    }
}
