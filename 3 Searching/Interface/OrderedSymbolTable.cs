using System;
using System.Collections.Generic;

namespace _3_Searching
{
    public abstract class OrderedSymbolTable<TKey, TValue> : SymbolTable<TKey, TValue>, IOrderedSymbolTable<TKey, TValue> where TKey : IComparable<TKey>
    {
        public override IEnumerable<TKey> Keys => KeysBetween(Min, Max);

        public abstract TKey Min { get; }

        public abstract TKey Max { get; }

        public virtual void DeleteMin()
        {
            Delete(Min);
        }

        public virtual void DeleteMax()
        {
            Delete(Max);
        }

        public abstract TKey Ceiling(TKey key);

        public abstract TKey Floor(TKey key);

        public abstract int Rank(TKey key);

        public abstract TKey Select(int rank);

        public virtual int SizeBetween(TKey low, TKey high)
        {
            if (low.CompareTo(high) > 0) return 0;
            if (Contains(high)) return Rank(high) - Rank(low) + 1;
            return Rank(high) - Rank(low);
        }

        public abstract IEnumerable<TKey> KeysBetween(TKey low, TKey high);
    }
}
