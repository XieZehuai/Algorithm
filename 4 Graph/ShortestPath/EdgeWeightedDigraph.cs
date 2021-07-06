using System.Collections.Generic;
using System.Text;

using _1_Basics;

namespace _4_Graph.ShortestPath
{
    /// <summary>
    /// 加权有向图
    /// </summary>
    public class EdgeWeightedDigraph
    {
        private int vertexCount;
        private int edgeCount;
        private Bag<DirectedEdge>[] adjacents;

        public EdgeWeightedDigraph(int vertexCount)
        {
            this.vertexCount = vertexCount;
            edgeCount = 0;
            adjacents = new Bag<DirectedEdge>[vertexCount];

            for (int i = 0; i < vertexCount; i++)
            {
                adjacents[i] = new Bag<DirectedEdge>();
            }
        }

        public int VertexCount => vertexCount;

        public int EdgeCount => edgeCount;

        public void AddEdge(int v, int w, float weight)
        {
            DirectedEdge edge = new DirectedEdge(v, w, weight);
            AddEdge(edge);
        }
        
        public void AddEdge(DirectedEdge edge)
        {
            adjacents[edge.V].Add(edge);
            edgeCount++;
        }

        public IEnumerable<DirectedEdge> Adjacent(int vertex)
        {
            return adjacents[vertex];
        }

        public IEnumerable<DirectedEdge> Edges()
        {
            Bag<DirectedEdge> bag = new Bag<DirectedEdge>();
            for (int v = 0; v < VertexCount; v++)
            {
                foreach (var edge in adjacents[v])
                {
                    bag.Add(edge);
                }
            }

            return bag;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (var edge in Edges())
            {
                sb.AppendLine(edge.ToString());
            }

            return sb.ToString();
        }
    }
}
