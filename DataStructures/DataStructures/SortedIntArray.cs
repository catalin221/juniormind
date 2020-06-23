namespace DataStructures
{
    class SortedIntArray : IntArray
    {
        public SortedIntArray() : base()
        {
        }

        public override int this[int index]
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

        public override void Add(int element)
        {
            EnsureCapactity();

            if (Count == 0 || (Count > 0 && element > base[Count - 1]))
            {
                base.Add(element);
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    if (element < base[i])
                    {
                        base.Insert(i, element);
                        break;
                    }
                }
            }
        }

        public override void Insert(int index, int element)
        {
            if (!CheckNeighbours(index, element, index - 1, index))
            {
                return;
            }

            base.Insert(index, element);
        }

        public int ElementAt(int index, int value)
        {
            return index < Count ? base[index] : value;
        }

        private bool CheckNeighbours(int index, int element, int leftIndex, int rightIndex)
        {
            if (index == 0 && element > base[rightIndex])
            {
                return false;
            }
            else if (index == Count - 1 && (element < ElementAt(leftIndex, element) || element > ElementAt(rightIndex, element)))
            {
                return false;
            }
            else if (index != 0 && index != Count - 1 && (ElementAt(leftIndex, element) > element || ElementAt(rightIndex, element) < element))
            {
                return false;
            }

            return true;
        }
    }
}
