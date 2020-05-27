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
                if (!CheckNeighboursSet(index, value))
                {
                    return;
                }

                base[index] = value;
            }
        }

        public override void Add(int element)
            {
            EnsureCapactity();
            if (Count == 0)
            {
                base.Add(element);
            }
            else if (Count > 0 && element > base[Count - 1])
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
            if (!CheckNeighboursInsert(index, element))
            {
                return;
            }

            base.Insert(index, element);
        }

        private bool CheckNeighboursSet(int index, int value)
        {
            if (index == 0 && value > base[1])
            {
                return false;
            }
            else if (index == Count - 1 && value < base[index - 1])
            {
                return false;
            }
            else if (index != 0 && index != Count - 1 && (base[index - 1] > value || base[index + 1] < value))
            {
                return false;
            }

            return true;
        }

        private bool CheckNeighboursInsert(int index, int element)
        {
            if (index == 0 && element > base[0])
            {
                return false;
            }
            else if (index == Count - 1 && (element < base[index - 1] || element > base[index]))
            {
                return false;
            }
            else if (index != 0 && index != Count - 1 && (base[index - 1] > element || base[index] < element))
            {
                return false;
            }

            return true;
        }
    }
}
