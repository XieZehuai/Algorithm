using System;
using System.Collections.Generic;

namespace _2_Sort.PriorityQueue
{
    /// <summary>
    /// 用堆实现的优先队列，插入和删除的时间都为O(lgN)
    /// </summary>
    public class HeapPriorityQueue<T> : OrderedPriorityQueue<T> where T : IComparable<T>
    {
        public HeapPriorityQueue(int capacity) : base(capacity + 1)
        {
            this.capacity = capacity;
        }

        public HeapPriorityQueue(IEnumerable<T> items) : base(9)
        {
            capacity = 8;

            foreach (var item in items)
            {
                Insert(item);
            }
        }

        public override void Insert(T value)
        {
            if (size >= capacity)
            {
                capacity *= 2;
                T[] temp = new T[capacity];
                Array.Copy(datas, 1, temp, 1, datas.Length - 1);
                datas = temp;
            }

            datas[++size] = value;
            Swim(size);
        }

        public override T Max()
        {
            if (IsEmpty)
            {
                throw new QueueEmptyException();
            }

            return datas[1];
        }

        public override T DeleteMax()
        {
            if (IsEmpty)
            {
                throw new QueueEmptyException();
            }

            T max = datas[1];
            Swap(1, size);
            datas[size--] = default;
            Sink(1);

            return max;
        }

        public override void Print()
        {
            for (int i = 1; i <= size; i++)
            {
                Console.WriteLine(datas[i].ToString());
            }
        }

        /// <summary>
        /// 将第k个位置的元素按照层级关系向上移动，维持父节点大于子节点的结构
        /// </summary>
        /// <param name="k">元素的位置</param>
        private void Swim(int k)
        {
            while (k > 1 && datas[k / 2].CompareTo(datas[k]) < 0)
            {
                Swap(k / 2, k);
                k /= 2;
            }
        }

        /// <summary>
        /// 将第k个位置的元素按照层次关系向下移动，维持父节点大于直接点的结构
        /// </summary>
        /// <param name="k">元素的位置</param>
        private void Sink(int k)
        {
            while (2 * k <= size)
            {
                int j = 2 * k;

                if (j < size && datas[j].CompareTo(datas[j + 1]) < 0)
                {
                    j++;
                }

                if (datas[k].CompareTo(datas[j]) >= 0) break;

                Swap(k, j);
                k = j;
            }
        }
    }
}
