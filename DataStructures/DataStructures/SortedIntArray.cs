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
                int leftSide = ElementAt(index - 1, value);
                int rightSide = ElementAt(index + 1, value);

                if (leftSide > value || value > rightSide)
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
            int leftSide = ElementAt(index - 1, element);
            int rightSide = ElementAt(index, base[index]);

            if (leftSide > element || rightSide < element)
            {
                return;
            }

            base.Insert(index, element);
        }

        public int ElementAt(int index, int value)
        {
            return index < Count && index > -1 ? base[index] : value;
        }
    }
}
