using System;
using System.Collections.Generic;

namespace _2_Sort
{
    /// <summary>
    /// C#自带的排序算法
    /// </summary>
    public class CSharpSort<T> : IComparisonSorter<T> where T : IComparable<T>
    {
        #region
        public delegate int Compare(T x, T y);

        private class Comparer : IComparer<T>
        {
            private readonly Compare compare;

            public Comparer(Compare compare)
            {
                this.compare = compare;
            }

            public int Compare(T x, T y)
            {
                return compare(x, y);
            }
        }
        #endregion

        public string Name => "C#自带排序";

        public void Sort(T[] arr)
        {
            Array.Sort(arr);
        }

        public void Sort(T[] arr, int low, int high)
        {
            Array.Sort(arr, low, high - low + 1);
        }

        public void Sort(T[] arr, Compare compare)
        {
            Array.Sort(arr, new Comparer(compare));
        }
    }
}
