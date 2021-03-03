namespace _4_Graph
{
    /// <summary>
    /// 有向图接口
    /// </summary>
    public interface IDirectedGraph : IGraph
    {
        /// <summary>
        /// 获取图的反向图
        /// </summary>
        IDirectedGraph Reverse();
    }
}
