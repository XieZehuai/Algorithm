using System;

namespace _2_Sort
{
    /// <summary>
    /// 冒泡排序
    /// </summary>
    public class BubbleSort<T> : IComparisonSorter<T> where T : IComparable<T>
    {
        public string Name => "冒泡排序";

        public void Sort(T[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        public void Sort(T[] arr, int low, int high)
        {
            bool isSorted = false;
            int j = 1;

            while (!isSorted)
            {
                isSorted = true;

                for (int i = low; i <= high - j; i++)
                {
                    if (arr[i].CompareTo(arr[i + 1]) > 0)
                    {
                        T temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        isSorted = false;
                    }
                }

                j++;
            }
        }
    }
}
