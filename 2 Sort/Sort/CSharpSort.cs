using System;
using System.Collections.Generic;

namespace _2_Sort
{
    /*
     * C#自带排序算法
     */
    public class CSharpSort : ISorter
    {
        public string Name => "C#自带排序";

        public delegate int Compare<T>(T x, T y);

        private class Comparer<T> : IComparer<T>
        {
            private readonly Compare<T> compare;

            public Comparer(Compare<T> compare)
            {
                this.compare = compare;
            }

            public int Compare(T x, T y)
            {
                return compare(x, y);
            }
        }

        public void Test<T>(T[] arr, Compare<T> compare)
        {
            Array.Sort(arr, new Comparer<T>(compare));
        }

        public void Sort<T>(T[] arr) where T : IComparable<T>
        {
            Array.Sort(arr);
        }

        public void Sort<T>(T[] arr, int low, int high) where T : IComparable<T>
        {
            Array.Sort(arr, low, high - low + 1);
        }
    }
}
