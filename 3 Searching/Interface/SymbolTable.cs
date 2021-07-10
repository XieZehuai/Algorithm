using System.Collections;
using System.Collections.Generic;

namespace _3_Searching
{
    public abstract class SymbolTable<TKey, TValue> : ISymbolTable<TKey, TValue>, IEnumerable<KeyValue<TKey, TValue>>
    {
        public abstract string Name { get; }

        public virtual bool IsEmpty => Size == 0;

        public abstract int Size { get; }

        public virtual IEnumerable<TKey> Keys { get; }

        public virtual IEnumerable<TValue> Values { get; }

        public abstract bool Contains(TKey key);

        public abstract void Delete(TKey key);

        public abstract TValue Get(TKey key);

        public abstract void Put(TKey key, TValue value);

        public abstract IEnumerator<KeyValue<TKey, TValue>> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
