using System;

namespace DataStructures
{
    public class IntArray
    {
        private int[] array;

        public IntArray()
        {
            this.array = new int[4];
            Count = 0;
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public void Add(int element)
        {
            EnsureCapactity();
            array[Count] = element;
            Count++;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
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

        public void Remove(int element)
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

        private void EnsureCapactity()
        {
            if (Count != array.Length)
            {
                return;
            }

            Array.Resize(ref array, array.Length * 2);
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
