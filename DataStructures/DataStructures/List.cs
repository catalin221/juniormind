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
            get
            {
                OutOfBoundsException(index);
                return listArray[index];
            }

            set
            {
                IsReadonlyException();
                OutOfBoundsException(index);
                listArray[index] = value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ArgumentNullException(array);
            NegativeIndexException(arrayIndex);
            ArgumentException(array, arrayIndex);
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
            IsReadonlyException();
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
            IsReadonlyException();
            OutOfBoundsException(index);
            EnsureCapactity();
            ShiftRight(index);
            listArray[index] = item;
            Count++;
        }

        public void Clear()
        {
            IsReadonlyException();
            this.Count = 0;
        }

        public bool Remove(T item)
        {
            IsReadonlyException();
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
            IsReadonlyException();
            OutOfBoundsException(index);
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

        private void OutOfBoundsException(int index)
        {
            if (index >= 0 && index <= Count - 1)
            {
                return;
            }

            throw new ArgumentOutOfRangeException("index");
        }

        private void ArgumentException(T[] array, int index)
        {
            if (array.Length - index >= Count)
            {
                return;
            }

            throw new ArgumentException("Destination array doesn't have enough space for the operation");
        }

        private void NegativeIndexException(int index)
        {
            if (index >= 0)
            {
                return;
            }

            throw new ArgumentOutOfRangeException("index");
        }

        private void ArgumentNullException(T[] array)
        {
            if (array != null)
            {
                return;
            }

            throw new ArgumentNullException("array");
        }

        private void IsReadonlyException()
            {
            if (!listArray.IsReadOnly)
            {
                return;
            }

            throw new NotSupportedException();
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
