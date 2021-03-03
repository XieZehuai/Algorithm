namespace _4_Graph.GraphSearchAlgorithm
{
    /// <summary>
    /// Kosaraju算法，用于计算有向图中的强连通分量，算法基本与
    /// 无向图的连通分量算法相同，只是在遍历节点时不是图的默认
    /// 顶点顺序遍历，而是按有向图的反向图的逆后序排序顺序遍历
    /// </summary>
    public class KosarajuSCC
    {
        private bool[] isConnected;
        private int[] id;
        private int count;

        public KosarajuSCC(IDirectedGraph graph)
        {
            isConnected = new bool[graph.VertexCount];
            id = new int[graph.VertexCount];

            DirectedDepthFirstOrder order = new DirectedDepthFirstOrder(graph.Reverse());
            foreach (var v in order.ReversePostOrder())
            {
                if (!isConnected[v])
                {
                    DFS(graph, v);
                    count++;
                }
            }
        }

        /// <summary>
        /// 判断两个顶点是否强连通
        /// </summary>
        public bool IsStronglyConnected(int v, int w)
        {
            return id[v] == id[w];
        }

        /// <summary>
        /// 获取顶点对应的强连通分量的ID
        /// </summary>
        public int Id(int v)
        {
            return id[v];
        }

        /// <summary>
        /// 获取强连通分量的数量
        /// </summary>
        public int Count()
        {
            return count;
        }

        private void DFS(IDirectedGraph graph, int vertex)
        {
            isConnected[vertex] = true;
            id[vertex] = count;

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
