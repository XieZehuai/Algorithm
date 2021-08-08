using System;

namespace _2_Sort.PriorityQueue
{
    public interface IPriorityQueue<T> where T : IComparable<T>
    {
        /// <summary>
        /// 判断队列是否为空
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// 获取队列元素数量
        /// </summary>
        int Size { get; }

        /// <summary>
        /// 获取队列的最大容量
        /// </summary>
        int Capacity { get; }

        /// <summary>
        /// 向队列中插入一个元素
        /// </summary>
        /// <param name="value">要插入的元素</param>
        void Insert(T value);

        /// <summary>
        /// 获取队列中优先级最高的元素
        /// </summary>
        /// <returns>优先级最高的元素</returns>
        T Max();

        /// <summary>
        /// 获取并删除队列中优先级最高的元素
        /// </summary>
        /// <returns>优先级最高的元素</returns>
        T DeleteMax();

        void Print();
    }
}
