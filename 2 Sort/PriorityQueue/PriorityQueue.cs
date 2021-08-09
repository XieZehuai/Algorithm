using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace System.Collections.Generic
{
    [Serializable]
    [DebuggerTypeProxy(typeof(PriorityQueueDebugView<>))]
    [DebuggerDisplay("Count = {Count}")]
    [ComVisible(false)]
    public class PriorityQueue<T> : IEnumerable<T>, IEnumerable, ICollection, IReadOnlyCollection<T> where T : IComparable<T>
    {
        #region Enumerator

        [Serializable]
        public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
        {
            PriorityQueue<T> queue;
            private PriorityQueue<T> copy;
            private bool isFinish;
            private int version;
            private T currentElement;

            internal Enumerator(PriorityQueue<T> priorityQueue)
            {
                queue = priorityQueue;
                copy = new PriorityQueue<T>(priorityQueue);
                isFinish = false;
                version = priorityQueue.version;
                currentElement = default;
            }

            public T Current
            {
                get
                {
                    if (isFinish)
                    {
                        throw new InvalidOperationException();
                    }

                    return currentElement;
                }
            }

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (version != queue.version)
                {
                    throw new InvalidOperationException();
                }
                if (isFinish)
                {
                    return false;
                }
                if (copy.IsEmpty)
                {
                    isFinish = true;
                    currentElement = default;
                    return false;
                }

                currentElement = copy.Dequeue();
                return true;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                isFinish = true;
                copy = null;
                currentElement = default;
            }
        }

        #endregion


        #region PriorityQueueDebugView

        internal sealed class PriorityQueueDebugView<Type> where Type : IComparable<Type>
        {
            private PriorityQueue<Type> priorityQueue;

            public PriorityQueueDebugView(PriorityQueue<Type> priorityQueue)
            {
                this.priorityQueue = priorityQueue ?? throw new ArgumentNullException(nameof(priorityQueue));
            }

            public Type[] Items => priorityQueue.ToArray();
        }

        #endregion


        #region field

        private const int DEFAULT_CAPACITY = 4;
        private const int SIZE_GROW_FACTOR = 2;

        private T[] data;
        private int size;
        private int version;
        private int capacity;
        private readonly Func<T, T, int> Compare;

        [NonSerialized] private object syncRoot;

        #endregion

        #region constructor

        public PriorityQueue(IEnumerable<T> collection) : this()
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection is null");
            }

            foreach (T item in collection)
            {
                Enqueue(item);
            }
        }

        public PriorityQueue(int capacity = DEFAULT_CAPACITY, Func<T, T, int> Compare = null)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("capacity can't be less than 0, capacity: " + capacity);
            }

            this.capacity = capacity;
            data = new T[capacity + 1];
            size = 0;
            version = 0;
            this.Compare = Compare ?? DefaultCompare;
        }

        public PriorityQueue(PriorityQueue<T> priorityQueue)
        {
            capacity = priorityQueue.capacity;
            data = new T[capacity + 1];
            Array.Copy(priorityQueue.data, data, priorityQueue.data.Length);
            size = priorityQueue.size;
            version = 0;
            Compare = priorityQueue.Compare;
        }

        #endregion

        #region property

        public bool IsEmpty => Count == 0;

        public int Count => size;

        public int Capacity => capacity;

        bool ICollection.IsSynchronized => false;

        object ICollection.SyncRoot
        {
            get
            {
                if (syncRoot == null)
                {
                    Interlocked.CompareExchange<object>(ref syncRoot, new object(), null);
                }

                return syncRoot;
            }
        }

        #endregion

        #region public method

        public void Enqueue(T item)
        {
            if (size == capacity)
            {
                Resize();
            }

            data[++size] = item;
            Swim(size);
            version++;
        }

        public bool Contains(T item)
        {
            EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;

            for (int i = 1; i <= size; i++)
            {
                if (item == null)
                {
                    if (data[i] == null)
                    {
                        return true;
                    }
                }
                else if (data[i] != null && equalityComparer.Equals(data[i], item))
                {
                    return true;
                }
            }

            return false;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("queue is empty");
            }

            return data[1];
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("queue is empty");
            }

            T max = data[1];
            Swap(1, size);
            data[size--] = default;
            Sink(1);
            version++;

            return max;
        }

        public void Clear()
        {
            if (size > 0)
            {
                Array.Clear(data, 0, size);
            }

            size = 0;
            version++;
        }

        #endregion

        #region interface implementation

        public void CopyTo(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array is null");
            }
            if (index < 0 || index > array.Length)
            {
                throw new ArgumentOutOfRangeException("index is out of range, index: " + index);
            }
            if (array.Length - index < size)
            {
                throw new ArgumentException("array doesn't have enough space to copy elements");
            }

            PriorityQueue<T> copy = new PriorityQueue<T>(this);
            int endIndex = index + copy.size;
            for (int i = index; i < endIndex; i++)
            {
                array[i] = copy.Dequeue();
            }
        }

        public void CopyTo(Array array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array is null");
            }
            if (array.Rank != 1)
            {
                throw new ArgumentException("array must be a one-dimensional array");
            }
            if (array.GetLowerBound(0) != 0)
            {
                throw new ArgumentException("the starting index of the array must be 0");
            }
            if (index < 0 || index > array.Length)
            {
                throw new ArgumentOutOfRangeException("index is out of range, index: " + index);
            }
            if (array.Length - index < size)
            {
                throw new ArgumentException("array doesn't have enough space to copy elements");
            }

            T[] copy = this.ToArray();
            int num = (array.Length - index < copy.Length) ? (array.Length - index) : copy.Length;

            if (num != 0)
            {
                try
                {
                    Array.Copy(copy, 0, array, index, num);
                }
                catch (ArrayTypeMismatchException)
                {
                    throw new ArgumentException("array and queue element types do not match");
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        #endregion

        #region privare method

        private int DefaultCompare(T a, T b)
        {
            return a.CompareTo(b);
        }

        private void Resize()
        {
            capacity *= SIZE_GROW_FACTOR;
            T[] temp = new T[capacity + 1];
            Array.Copy(data, 1, temp, 1, data.Length - 1);
            data = temp;
        }

        private void Swim(int i)
        {
            while (i > 1 && Compare(data[i / 2], data[i]) < 0)
            {
                Swap(i / 2, i);
                i /= 2;
            }
        }

        private void Sink(int i)
        {
            while (2 * i <= size)
            {
                int j = 2 * i;

                if (j < size && Compare(data[j], data[j + 1]) < 0)
                {
                    j++;
                }

                if (Compare(data[i], data[j]) >= 0) break;

                Swap(i, j);
                i = j;
            }
        }

        private void Swap(int i, int j)
        {
            T temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }

        #endregion
    }
}
