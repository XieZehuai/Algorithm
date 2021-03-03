using System;
using System.Collections.Generic;

namespace _4_Graph.GraphSearchAlgorithm
{
    public class BFSPathSearch : IGraphPathSearch
    {
        private bool[] isConnected;
        private int[] edgeTo;
        private readonly int start;

        public string Name => "广度优先搜索图寻路算法";

        public BFSPathSearch(IGraph graph, int start)
        {
            isConnected = new bool[graph.VertexCount];
            edgeTo = new int[graph.VertexCount];
            this.start = start;

            BFS(graph, start);
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

        private void BFS(IGraph graph, int start)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            isConnected[start] = true;

            while (queue.Count > 0)
            {
                int vertex = queue.Dequeue();

                foreach (var v in graph.Adjacent(vertex))
                {
                    if (!isConnected[v])
                    {
                        edgeTo[v] = vertex;
                        queue.Enqueue(v);
                        isConnected[v] = true;
                    }
                }
            }
        }
    }
}
