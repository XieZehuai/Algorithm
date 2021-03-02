using System.Collections.Generic;
using _4_Graph.Common;

namespace _4_Graph.GraphSearchAlgorithm
{
    /// <summary>
    /// 基于深度优先搜索的图路径搜索算法
    /// </summary>
    public class DFSPathSearch : IGraphPathSearch
    {
        private bool[] isConnected;
        private int[] edgeTo;
        private readonly int start; // 起始顶点

        public string Name => "深度优先搜索图寻路算法";

        public DFSPathSearch(IGraph graph, int start)
        {
            isConnected = new bool[graph.VertexCount];
            edgeTo = new int[graph.VertexCount];
            this.start = start;

            DFS(graph, start);
        }

        public bool HasPathTo(int target)
        {
            return isConnected[target];
        }

        public IEnumerable<int> PathTo(int target)
        {
            Stack<int> path = new Stack<int>();
            if (!HasPathTo(target)) return path;

            while (target != start)
            {
                path.Push(target);
                target = edgeTo[target];
            }

            path.Push(start);

            return path;
        }

        private void DFS(IGraph graph, int vertex)
        {
            isConnected[vertex] = true;

            foreach (var v in graph.Adjacent(vertex))
            {
                if (!isConnected[v])
                {
                    edgeTo[v] = vertex;
                    DFS(graph, v);
                }
            }
        }
    }
}
