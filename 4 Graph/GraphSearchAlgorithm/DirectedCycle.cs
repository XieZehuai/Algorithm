using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Graph.GraphSearchAlgorithm
{
    /// <summary>
    /// 有向图中的有向环搜索算法
    /// </summary>
    public class DirectedCycle
    {
        protected bool[] isConnected;
        protected int[] edgeTo;
        protected Stack<int> cycle; // 保存有向环中的所有顶点（如果存在）
        protected bool[] onStack; // 递归调用栈上的所有顶点

        public DirectedCycle(IDirectedGraph graph)
        {
            int vertexCount = graph.VertexCount;

            isConnected = new bool[vertexCount];
            edgeTo = new int[vertexCount];
            onStack = new bool[vertexCount];

            for (int v = 0; v < vertexCount; v++)
            {
                if (!isConnected[v])
                {
                    DFS(graph, v);
                }
            }
        }

        public bool HasCycle()
        {
            return cycle != null;
        }

        public IEnumerable<int> GetCycle()
        {
            return cycle;
        }

        private void DFS(IDirectedGraph graph, int vertex)
        {
            onStack[vertex] = true;
            isConnected[vertex] = true;

            foreach (int v in graph.Adjacent(vertex))
            {
                if (HasCycle()) return;

                if (!isConnected[v])
                {
                    edgeTo[v] = vertex;
                    DFS(graph, v);
                }
                // 如果当前相邻顶点被标记过，并且在递归调用栈上，说明路径又回到了之前的顶点，也就是出现环路
                else if (onStack[v])
                {
                    cycle = new Stack<int>();

                    // 把路径上的所有顶点记录下来
                    for (int i = vertex; i != v; i = edgeTo[i])
                    {
                        cycle.Push(i);
                    }

                    cycle.Push(v);
                    cycle.Push(vertex);
                }
            }

            onStack[vertex] = false;
        }
    }
}
