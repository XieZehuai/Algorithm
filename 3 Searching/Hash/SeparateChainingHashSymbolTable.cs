using System.Collections.Generic;

namespace _3_Searching.Hash
{
    /// <summary>
    /// 基于拉链法的哈希表实现，通过哈希函数将key转换成一个hash，以hash作为索引
    /// 存到一个数组中，数组中的每个元素都是一个基于链表实现的顺序查找表，用于存储
    /// hash相同的key（hash的计算用除数取余法）
    /// </summary>
    public class SeparateChainingHashSymbolTable<TK, TV> : SymbolTable<TK, TV>
    {
        private int size; // 当前元素的个数
        private readonly int division; // 除数，用于计算hash
        private readonly SequentialSearchSymbolTable<TK, TV>[] datas;

        // 默认除数997
        public SeparateChainingHashSymbolTable() : this(997)
        {
        }

        public SeparateChainingHashSymbolTable(int division)
        {
            this.division = division;
            size = 0;

            datas = new SequentialSearchSymbolTable<TK, TV>[division];
            for (int i = 0; i < division; i++)
            {
                datas[i] = new SequentialSearchSymbolTable<TK, TV>();
            }
        }

        public override string Name => "拉链法哈希表";

        public override int Size => size;

        public override bool Contains(TK key)
        {
            return datas[GetHash(key)].Contains(key);
        }

        public override TV Get(TK key)
        {
            return datas[GetHash(key)].Get(key);
        }

        public override void Put(TK key, TV value)
        {
            datas[GetHash(key)].Put(key, value);
            size++;
        }

        public override void Delete(TK key)
        {
            datas[GetHash(key)].Delete(key);
            size--;
        }

        public override IEnumerator<KeyValue<TK, TV>> GetEnumerator()
        {
            List<KeyValue<TK, TV>> list = new List<KeyValue<TK, TV>>();

            for (int i = 0; i < datas.Length; i++)
            {
                if (!datas[i].IsEmpty)
                {
                    list.AddRange(datas[i]);
                }
            }

            return list.GetEnumerator();
        }

        /// <summary>
        /// 获取key对应的hash值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>对应的hash值</returns>
        protected virtual int GetHash(TK key)
        {
            // GetHashCode()方法返回一个int类型的hash值，有可能是负数
            // 所以通过和0x7FFFFFFF进行与运算，去掉符号位
            return (key.GetHashCode() & 0x7FFFFFFF) % division;
        }
    }
}