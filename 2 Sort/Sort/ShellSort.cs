using System;

namespace _2_Sort
{
    /// <summary>
    /// 希尔排序，改进自插入排序，将数组分成固定距离的子数组，
    /// 对子数组进行插入排序，然后缩短距离，继续进行插入排序
    /// </summary>
    public class ShellSort<T> : IComparisonSorter<T> where T : IComparable<T>
    {
        public string Name => "希尔排序";

        public void Sort(T[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        public void Sort(T[] arr, int low, int high)
        {
            int h = 1;
            while (h < arr.Length / 3) h = 3 * h + 1; // 设定初始间距（1、4、13、40、121、364）

            while (h >= 1)
            {
                for (int i = h + low; i <= high; i++)
                {
                    T temp = arr[i];
                    int j = i;
                    while (j >= h + low && temp.CompareTo(arr[j - h]) < 0)
                    {
                        j -= h;
                        arr[j + h] = arr[j];
                    }
                    arr[j] = temp;
                }

                h /= 3; // 缩短距离
            }
        }
    }
}
