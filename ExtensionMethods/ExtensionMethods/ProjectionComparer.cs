using System;
using System.Collections.Generic;

namespace ExtensionMethods
{
    public class ProjectionComparer<TSource, TKey> : IComparer<TSource>
    {
        private readonly Func<TSource, TKey> keySelector;
        private readonly IComparer<TKey> comparer;

        public ProjectionComparer(Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            this.keySelector = keySelector;
            this.comparer = comparer ?? Comparer<TKey>.Default;
        }

        public int Compare(TSource x, TSource y)
        {
            return comparer.Compare(keySelector(x), keySelector(y));
        }
    }
}
