using System;

namespace DataStructures
{
    class SortedList<T> : List<T>
        where T : IComparable<T>
    {
        public SortedList() : base()
        {
        }

        public override T this[int index]
        {
            set
            {
                if (!CheckNeighbours(index, value, index - 1, index + 1))
                {
                    return;
                }

                base[index] = value;
            }
        }

        public override void Insert(int index, T element)
        {
            if (!CheckNeighbours(index, element, index - 1, index))
            {
                return;
            }

            base.Insert(index, element);
        }

        public override void Add(T element)
        {
            EnsureCapactity();

            if (Count == 0 || (Count > 0 && element.CompareTo(base[Count - 1]) == 1))
            {
                base.Add(element);
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    if (element.CompareTo(base[i]) == -1)
                    {
                        base.Insert(i, element);
                        break;
                    }
                }
            }
        }

        public T ElementAt(int index, T value)
        {
            return index < Count ? base[index] : value;
        }

        private bool CheckNeighbours(int index, T element, int leftIndex, int rightIndex)
        {
            if (index == 0 && element.CompareTo(base[rightIndex]) == 1)
            {
                return false;
            }
            else if (index == Count - 1 && (element.CompareTo(ElementAt(leftIndex, element)) == -1 || element.CompareTo(ElementAt(rightIndex, element)) == 1))
            {
                return false;
            }
            else if (index != 0 && index != Count - 1 && (ElementAt(leftIndex, element).CompareTo(element) == 1 || ElementAt(rightIndex, element).CompareTo(element) == -1))
            {
                return false;
            }

            return true;
        }
    }
}
