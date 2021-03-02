using System;

namespace _2_Sort
{
    public static class ArrayExtension
    {
        /// <summary>
        /// 交换数组中两个元素的位置
        /// </summary>
        /// <typeparam name="T">数据元素的数据类型</typeparam>
        /// <param name="l">第一个元素的索引</param>
        /// <param name="r">第二个元素的索引</param>
        public static void Swap<T>(this T[] arr, int l, int r)
        {
            if (l < 0 || l >= arr.Length || r < 0 || r >= arr.Length)
            {
                throw new IndexOutOfRangeException("要交换的元素索引越界：" + l + " " + r);
            }

            T temp = arr[l];
            arr[l] = arr[r];
            arr[r] = temp;
        }
    }
}
