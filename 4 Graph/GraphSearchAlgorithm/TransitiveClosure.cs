using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Graph.GraphSearchAlgorithm
{
    /// <summary>
    /// 有向图的传递闭包，用于计算有向图中从一个给定的顶点开始是否能到达
    /// 另一个给定的顶点
    /// </summary>
    public class TransitiveClosure
    {
        private DepthFirstSearch[] searchs;

        public TransitiveClosure(IDirectedGraph graph)
        {
            searchs = new DepthFirstSearch[graph.VertexCount];

            // 对于每个顶点，都用深度优先搜索算法来计算该顶点可以到达的所有顶点
            for (int v = 0; v < graph.VertexCount; v++)
            {
                searchs[v] = new DepthFirstSearch(graph, v);
            }
        }

        /// <summary>
        /// 判断从给定顶点是否可以到达目标顶点
        /// </summary>
        /// <param name="from">起始顶点</param>
        /// <param name="to">目标顶点</param>
        public bool IsReachable(int from, int to)
        {
            return searchs[from].IsConnectedTo(to);
        }
    }
}
