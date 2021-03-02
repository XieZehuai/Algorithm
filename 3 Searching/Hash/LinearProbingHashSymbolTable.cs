using System.Collections.Generic;

namespace _3_Searching.Hash
{
    /// <summary>
    /// 基于线性探测法的哈希表，通过用一个大小大于等于所有键值对数量的数组来保存
    /// 所有键值对，以键的hash值作为数组的下标，出现hash冲突时，就按顺序查找下
    /// 一个位置，直到找到对应的key或者空位，设a = size / capacity，查找命中
    /// 需要探测0.5 * (1 + 1 / a)次，未命中需要探测0.5 * (1 + (1 / a)²)，
    /// 所以在元素个数为数组大小一般时，每次查找的次数介于1.5到2.5次之间，如果
    /// 元素个数接近数组大小，那么查找次数就会非常大
    /// </summary>
    /// <typeparam name="TK">键的数据类型</typeparam>
    /// <typeparam name="TV">值的数据类型</typeparam>
    public class LinearProbingHashSymbolTable<TK, TV> : SymbolTable<TK, TV>
    {
        private int size = 0; // 当前元素个数
        private int capacity = 16; // 最大容量
        private TK[] keys; // 保存键
        private TV[] values; // 保存值
        private bool[] slots; // 因为无法根据TK的值来确定该位置是否为空，所以用个辅助数组来记录每个位置是否被占用

        public LinearProbingHashSymbolTable()
        {
            keys = new TK[capacity];
            values = new TV[capacity];
            slots = new bool[capacity];
        }

        public LinearProbingHashSymbolTable(int capacity)
        {
            this.capacity = capacity;
            keys = new TK[capacity];
            values = new TV[capacity];
            slots = new bool[capacity];
        }

        public override string Name => "线性探测哈希表";

        public override int Size => size;

        public override bool Contains(TK key)
        {
            for (int i = GetHash(key); slots[i]; i = (i + 1) % capacity)
            {
                if (keys[i].Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        public override TV Get(TK key)
        {
            for (int i = GetHash(key); slots[i]; i = (i + 1) % capacity)
            {
                if (keys[i].Equals(key))
                {
                    return values[i];
                }
            }

            throw new KeyNotFoundException();
        }

        public override void Put(TK key, TV value)
        {
            // 要实现高效的性能，需要保证元素个数不超过数组大小的一半
            if (size >= capacity / 2)
            {
                Resize(capacity * 2);
            }

            int i;
            for (i = GetHash(key); slots[i]; i = (i + 1) % capacity)
            {
                if (keys[i].Equals(key))
                {
                    values[i] = value;
                    return;
                }
            }

            keys[i] = key;
            values[i] = value;
            slots[i] = true;
            size++;
        }

        public override void Delete(TK key)
        {
            if (!Contains(key)) throw new KeyNotFoundException();

            // 查找目标key的索引
            int index = GetHash(key);
            while (!keys[index].Equals(key))
            {
                index = (index + 1) % capacity;
            }

            slots[index] = false; // 把目标键值对删掉
            size--;
            
            // 删掉后需要把后面的数据重新插入到表中，因为后面的key的hash有可能
            // 与当前的key一样
            index = (index + 1) % capacity;
            while (slots[index])
            {
                // 先删掉当前位置的数据然后再重新插入到表中
                slots[index] = false;
                size--;
                Put(keys[index], values[index]);
                index = (index + 1) % capacity;
            }

            // 当元素个数不大于数组大小的八分之一时，减小数组的大小
            if (size > 0 && size <= capacity / 8) Resize(capacity / 2);
        }

        public override IEnumerator<KeyValue<TK, TV>> GetEnumerator()
        {
            List<KeyValue<TK, TV>> list = new List<KeyValue<TK, TV>>();
            for (int i = 0; i < capacity; i++)
            {
                if (slots[i])
                {
                    list.Add(new KeyValue<TK, TV>(keys[i], values[i]));
                }
            }

            return list.GetEnumerator();
        }

        /// <summary>
        /// 获取key对应的hash值
        /// </summary>
        protected virtual int GetHash(TK key)
        {
            return (key.GetHashCode() & 0x7FFFFFFF) % capacity;
        }

        /// <summary>
        /// 调整数组的大小，让元素个数与数组大小的比例保持在一个合理的范围内
        /// </summary>
        protected virtual void Resize(int newCapacity)
        {
            // 保存原来的数据
            TK[] keyTemp = keys;
            TV[] valueTemp = values;
            bool[] slotTemp = slots;
            
            // 重新分配空间
            capacity = newCapacity;
            keys = new TK[newCapacity];
            values = new TV[newCapacity];
            slots = new bool[newCapacity];

            // 存回原来的数据
            for (int i = 0; i < slotTemp.Length; i++)
            {
                if (slotTemp[i])
                {
                    Put(keyTemp[i], valueTemp[i]);
                }
            }
        }
    }
}