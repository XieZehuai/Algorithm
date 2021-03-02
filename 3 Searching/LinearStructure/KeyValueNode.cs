using System;
using System.Collections;
using System.Collections.Generic;

namespace _3_Searching
{
    public partial class KeyValueNode<TKey, TValue> : KeyValue<TKey, TValue>, IEnumerable<KeyValueNode<TKey, TValue>>
    {
        public KeyValueNode<TKey, TValue> next;

        public KeyValueNode(TKey key, TValue value, KeyValueNode<TKey, TValue> next) : base(key, value)
        {
            this.next = next;
        }

        public IEnumerable<TKey> Keys => new KeyEnumerator(this);
        
        public IEnumerable<TValue> Values => new ValueEnumerator(this);

        public IEnumerator<KeyValueNode<TKey, TValue>> GetEnumerator()
        {
            return new KeyValueEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    public partial class KeyValueNode<TKey, TValue>
    {
        protected abstract class Enumerator<T> : IEnumerator<T>
        {
            protected KeyValueNode<TKey, TValue> first;
            protected KeyValueNode<TKey, TValue> current;

            public Enumerator(KeyValueNode<TKey, TValue> first)
            {
                this.first = first ?? throw new ArgumentNullException();
                current = null;
            }

            public abstract T Current { get; }

            object IEnumerator.Current => Current;

            public virtual bool MoveNext()
            {
                current = current == null ? first : current.next;
                return current != null;
            }

            public virtual void Reset()
            {
                current = null;
            }

            public virtual void Dispose()
            {
                first = null;
                current = null;
            }
        }


        protected class KeyEnumerator : Enumerator<TKey>, IEnumerable<TKey>
        {
            public KeyEnumerator(KeyValueNode<TKey, TValue> first) : base(first)
            {
            }

            public override TKey Current => current.Key;

            public IEnumerator<TKey> GetEnumerator()
            {
                return this;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }


        protected class ValueEnumerator : Enumerator<TValue>, IEnumerable<TValue>
        {
            public ValueEnumerator(KeyValueNode<TKey, TValue> first) : base(first)
            {
            }

            public override TValue Current => current.Value;

            public IEnumerator<TValue> GetEnumerator()
            {
                return this;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }


        protected class KeyValueEnumerator : Enumerator<KeyValueNode<TKey, TValue>>
        {
            public KeyValueEnumerator(KeyValueNode<TKey, TValue> first) : base(first)
            {
            }

            public override KeyValueNode<TKey, TValue> Current => current;
        }
    }
}