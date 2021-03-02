using _4_Graph.Common;

namespace _4_Graph.GraphSearchAlgorithm
{
    /// <summary>
    /// 基于深度优先搜索的图搜索算法
    /// </summary>
    public class DepthFirstSearch : IGraphSearch
    {
        private bool[] isConnected;
        private int count;

        public string Name => "深度优先搜索图搜索算法";

        public DepthFirstSearch(IGraph graph, int vertex)
        {
            isConnected = new bool[graph.VertexCount];
            DFS(graph, vertex);
        }

        public bool IsConnectedTo(int target)
        {
            return isConnected[target];
        }

        public int Count()
        {
            return count;
        }

        private void DFS(IGraph graph, int vertex)
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
