using System;
using System.Collections;
using System.Collections.Generic;

namespace _3_Searching
{
    public partial class CSharpDictionary<TKey, TValue> : SymbolTable<TKey, TValue>
    {
        private Dictionary<TKey, TValue> dic;

        public CSharpDictionary()
        {
            dic = new Dictionary<TKey, TValue>();
        }

        public override string Name => "C#自带字典";

        public override int Size => dic.Count;

        public override bool Contains(TKey key)
        {
            return dic.ContainsKey(key);
        }

        public override void Delete(TKey key)
        {
            dic.Remove(key);
        }

        public override TValue Get(TKey key)
        {
            if (!Contains(key))
            {
                throw new KeyNotFoundException();
            }

            return dic[key];
        }

        public override IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            List<KeyValue<TKey, TValue>> list = new List<KeyValue<TKey, TValue>>();
            foreach (var item in dic)
            {
                list.Add(new KeyValue<TKey, TValue>(item.Key, item.Value));
            }

            return list.GetEnumerator();
        }

        public override void Put(TKey key, TValue value)
        {
            if (Contains(key))
            {
                dic[key] = value;
            }
            else
            {
                dic.Add(key, value);
            }
        }
    }


    public partial class CSharpDictionary<TKey, TValue>
    {
        protected class KeyValueEnumerator : IEnumerator<KeyValue<TKey, TValue>>
        {
            private Dictionary<TKey, TValue> dic;

            public KeyValueEnumerator(Dictionary<TKey, TValue> dic)
            {
                this.dic = dic;
            }

            public KeyValue<TKey, TValue> Current => throw new NotImplementedException();

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
