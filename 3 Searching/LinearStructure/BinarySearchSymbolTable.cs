using System;
using System.Collections;
using System.Collections.Generic;

namespace _3_Searching
{
    /*
     * 基于二分查找实现的符号表，内部用两个平行数组存储key和value，
     * 每次插入时都会重新排列，保证key的按顺序排列的
     */
    public partial class BinarySearchSymbolTable<TKey, TValue> : OrderedSymbolTable<TKey, TValue> where TKey : IComparable<TKey>
    {
        private TKey[] keys;
        private TValue[] values;
        private int size;

        public BinarySearchSymbolTable()
        {
            keys = new TKey[10];
            values = new TValue[10];
            size = 0;
        }

        public BinarySearchSymbolTable(int capacity)
        {
            keys = new TKey[capacity];
            values = new TValue[capacity];
            size = 0;
        }

        public override string Name => "二分搜索顺序表";

        public override int Size => size;

        public override TKey Min => keys[0];

        public override TKey Max => keys[size - 1];

        public override IEnumerable<TValue> Values => new ValueEnumerator(keys, values, 0, size - 1);

        public override TValue Get(TKey key)
        {
            if (!IsEmpty)
            {
                int index = Rank(key);
                if (index < size && keys[index].CompareTo(key) == 0) return values[index];
            }

            throw new KeyNotFoundException("在表中找不到键" + key);
        }

        public override bool Contains(TKey key)
        {
            if (!IsEmpty)
            {
                int index = Rank(key);
                if (index < size && keys[index].CompareTo(key) == 0) return true;
            }

            return false;
        }

        public override void Put(TKey key, TValue value)
        {
            int index = Rank(key);
            if (index < size && keys[index].CompareTo(key) == 0)
            {
                values[index] = value;
                return;
            }

            if (size == keys.Length)
            {
                int capacity = size * 2;
                TKey[] keyTemp = new TKey[capacity];
                TValue[] valueTemp = new TValue[capacity];
                Array.Copy(keys, 0, keyTemp, 0, size);
                Array.Copy(values, 0, valueTemp, 0, size);
                keys = keyTemp;
                values = valueTemp;
            }

            for (int i = size; i > index; i--)
            {
                keys[i] = keys[i - 1];
                values[i] = values[i - 1];
            }

            keys[index] = key;
            values[index] = value;
            size++;
        }

        public override void Delete(TKey key)
        {
            if (!IsEmpty)
            {
                int index = Rank(key);
                if (index < size && keys[index].CompareTo(key) == 0)
                {
                    for (int i = index; i < size - 1; i++)
                    {
                        keys[i] = keys[i + 1];
                        values[i] = values[i + 1];
                    }

                    size--;
                    return;
                }
            }

            throw new KeyNotFoundException("在表中找不到键" + key);
        }

        public override int Rank(TKey key)
        {
            return Rank(key, 0, size - 1);
        }

        protected virtual int Rank(TKey key, int low, int high)
        {
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int cmp = key.CompareTo(keys[mid]);

                if (cmp == 0)
                {
                    return mid;
                }
                else if (cmp > 0)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return low;
        }

        public override TKey Select(int rank)
        {
            return keys[rank];
        }

        public override TKey Ceiling(TKey key)
        {
            int index = Rank(key);
            if (index == size) throw new ArgumentOutOfRangeException();

            return keys[index];
        }

        public override TKey Floor(TKey key)
        {
            int index = Rank(key);
            if (index < size && keys[index].CompareTo(key) == 0) return keys[index];
            if (index == 0) throw new ArgumentOutOfRangeException();

            return keys[index - 1];
        }

        public override IEnumerable<TKey> KeysBetween(TKey low, TKey high)
        {
            if (low.CompareTo(high) > 0) throw new ArgumentException();

            return new KeyEnumerator(keys, values, Rank(low), Rank(high));
        }

        public override IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            return new KeyValueEnumerator(keys, values, 0, size - 1);
        }
    }


    public partial class BinarySearchSymbolTable<TKey, TValue>
    {
        protected abstract class Enumerator<T> : IEnumerator<T>
        {
            protected TKey[] keys;
            protected TValue[] values;
            protected int low;
            protected int high;
            protected int current;

            protected Enumerator(TKey[] keys, TValue[] values, int low, int high)
            {
                this.keys = keys;
                this.values = values;
                this.low = low;
                this.high = high;
                current = low - 1;
            }

            public abstract T Current { get; }

            object IEnumerator.Current => Current;

            public virtual bool MoveNext()
            {
                return current++ < high;
            }

            public void Reset()
            {
                current = low - 1;
            }

            public void Dispose()
            {
                keys = null;
                values = null;
            }
        }


        protected class KeyValueEnumerator : Enumerator<KeyValue<TKey, TValue>>
        {
            public KeyValueEnumerator(TKey[] keys, TValue[] values, int low, int high) : base(keys, values, low, high)
            {
            }

            public override KeyValue<TKey, TValue> Current =>
                new KeyValue<TKey, TValue>(keys[current], values[current]);
        }


        protected class KeyEnumerator : Enumerator<TKey>, IEnumerable<TKey>
        {
            public KeyEnumerator(TKey[] keys, TValue[] values, int low, int high) : base(keys, values, low, high)
            {
            }

            public override TKey Current => keys[current];

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
            public ValueEnumerator(TKey[] keys, TValue[] values, int low, int high) : base(keys, values, low, high)
            {
            }

            public override TValue Current => values[current];

            public IEnumerator<TValue> GetEnumerator()
            {
                return this;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
