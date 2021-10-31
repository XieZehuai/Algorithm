using System;
using System.Collections.Generic;

namespace _2_Sort.PriorityQueue
{
    /// <summary>
    /// 优先队列，使用IComparable接口比较元素优先级，可以设置该队列
    /// 为最大优先队列或是最小优先队列，最大优先队列中元素值越大优先
    /// 级越高，最小优先队列相反
    /// </summary>
    /// <typeparam name="T">实现IComparable接口的类型</typeparam>
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private T[] items;
        private int size;
        private readonly Func<T, T, int> compare;

        /// <summary>
        /// 创建一个优先队列，默认创建的是最小优先队列
        /// </summary>
        public PriorityQueue(bool maxHeap = false, int capacity = 4)
        {
            items = new T[capacity];
            size = 0;

            if (maxHeap)
            {
                compare = (a, b) => a.CompareTo(b);
            }
            else
            {
                compare = (a, b) => b.CompareTo(a);
            }
        }

        /// <summary>
        /// 创建一个优先队列，默认创建的是最小优先队列，并插入初始数据
        /// </summary>
        public PriorityQueue(IEnumerable<T> data, bool maxHeap = false, int capacity = 4) : this(maxHeap, capacity)
        {
            foreach (var item in data)
            {
                Enqueue(item);
            }
        }

        /// <summary>
        /// 队列是否为空
        /// </summary>
        public bool IsEmpty => size == 0;

        /// <summary>
        /// 当前队列中元素的个数
        /// </summary>
        public int Count => size;

        /// <summary>
        /// 将一个元素入队
        /// </summary>
        public void Enqueue(T item)
        {
            if (size == items.Length)
            {
                Resize();
            }

            items[size] = item;
            Swim(size++);
        }

        /// <summary>
        /// 获取队列头部元素，即优先级最高的元素
        /// </summary>
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("queue is empty");
            }

            return items[0];
        }

        /// <summary>
        /// 将优先级最高的元素出队
        /// </summary>
        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("queue is empty");
            }

            T max = items[0];
            items[0] = items[--size];
            Sink(0);

            return max;
        }

        /// <summary>
        /// 清除队列中的所有元素
        /// </summary>
        public void Clear()
        {
            if (size > 0)
            {
                Array.Clear(items, 0, size);
            }

            size = 0;
        }

        private void Resize()
        {
            T[] temp = items;
            items = new T[size * 2];
            Array.Copy(temp, 0, items, 0, size);
        }

        private void Swim(int i)
        {
            while (i > 0 && compare(items[i / 2], items[i]) < 0)
            {
                Swap(i / 2, i);
                i /= 2;
            }
        }

        private void Sink(int i)
        {
            while (i * 2 < size)
            {
                int j = i * 2;
                if (j == 0) j = 1;

                if (j + 1 < size && compare(items[j], items[j + 1]) < 0)
                {
                    j++;
                }

                if (compare(items[i], items[j]) >= 0) break;

                Swap(i, j);
                i = j;
            }
        }

        private void Swap(int i, int j)
        {
            T temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
    }
}
