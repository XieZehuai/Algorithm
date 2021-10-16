using System;
using System.Collections.Generic;

namespace _2_Sort.PriorityQueue
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private T[] items;
        private int size;
        private readonly Func<T, T, int> compare;

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

        public PriorityQueue(IEnumerable<T> data, bool maxHeap = false, int capacity = 4) : this(maxHeap, capacity)
        {
            foreach (var item in data)
            {
                Enqueue(item);
            }
        }

        public bool IsEmpty => size == 0;

        public int Count => size;

        public void Enqueue(T item)
        {
            if (size == items.Length)
            {
                Resize();
            }

            items[size] = item;
            Swim(size++);
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("queue is empty");
            }

            return items[0];
        }

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
