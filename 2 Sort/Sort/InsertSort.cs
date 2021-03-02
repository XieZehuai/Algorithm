using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Sort
{
    class InsertSort : ISorter
    {
        public string Name => "插入排序";

        public void Sort<T>(T[] arr) where T : IComparable<T>
        {
            Sort(arr, 0, arr.Length - 1);
        }

        public void Sort<T>(T[] arr, int low, int high) where T : IComparable<T>
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
