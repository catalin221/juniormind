using System.Collections.Generic;

namespace ExtensionMethods
{
    public class CompoundComparer<TSource> : IComparer<TSource>
    {
        private readonly IComparer<TSource> primaryComparer;
        private readonly IComparer<TSource> secondaryComparer;

        public CompoundComparer(IComparer<TSource> primary, IComparer<TSource> secondary)
        {
            primaryComparer = primary;
            secondaryComparer = secondary;
        }

        public int Compare(TSource x, TSource y)
        {
            return primaryComparer.Compare(x, y) != 0 ? primaryComparer.Compare(x, y) : secondaryComparer.Compare(x, y);
        }
    }
}
