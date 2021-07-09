using System;

namespace _2_Sort
{
    /// <summary>
    /// 堆排序
    /// </summary>
    public class HeapSort<T> : IComparisonSorter<T> where T : IComparable<T>
    {
        public string Name => "堆排序";

        public void Sort(T[] arr)
        {
            int len = arr.Length;

            for (int i = len / 2; i >= 1; i--)
            {
                Sink(arr, i, len);
            }

            while (len > 1)
            {
                arr.Swap(0, --len);
                Sink(arr, 1, len);
            }
        }

        public void Sort(T[] arr, int low, int high)
        {
            throw new NotImplementedException();
        }

        private void Sink(T[] arr, int k, int length)
        {
            while (2 * k <= length)
            {
                int j = 2 * k;

                if (j < length && arr[j - 1].CompareTo(arr[j]) < 0)
                {
                    j++;
                }

                if (arr[k - 1].CompareTo(arr[j - 1]) >= 0) break;

                arr.Swap(k - 1, j - 1);
                k = j;
            }
        }
    }
}
