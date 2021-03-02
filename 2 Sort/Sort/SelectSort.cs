using System;

namespace _2_Sort
{
    class SelectSort : ISorter
    {
        public string Name => "选择排序";

        public void Sort<T>(T[] arr) where T : IComparable<T>
        {
            Sort(arr, 0, arr.Length - 1);
        }

        public void Sort<T>(T[] arr, int low, int high) where T : IComparable<T>
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
