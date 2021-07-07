using System;
using System.Collections;
using System.Collections.Generic;

namespace _2_Sort.PriorityQueue
{
    public class IndexPriorityQueue<T> : IEnumerable<int> where T : IComparable<T>
    {
        private int capacity;
        private int count;
        private int[] heap; // 二叉堆，索引从1开始（索引为1 - n，长度为n + 1）
        private int[] inverseHeap; // heap的反向（inverseHeap[heap[i]] = heap[inverseHeap[i]] = i）
        private T[] keys;

        public IndexPriorityQueue(int capacity)
        {
            this.capacity = capacity;
            count = 0;
            keys = new T[capacity + 1];
            heap = new int[capacity + 1];
            inverseHeap = new int[capacity + 1];

            for (int i = 0; i <= capacity; i++)
            {
                heap[i] = -1;
            }
        }

        /// <summary>
        /// 队列是否为空
        /// </summary>
        public bool IsEmpty => count == 0;

        /// <summary>
        /// 队列中元素的个数
        /// </summary>
        public int Count => count;

        public T this[int i]
        {
            get
            {
                return KeyOf(i);
            }
            set
            {
                Change(i, value);
            }
        }

        /// <summary>
        /// 插入一个元素并为它指定一个索引
        /// </summary>
        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            count++;
            inverseHeap[index] = count;
            heap[count] = index;
            keys[index] = item;
            Swim(count);
        }

        /// <summary>
        /// 将索引为index的元素设为item
        /// </summary>
        public void Change(int index, T item)
        {
            ValidateIndex(index);
            if (!Contains(index)) throw new ArgumentOutOfRangeException($"索引{index}不在队列中");

            keys[index] = item;
            Swim(inverseHeap[index]);
            Sink(inverseHeap[index]);
        }

        /// <summary>
        /// 是否存在索引为index的元素
        /// </summary>
        public bool Contains(int index)
        {
            ValidateIndex(index);
            return inverseHeap[index] != -1;
        }

        /// <summary>
        /// 返回索引为index的元素
        /// </summary>
        public T KeyOf(int index)
        {
            ValidateIndex(index);
            if (!Contains(index)) throw new ArgumentOutOfRangeException($"索引{index}不在队列中");
            return keys[index];
        }

        /// <summary>
        /// 删除索引为index的元素
        /// </summary>
        public void Delete(int index)
        {
            ValidateIndex(index);
            if (!Contains(index)) throw new ArgumentOutOfRangeException($"索引{index}不在队列中");

            int i = inverseHeap[index];
            Swap(i, count--);
            Swim(i);
            Sink(i);
            keys[index] = default;
            inverseHeap[index] = -1;
        }

        /// <summary>
        /// 获取优先级最大的元素
        /// </summary>
        public T Max()
        {
            if (count == 0) throw new NullReferenceException("队列为空");
            return keys[heap[1]];
        }

        /// <summary>
        /// 删除优先级最大的元素并返回它的索引
        /// </summary>
        public int DeleteMax()
        {
            if (count == 0) throw new NullReferenceException("队列为空");

            int max = heap[1];
            Swap(1, count--);
            Sink(1);
            inverseHeap[max] = -1;
            keys[max] = default;
            heap[count + 1] = -1;

            return max;
        }

        /// <summary>
        /// 获取优先级最大的元素的索引
        /// </summary>
        /// <returns>如果队列为空返回-1</returns>
        public int MaxIndex()
        {
            if (count == 0) throw new NullReferenceException("队列为空");
            return heap[1];
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new HeapEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        /// <summary>
        /// 判断索引是否合法
        /// </summary>
        private void ValidateIndex(int index)
        {
            if (index < 0) throw new ArgumentOutOfRangeException($"索引不能小于0，index = {index}");
            if (index >= capacity) throw new ArgumentOutOfRangeException($"索引不能大于队列容量，capacity = {capacity}, index = {index}");
        }

        /// <summary>
        /// 上浮操作，将索引为index的元素上移到正确的位置
        /// </summary>
        private void Swim(int index)
        {
            while (index > 1 && Greater(index / 2, index))
            {
                Swap(index, index / 2);
                index /= 2;
            }
        }

        /// <summary>
        /// 下沉操作，将索引为index的元素下移到正确的位置
        /// </summary>
        private void Sink(int index)
        {
            while (2 * index <= count)
            {
                int j = 2 * index;
                if (j < count && Greater(j, j + 1)) j++;
                if (!Greater(index, j)) break;
                Swap(index, j);
                index = j;
            }
        }

        /// <summary>
        /// 交换两个元素的位置
        /// </summary>
        private void Swap(int a, int b)
        {
            int temp = heap[a];
            heap[a] = heap[b];
            heap[b] = temp;
            inverseHeap[heap[a]] = a;
            inverseHeap[heap[b]] = b;
        }

        /// <summary>
        /// 判断索引为a的元素是否大于索引为b的元素
        /// </summary>
        private bool Greater(int a, int b)
        {
            return keys[heap[a]].CompareTo(keys[heap[b]]) > 0;
        }


        #region 迭代器，用于遍历优先队列
        private class HeapEnumerator : IEnumerator<int>
        {
            private IndexPriorityQueue<T> queue;
            private IndexPriorityQueue<T> copy;

            public HeapEnumerator(IndexPriorityQueue<T> queue)
            {
                this.queue = queue;
                Copy();
            }

            public int Current { get; private set; }

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (copy.IsEmpty) return false;

                Current = copy.DeleteMax();
                return true;
            }

            public void Reset()
            {
                Copy();
            }

            public void Dispose()
            {
                queue = null;
            }

            private void Copy()
            {
                copy = new IndexPriorityQueue<T>(queue.capacity);
                for (int i = 1; 1 <= queue.count; i++)
                {
                    copy.Insert(queue.heap[i], queue.keys[queue.heap[i]]);
                }
            }
        }
        #endregion
    }
}
