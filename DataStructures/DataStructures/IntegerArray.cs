using System;

namespace DataStructures
{
    public class IntArray
    {
        private int[] array;
        private int count;

        public IntArray()
        {
            this.array = new int[4];
            this.count = 0;
        }

        public void Add(int element)
        {
            if (count == array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }

            array[count] = element;
            count++;
        }

        public int Count()
        {
            return this.count;
        }

        public int Element(int index)
        {
            return this.array[index];
        }

        public void SetElement(int index, int element)
        {
            this.array[index] = element;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < count; i++)
            {
                if (array[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < count; i++)
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
            if (count == array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }

            for (int i = count; i > index; i--)
            {
                array[i] = array[i - 1];
            }

            array[index] = element;
            count++;
        }

        public void Clear()
        {
            this.count = 0;
        }

        public void Remove(int element)
        {
            int index = 0;
            for (int i = 0; i < count; i++)
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
            for (int i = count - 1; i > index; i--)
            {
                array[i - 1] = array[i];
            }

            count--;
        }
    }
}
