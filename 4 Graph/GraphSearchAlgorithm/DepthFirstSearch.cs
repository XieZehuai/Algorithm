namespace _4_Graph.GraphSearchAlgorithm
{
    /// <summary>
    /// 基于深度优先搜索的图搜索算法
    /// </summary>
    public class DepthFirstSearch : IGraphSearch
    {
        protected bool[] isConnected;
        protected int count;

        public virtual string Name => "深度优先搜索";

        public DepthFirstSearch()
        {
        }

        public DepthFirstSearch(IGraph graph, int vertex)
        {
            isConnected = new bool[graph.VertexCount];
            DFS(graph, vertex);
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
