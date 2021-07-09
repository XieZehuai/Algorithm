using System;

namespace _2_Sort
{
    /// <summary>
    /// 基于比较的排序算法
    /// </summary>
    /// <typeparam name="T">任意实现IComparable接口的数据类型</typeparam>
    public interface IComparisonSorter<T> : ISorter<T> where T : IComparable<T>
    {
    }
}
