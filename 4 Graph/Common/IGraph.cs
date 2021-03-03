using System.Collections;
using System.Collections.Generic;

namespace _4_Graph
{
    /// <summary>
    /// 无向图接口
    /// </summary>
    public interface IGraph
    {
        /// <summary>
        /// 顶点数
        /// </summary>
        int VertexCount { get; }

        /// <summary>
        /// 边数
        /// </summary>
        int EdgeCount { get; }

        /// <summary>
        /// 添加一条边
        /// </summary>
        /// <param name="from">第一个顶点</param>
        /// <param name="to">第二个顶点</param>
        void AddEdge(int from, int to);

        /// <summary>
        /// 获取与目标顶点相邻的所有顶点
        /// </summary>
        IEnumerable<int> Adjacent(int vertex);
    }
}