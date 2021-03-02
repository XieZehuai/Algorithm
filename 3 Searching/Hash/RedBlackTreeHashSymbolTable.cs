using System;
using System.Collections.Generic;
using System.Linq;

namespace _3_Searching.Hash
{
    public class RedBlackTreeHashSymbolTable<TK, TV> : SymbolTable<TK, TV>
        where TK : IComparable<TK>
    {
        private int size;
        private readonly int division;
        private readonly RedBlackTreeSymbolTable<TK, TV>[] datas;

        public RedBlackTreeHashSymbolTable() : this(997)
        {
        }

        public RedBlackTreeHashSymbolTable(int division)
        {
            this.division = division;
            size = 0;
            datas = new RedBlackTreeSymbolTable<TK, TV>[division];

            for (int i = 0; i < division; i++)
            {
                datas[i] = new RedBlackTreeSymbolTable<TK, TV>();
            }
        }

        public override string Name => "红黑树哈希表";

        public override int Size => size;

        public override bool Contains(TK key)
        {
            return datas[GetHash(key)].Contains(key);
        }

        public override void Delete(TK key)
        {
            datas[GetHash(key)].Delete(key);
        }

        public override TV Get(TK key)
        {
            return datas[GetHash(key)].Get(key);
        }

        public override void Put(TK key, TV value)
        {
            datas[GetHash(key)].Put(key, value);
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

        protected virtual int GetHash(TK key)
        {
            // GetHashCode()方法返回一个int类型的hash值，有可能是负数
            // 所以通过和0x7FFFFFFF进行与运算，去掉符号位
            return (key.GetHashCode() & 0x7FFFFFFF) % division;
        }
    }
}