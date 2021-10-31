using System.Collections.Generic;

namespace _4_Graph.GraphSearchAlgorithm
{
    /// <summary>
    /// 基于深度优先搜索的图搜索算法，用于寻找目标图中给定节点所有可达的节点
    /// </summary>
    public class DepthFirstSearch : IGraphSearch
    {
        protected bool[] isConnected;
        protected int count;

        public virtual string Name => "深度优先搜索";

        public DepthFirstSearch(IGraph graph, int vertex)
        {
            isConnected = new bool[graph.VertexCount];
            DFS(graph, vertex);
        }

        public DepthFirstSearch(IGraph graph, IEnumerable<int> vertices)
        {
            isConnected = new bool[graph.VertexCount];
            foreach (var v in vertices)
            {
                if (!isConnected[v])
                {
                    DFS(graph, v);
                }
            }
        }

        public virtual bool IsConnectedTo(int target)
        {
            return isConnected[target];
        }

        public virtual int Count()
        {
            return count;
        }

        protected virtual void DFS(IGraph graph, int vertex)
        {
            isConnected[vertex] = true;
            count++;

            foreach (var v in graph.Adjacent(vertex))
            {
                if (!isConnected[v])
                {
                    DFS(graph, v);
                }
            }
        }
    }
}
