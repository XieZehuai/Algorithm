using System.Collections.Generic;

namespace _4_Graph.GraphSearchAlgorithm
{
    /// <summary>
    /// 图路径搜索算法接口，用于判断给定顶点与目标顶点之间是否存在一条路径以及找出
    /// 这条路径上的所有顶点
    /// </summary>
    public interface IGraphPathSearch
    {
        string Name { get; }

        /// <summary>
        /// 判断与目标顶点之间是否存在一条路径
        /// </summary>
        bool HasPathTo(int target);

        /// <summary>
        /// 获取到目标顶点路径上的所有顶点
        /// </summary>
        IEnumerable<int> PathTo(int target);
    }
}
