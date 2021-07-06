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
        private Bag<UndirectedEdge>[] adjacents;

        /// <summary>
        /// 创建一个含有v个顶点的空图
        /// </summary>
        /// <param name="vertexCount">顶点的数量</param>
        public EdgeWeightedGraph(int vertexCount)
        {
            this.vertexCount = vertexCount;
            edgeCount = 0;
            adjacents = new Bag<UndirectedEdge>[vertexCount];

            for (int v = 0; v < vertexCount; v++)
            {
                adjacents[v] = new Bag<UndirectedEdge>();
            }
        }

        public int VertexCount => vertexCount;

        public int EdgeCount => edgeCount;

        public void AddEdge(UndirectedEdge edge)
        {
            adjacents[edge.V].Add(edge);
            adjacents[edge.W].Add(edge);
            edgeCount++;
        }

        public IEnumerable<UndirectedEdge> Adjacents(int vertex)
        {
            return adjacents[vertex];
        }

        public IEnumerable<UndirectedEdge> Edges()
        {
            Bag<UndirectedEdge> bag = new Bag<UndirectedEdge>();

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
