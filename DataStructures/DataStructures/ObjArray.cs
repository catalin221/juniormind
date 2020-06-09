using System;
using System.Collections;

namespace DataStructures
{
    public class ObjArrayCollection : IEnumerable
    {
        private object[] array;

        public ObjArrayCollection()
        {
            this.array = new object[4];
        }

        public int Count { get; private set; }

        public virtual object this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public ObjectEnumerator GetEnumerator()
        {
            return new ObjectEnumerator(this);
        }

        public virtual void Add(object element)
        {
            EnsureCapactity();
            array[Count] = element;
            Count++;
        }

        public bool Contains(object element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(object element)
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

        public virtual void Insert(int index, object element)
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
