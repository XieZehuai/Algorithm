using System.Collections.Generic;
using _1_Basics;

namespace _4_Graph.MinimumSpanningTree
{
    /// <summary>
    /// 加权无向图
    /// </summary>
    public class EdgeWeightedGraph
    {
        private readonly int vertexCount;
        private int edgeCount;
        private Bag<Edge>[] adjacents;

        /// <summary>
        /// 创建一个含有v个顶点的空图
        /// </summary>
        /// <param name="v">顶点的数量</param>
        public EdgeWeightedGraph(int vertexCount)
        {
            this.vertexCount = vertexCount;
            edgeCount = 0;
            adjacents = new Bag<Edge>[vertexCount];

            for (int v = 0; v < vertexCount; v++)
            {
                adjacents[v] = new Bag<Edge>();
            }
        }

        public int VertexCount => vertexCount;

        public int EdgeCount => edgeCount;

        public void AddEdge(Edge edge)
        {
            adjacents[edge.V].Add(edge);
            adjacents[edge.W].Add(edge);
            edgeCount++;
        }

        public IEnumerable<Edge> Adjacents(int vertex)
        {
            return adjacents[vertex];
        }

        public IEnumerable<Edge> Edges()
        {
            Bag<Edge> bag = new Bag<Edge>();

            for (int v = 0; v < vertexCount; v++)
            {
                foreach (var edge in adjacents[v])
                {
                    if (edge.Other(v) > v)
                    {
                        bag.Add(edge);
                    }
                }
            }

            return bag;
        }
    }
}
