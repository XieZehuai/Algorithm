using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _3_Searching
{
    /// <summary>
    /// 用链表实现的符号表，每次插入和删除都会从头节点开始顺序遍历整个
    /// 链表直到找到目标元素或者链表末尾
    /// </summary>
    public class SequentialSearchSymbolTable<TKey, TValue> : SymbolTable<TKey, TValue>
    {
        private KeyValueNode<TKey, TValue> first = null;
        private int size = 0;

        public override string Name => "顺序搜索表";

        public override int Size => size;

        public override IEnumerable<TKey> Keys => first?.Keys;

        public override IEnumerable<TValue> Values => first?.Values;

        public override void Delete(TKey key)
        {
            if (!IsEmpty)
            {
                if (first.Key.Equals(key))
                {
                    first = first.next;
                    size--;
                    return;
                }

                for (KeyValueNode<TKey, TValue> node = first; node.next != null; node = node.next)
                {
                    if (node.next.Key.Equals(key))
                    {
                        node.next = node.next.next;
                        size--;
                        return;
                    }
                }
            }

            throw new KeyNotFoundException("在表中找不到键" + key);
        }

        public override TValue Get(TKey key)
        {
            TValue value = default;
            Find(key, node => value = node.Value,
                () => throw new KeyNotFoundException("在表中找不到键" + key));

            return value;
        }

        public override void Put(TKey key, TValue value)
        {
            Find(key, node => node.Value = value,
                () => first = new KeyValueNode<TKey, TValue>(key, value, first));
            size++;
        }

        public override bool Contains(TKey key)
        {
            bool find = false;
            Find(key, node => find = true, null);

            return find;
        }

        protected virtual void Find(TKey key, Action<KeyValueNode<TKey, TValue>> onSuccess,
            Action onFailed)
        {
            if (!IsEmpty)
            {
                for (KeyValueNode<TKey, TValue> node = first; node != null; node = node.next)
                {
                    if (node.Key.Equals(key))
                    {
                        onSuccess?.Invoke(node);
                        return;
                    }
                }
            }

            onFailed?.Invoke();
        }

        public override IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            return first.GetEnumerator();
        }
    }
}