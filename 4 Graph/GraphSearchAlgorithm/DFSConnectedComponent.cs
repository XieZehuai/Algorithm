namespace _4_Graph.GraphSearchAlgorithm
{
    /// <summary>
    /// 基于深度优先搜索的图连通分量计算算法（连通分量就是独立子图的意思）
    /// </summary>
    public class DFSConnectedComponent : IGraphConnectedComponent
    {
        private bool[] isConnected;
        private int[] id; // 保存所有顶点对应的连通分量的ID
        private int count; // 连通分量的数量

        public string Name => "深度优先搜索连通分量算法";

        public DFSConnectedComponent(IGraph graph)
        {
            isConnected = new bool[graph.VertexCount];
            id = new int[graph.VertexCount];

            // 遍历所有顶点，在遍历的同时用深度优先搜索找出所有与当前顶点
            // 连通的顶点，所以如果处理后还遇到没有被标记的顶点，就说明该
            // 顶点与前面处理过的所有顶点都不连通，是一个新的连通分量
            for (int i = 0; i < graph.VertexCount; i++)
            {
                if (!isConnected[i])
                {
                    DFS(graph, i);
                    count++;
                }
            }
        }

        public bool IsConnected(int v, int w)
        {
            return id[v] == id[w];
        }

        public int Id(int v)
        {
            return id[v];
        }

        public int Count()
        {
            return count;
        }

        private void DFS(IGraph graph, int vertex)
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
