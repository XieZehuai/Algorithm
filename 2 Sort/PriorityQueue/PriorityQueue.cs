using System;

namespace _2_Sort.PriorityQueue
{
    public abstract class PriorityQueue<T> where T : IComparable<T>
    {
        /// <summary>
        /// 判断队列是否为空
        /// </summary>
        public abstract bool IsEmpty { get; }

        /// <summary>
        /// 获取队列元素数量
        /// </summary>
        public abstract int Size { get; }

        /// <summary>
        /// 获取队列的最大容量
        /// </summary>
        public virtual int Capacity { get; }

        /// <summary>
        /// 向队列中插入一个元素
        /// </summary>
        /// <param name="value">要插入的元素</param>
        public abstract void Insert(T value);

        /// <summary>
        /// 获取队列中优先级最高的元素
        /// </summary>
        /// <returns>优先级最高的元素</returns>
        public abstract T Max();

        /// <summary>
        /// 获取并删除队列中优先级最高的元素
        /// </summary>
        /// <returns>优先级最高的元素</returns>
        public abstract T DeleteMax();

        /// <summary>
        /// 打印队列中的所有元素
        /// </summary>
        public virtual void Print()
        {
            Console.WriteLine(GetType() + " not implement Print method");
        }
    }
}
