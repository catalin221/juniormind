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
                T leftSide = ElementAt(index - 1, value);
                T rightSide = ElementAt(index + 1, value);

                if (value.CompareTo(leftSide) == -1 || value.CompareTo(rightSide) == 1)
                {
                    return;
                }

                base[index] = value;
            }
        }

        public override void Insert(int index, T element)
        {
            T leftSide = ElementAt(index - 1, element);
            T rightSide = ElementAt(index, base[index]);

            if (leftSide.CompareTo(element) == 1 || rightSide.CompareTo(element) == -1)
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
            return index < Count && index > -1 ? base[index] : value;
        }
    }
}
