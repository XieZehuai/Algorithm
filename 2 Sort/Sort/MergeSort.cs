using System;

namespace _2_Sort
{
    class MergeSort : ISorter
    {
        public string Name => top ? "归并排序：自顶向下" : "归并排序：自底向上";

        private bool top;
        private InsertSort insertSort = new InsertSort();

        public MergeSort(bool top)
        {
            this.top = top;
        }

        public void Sort<T>(T[] arr) where T : IComparable<T>
        {
            Sort(arr, 0, arr.Length - 1);
        }

        public void Sort<T>(T[] arr, int low, int high) where T : IComparable<T>
        {
            if (top)
            {
                SortBT(arr, new T[arr.Length], low, high);
            }
            else
            {
                SortBU(arr, new T[arr.Length]);
            }
        }

        // 自顶向下的归并排序方法
        private void SortBT<T>(T[] arr, T[] temp, int low, int high) where T : IComparable<T>
        {
            if (high <= low + 10)
            {
                insertSort.Sort(arr, low, high);
                return;
            }

            int mid = low + (high - low) / 2;
            SortBT(arr, temp, low, mid);
            SortBT(arr, temp, mid + 1, high);

            if (arr[mid].CompareTo(arr[mid + 1]) <= 0) return;
            Merge(arr, temp, low, mid, high);
        }

        // 自底向上的归并排序方法
        private void SortBU<T>(T[] arr, T[] temp) where T : IComparable<T>
        {
            int len = arr.Length;
            for (int size = 1; size < len; size *= 2)
            {
                for (int index = 0; index < len - size; index += 2 * size)
                {
                    int mid = index + size - 1;
                    if (arr[mid].CompareTo(arr[mid + 1]) <= 0) continue;

                    Merge(arr, temp, index, mid, Math.Min(mid + size, len - 1));
                }
            }
        }

        private void Merge<T>(T[] arr, T[] temp, int low, int mid, int high) where T : IComparable<T>
        {
            for (int k = low; k <= high; k++)
            {
                temp[k] = arr[k];
            }

            int i = low;
            int j = mid + 1;
            for (int k = low; k <= high; k++)
            {
                if (i > mid) arr[k] = temp[j++];
                else if (j > high) arr[k] = temp[i++];
                else if (temp[i].CompareTo(temp[j]) < 0) arr[k] = temp[i++];
                else arr[k] = temp[j++];
            }
        }
    }
}
