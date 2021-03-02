using System;
using System.Collections.Generic;

namespace _3_Searching
{
    /// <summary>
    /// 键有序的抽象泛型符号表接口
    /// </summary>
    public interface IOrderedSymbolTable<TKey, TValue> : ISymbolTable<TKey, TValue> where TKey : IComparable<TKey>
    {
        /// <summary>
        /// 获取最小的键
        /// </summary>
        TKey Min { get; }

        /// <summary>
        /// 获取最大的键
        /// </summary>
        TKey Max { get; }

        /// <summary>
        /// 删除最小的键以及对应的值
        /// </summary>
        void DeleteMin();

        /// <summary>
        /// 删除最大的键以及对应的值
        /// </summary>
        void DeleteMax();

        /// <summary>
        /// 获取小于等于该键的最大键
        /// </summary>
        TKey Floor(TKey key);

        /// <summary>
        /// 获取大于等于该键的最小键
        /// </summary>
        TKey Ceiling(TKey key);

        /// <summary>
        /// 获取小于该键的所有键的数量
        /// </summary>
        int Rank(TKey key);

        /// <summary>
        /// 根据排名找出对应的键
        /// </summary>
        TKey Select(int rank);

        /// <summary>
        /// 获取所有位于low和high之间的键的数量，包括low和high本身
        /// </summary>
        int SizeBetween(TKey low, TKey high);

        /// <summary>
        /// 获取所有位于low和high之间的键，包括low和high本身
        /// </summary>
        IEnumerable<TKey> KeysBetween(TKey low, TKey high);
    }
}
