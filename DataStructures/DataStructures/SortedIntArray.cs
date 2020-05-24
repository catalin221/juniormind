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
                if (!CheckNeighbours(index, value))
                {
                    return;
                }

                array[index] = value;
            }
        }

        public override void Add(int element)
            {
            EnsureCapactity();
            if (Count == 0)
            {
                array[Count] = element;
            }
            else if (Count > 0 && element > array[Count - 1])
            {
                array[Count] = element;
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    if (element < array[i])
                    {
                        ShiftRight(i);
                        array[i] = element;
                        break;
                    }
                }
            }

            Count++;
        }

        public override void Insert(int index, int element)
        {
            if (!CheckNeighbours(index, element))
            {
                return;
            }

            base.Insert(index, element);
        }

        private bool CheckNeighbours(int index, int element)
        {
            if (index == 0 && element > array[0])
            {
                return false;
            }
            else if (index == Count - 1 && element < array[index - 1])
            {
                return false;
            }
            else if (index != 0 && (array[index - 1] > element || array[index + 1] < element))
            {
                return false;
            }

            return true;
        }
    }
}
