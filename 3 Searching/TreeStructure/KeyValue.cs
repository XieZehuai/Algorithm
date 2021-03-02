using System;
using System.Collections.Generic;

namespace _3_Searching
{
    public class KeyValue<TKey, TValue>
    {
        protected readonly TKey key;
        protected TValue value;

        public KeyValue()
        {
            key = default;
            value = default;
        }

        public KeyValue(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
        }

        public virtual TKey Key => key;

        public virtual TValue Value
        {
            get => value;
            set => this.value = value;
        }

        public override string ToString()
        {
            return "[" + key + ": " + value + "]";
        }
    }
}
