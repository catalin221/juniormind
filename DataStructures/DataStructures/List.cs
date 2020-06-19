using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class List<T> : IEnumerable<T>
    {
        private T[] array;

        public List()
        {
            this.array = new T[4];
        }

        public int Count { get; private set; }

        public virtual T this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }

        public virtual void Add(T element)
        {
            EnsureCapactity();
            array[Count] = element;
            Count++;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, T element)
        {
            EnsureCapactity();
            ShiftRight(index);
            array[index] = element;
            Count++;
        }

        public void Clear()
        {
            this.Count = 0;
        }

        public void Remove(object element)
        {
            int index = 0;
            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(element))
                {
                    index = i;
                }
            }

            RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            Count--;
        }

        protected void EnsureCapactity()
        {
            if (Count != array.Length)
            {
                return;
            }

            Array.Resize<T>(ref array, array.Length * 2);
        }

        private void ShiftLeft(int index)
        {
            for (int i = Count - 1; i > index; i--)
            {
                array[i - 1] = array[i];
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                array[i] = array[i - 1];
            }
        }
    }
}
