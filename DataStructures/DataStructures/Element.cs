namespace DataStructures
{
    public class Element<TKey, TValue>
    {
        public Element()
        {
            Next = -1;
        }

        public Element(TKey key, TValue value)
        {
            Next = -1;
            this.Key = key;
            this.Value = value;
        }

        public int Next { get; set; }

        public TKey Key { get; set; }

        public TValue Value { get; set; }
    }
}
