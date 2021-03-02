using System;

namespace _2_Sort
{
    class QuickSort : ISorter
    {
        public string Name => "快速排序";

        private InsertSort insertSort = new InsertSort();

        public void Sort<T>(T[] arr) where T : IComparable<T>
        {
            Sort(arr, 0, arr.Length - 1);
        }

        public void Sort<T>(T[] arr, int low, int high) where T : IComparable<T>
        {
            if (high <= low + 10)
            {
                insertSort.Sort(arr, low, high);
            }
            else
            {
                int i = low, j = high;
                int mid = low + (high - low) / 2;
                T target = arr[mid];
                arr[mid] = arr[low];
                arr[low] = target;

                while (i < j)
                {
                    while (i < j && arr[j].CompareTo(target) >= 0)
                    {
                        j--;
                    }
                    if (i < j)
                    {
                        arr[i++] = arr[j];
                    }

                    while (i < j && arr[i].CompareTo(target) < 0)
                    {
                        i++;
                    }
                    if (i < j)
                    {
                        arr[j--] = arr[i];
                    }
                }

                arr[i] = target;
                Sort(arr, low, i - 1);
                Sort(arr, i + 1, high);
            }
        }
    }
}
