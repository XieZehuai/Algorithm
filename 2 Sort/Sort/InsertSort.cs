using System;

namespace _2_Sort
{
    /// <summary>
    /// 插入排序
    /// </summary>
    public class InsertSort<T> : IComparisonSorter<T> where T : IComparable<T>
    {
        public string Name => "插入排序";

        public void Sort(T[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        public void Sort(T[] arr, int low, int high)
        {
            for (int i = low + 1; i <= high; i++)
            {
                T temp = arr[i];
                int j = i;
                while (j > low && temp.CompareTo(arr[j - 1]) < 0)
                {
                    j--;
                    arr[j + 1] = arr[j];
                }
                arr[j] = temp;
            }
        }
    }
}
