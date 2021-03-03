using _1_Basics;

namespace _4_Graph.GraphSearchAlgorithm
{
    /// <summary>
    /// 使用并查集实现的图搜索算法
    /// </summary>
    public class UnionFindSearch : IGraphSearch
    {
        private readonly UnionFind uf;
        private readonly int vertexCount;
        private readonly int start;

        public string Name => "并查集图搜索算法";

        public UnionFindSearch(IGraph graph, int vertex)
        {
            vertexCount = graph.VertexCount;
            uf = new UnionFind(vertexCount);
            start = vertex;

            for (int from = 0; from < vertexCount; from++)
            {
                foreach (int to in graph.Adjacent(from))
                {
                    uf.Union(from, to);
                }
            }
        }

        public bool IsConnectedTo(int target)
        {
            return uf.IsConnected(start, target);
        }

        public int Count()
        {
            int cnt = 0;

            for (int to = 0; to < vertexCount; to++)
            {
                if (IsConnectedTo(to))
                {
                    cnt++;
                }
            }

            return cnt;
        }
    }
}
