using System.Collections.Generic;

namespace _3_Searching
{
    /// <summary>
    /// 抽象泛型符号表接口，用于表示能够存储键值对以及进行相应的操作的数据结构
    /// </summary>
    public interface ISymbolTable<TKey, TValue>
    {
        /// <summary>
        /// 符号表是否为空
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// 当前符号表中键值对个数
        /// </summary>
        int Size { get; }

        /// <summary>
        /// 获取所有键的集合
        /// </summary>
        IEnumerable<TKey> Keys { get; }

        /// <summary>
        /// 获取所有值的集合
        /// </summary>
        IEnumerable<TValue> Values { get; }

        /// <summary>
        /// 向表中添加一个键值对，如果符号表中没有对应的键，则会创建一个
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        void Put(TKey key, TValue value);

        /// <summary>
        /// 根据键获取值
        /// </summary>
        /// <param name="key">健</param>
        /// <returns>对应的值</returns>
        TValue Get(TKey key);

        /// <summary>
        /// 根据键删除对应的值以及健本身
        /// </summary>
        /// <param name="key">键</param>
        void Delete(TKey key);

        /// <summary>
        /// 判断是否包含某个键
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>包含返回true，不包含返回false</returns>
        bool Contains(TKey key);
    }
}
