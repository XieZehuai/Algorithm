using System.Collections.Generic;
using System.Linq;

namespace _4_Graph
{
    public class DirectedGraph : UndirectedGraph, IDirectedGraph
    {
        public DirectedGraph(int vertexCount) : base(vertexCount)
        {
        }

        public DirectedGraph(int vertexCount, int[,] edges) : base(vertexCount, edges)
        {
        }

        public override void AddEdge(int from, int to)
        {
            Edge edge = new Edge(to) { next = edges[from] };
            edges[from] = edge;

            edgeCount++;
        }

        public override IEnumerable<int> Adjacent(int vertex)
        {
            if (edges[vertex] == null)
            {
                return Enumerable.Empty<int>();
            }

            return edges[vertex];
        }

        public virtual IDirectedGraph Reverse()
        {
            DirectedGraph graph = new DirectedGraph(vertexCount);

            for (int from = 0; from < vertexCount; from++)
            {
                foreach (int to in Adjacent(from))
                {
                    graph.AddEdge(to, from);
                }
            }

            return graph;
        }
    }
}
