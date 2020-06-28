using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class List<T> : IList<T>
    {
        private T[] listArray;

        public List()
        {
            this.listArray = new T[4];
        }

        public int Count { get; private set; }

        public bool IsReadOnly { get; }

        public virtual T this[int index]
        {
            get => listArray[index];
            set => listArray[index] = value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            listArray.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return listArray[i];
            }
        }

        public virtual void Add(T item)
        {
            EnsureCapactity();
            listArray[Count] = item;
            Count++;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (listArray[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, T item)
        {
            EnsureCapactity();
            ShiftRight(index);
            listArray[index] = item;
            Count++;
        }

        public void Clear()
        {
            this.Count = 0;
        }

        public bool Remove(T item)
        {
            if (!Contains(item))
            {
                return false;
            }

            int index = 0;
            for (int i = 0; i < Count; i++)
            {
                if (listArray[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }

            RemoveAt(index);

            return true;
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            Count--;
        }

        protected void EnsureCapactity()
        {
            if (Count != listArray.Length)
            {
                return;
            }

            Array.Resize<T>(ref listArray, listArray.Length * 2);
        }

        private void ShiftLeft(int index)
        {
            for (int i = Count - 1; i > index; i--)
            {
                listArray[i - 1] = listArray[i];
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                listArray[i] = listArray[i - 1];
            }
        }
    }
}
