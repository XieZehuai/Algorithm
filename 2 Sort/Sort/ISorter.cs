namespace _2_Sort
{
    /// <summary>
    /// 定义对泛型数组的排序方法
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    public interface ISorter<T>
    {
        /// <summary>
        /// 排序算法的名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 对整个数组排序
        /// </summary>
        /// <param name="data"></param>
        void Sort(T[] data);

        /// <summary>
        /// 对数组从low到high范围内的元素排序
        /// </summary>
        /// <param name="data">要排序的数据</param>
        /// <param name="low">排序范围的最小索引值</param>
        /// <param name="high">排序范围的最大索引值</param>
        void Sort(T[] data, int low, int high);
    }
}
