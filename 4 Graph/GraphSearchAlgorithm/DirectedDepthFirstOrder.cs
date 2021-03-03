using System.Collections.Generic;

namespace _4_Graph.GraphSearchAlgorithm
{
    /// <summary>
    /// 有向图中基于深度优先搜索的顶点排序算法
    /// </summary>
    public class DirectedDepthFirstOrder
    {
        private bool[] isConnected;
        private Queue<int> pre; // 所有顶点的前序排列（在递归前将顶点加入队列）
        private Queue<int> post; // 所有顶点的后序排列（在递归后将顶点加入队列）
        private Stack<int> reversePost; // 所有顶点的逆后序排列（在递归调用后将顶点压入栈）

        public DirectedDepthFirstOrder(IDirectedGraph graph)
        {
            pre = new Queue<int>();
            post = new Queue<int>();
            reversePost = new Stack<int>();
            isConnected = new bool[graph.VertexCount];

            for (int v = 0; v < graph.VertexCount; v++)
            {
                if (!isConnected[v])
                {
                    DFS(graph, v);
                }
            }
        }

        /// <summary>
        /// 顶点的前序排列
        /// </summary>
        public IEnumerable<int> PreOrder()
        {
            return pre;
        }

        /// <summary>
        /// 顶点的后序排列
        /// </summary>
        public IEnumerable<int> PostOrder()
        {
            return post;
        }

        /// <summary>
        /// 顶点的逆后序排列
        /// </summary>
        public IEnumerable<int> ReversePostOrder()
        {
            return reversePost;
        }

        private void DFS(IDirectedGraph graph, int vertex)
        {
            pre.Enqueue(vertex);
            isConnected[vertex] = true;

            foreach (int v in graph.Adjacent(vertex))
            {
                if (!isConnected[v])
                {
                    DFS(graph, v);
                }
            }

            post.Enqueue(vertex);
            reversePost.Push(vertex);
        }
    }
}
