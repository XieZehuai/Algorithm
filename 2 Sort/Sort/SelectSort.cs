using System;

namespace _2_Sort
{
    /// <summary>
    /// 选择排序
    /// </summary>
    public class SelectSort<T> : IComparisonSorter<T> where T : IComparable<T>
    {
        public string Name => "选择排序";

        public void Sort(T[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        public void Sort(T[] arr, int low, int high)
        {
            for (int i = low; i <= high - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j <= high; j++)
                {
                    if (arr[j].CompareTo(arr[min]) < 0)
                    {
                        min = j;
                    }
                }

                T temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;
            }
        }
    }
}
