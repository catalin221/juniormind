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
                if (!CheckNeighbours(index, value, index - 1, index + 1, "set"))
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
            if (!CheckNeighbours(index, element, index - 1, index, "insert"))
            {
                return;
            }

            base.Insert(index, element);
        }

        private bool CheckNeighbours(int index, int element, int leftIndex, int rightIndex, string setOrInsert)
        {
            if (index == 0 && element > base[rightIndex])
            {
                return false;
            }
            else if (setOrInsert == "insert" && index == Count - 1 && (element < base[leftIndex] || element > base[rightIndex]))
            {
                return false;
            }
            else if (setOrInsert == "set" && index == Count - 1 && (element < base[leftIndex]))
            {
                return false;
            }
            else if (index != 0 && index != Count - 1 && (base[leftIndex] > element || base[rightIndex] < element))
            {
                return false;
            }

            return true;
        }
    }
}
