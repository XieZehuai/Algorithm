using System;

namespace _2_Sort.PriorityQueue
{
    /// <summary>
    /// 有序的优先队列，删除操作O(1)时间，插入操作O(n)时间
    /// </summary>
    public class OrderedPriorityQueue<T> : PriorityQueue<T> where T : IComparable<T>
    {
        protected T[] datas; // 保存所有数据
        protected int size; // 当前数据个数
        protected int capacity;

        /// <summary>
        /// 创建一个容量为capacity的优先队列
        /// </summary>
        /// <param name="capacity">容量</param>
        public OrderedPriorityQueue(int capacity)
        {
            this.capacity = capacity;
            datas = new T[capacity];
            size = 0;
        }

        public override bool IsEmpty => size == 0;

        public override int Size => size;

        public override int Capacity => capacity;

        public override void Insert(T value)
        {
            if (size >= capacity)
            {
                capacity *= 2;
                T[] temp = new T[capacity];
                Array.Copy(datas, 0, temp, 0, datas.Length);
                datas = temp;
            }

            int i = size - 1;

            while (i >= 0 && value.CompareTo(datas[i]) < 0)
            {
                datas[i + 1] = datas[i];
                i--;
            }

            datas[i + 1] = value;
            size++;
        }

        public override T Max()
        {
            return datas[size - 1];
        }

        public override T DeleteMax()
        {
            return datas[--size];
        }

        public override void Print()
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(datas[i].ToString());
            }
        }

        /// <summary>
        /// 交换两个元素的位置
        /// </summary>
        /// <param name="i">第一个元素的位置</param>
        /// <param name="j">第二个元素的位置</param>
        protected virtual void Swap(int i, int j)
        {
            T temp = datas[i];
            datas[i] = datas[j];
            datas[j] = temp;
        }
    }
}
