namespace _4_Graph.GraphSearchAlgorithm
{
    /// <summary>
    /// 图搜索算法接口，用于计算图中的顶点是否与其他顶点连通，以及图中与当前顶点连通的所有顶点的数量
    /// </summary>
    public interface IGraphSearch
    {
        string Name { get; }

        /// <summary>
        /// 判断顶点与目标顶点是否连通（不是相邻）
        /// </summary>
        /// <param name="target">目标顶点</param>
        bool IsConnectedTo(int target);

        /// <summary>
        /// 获取图中与当前顶点连通的所有顶点的数量
        /// </summary>
        /// <returns></returns>
        int Count();
    }
}
