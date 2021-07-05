using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_Basics;
using _2_Sort.PriorityQueue;

namespace _4_Graph.MinimumSpanningTree
{
    public class Kruskal : MST
    {
        private Queue<Edge> mst;

        public Kruskal(EdgeWeightedGraph graph) : base(graph)
        {
            mst = new Queue<Edge>();
            PriorityQueue<Edge> priorityQueue = new HeapPriorityQueue<Edge>(graph.Edges());
            UnionFind unionFind = new UnionFind(graph.VertexCount);

            while (!priorityQueue.IsEmpty && mst.Count < graph.VertexCount - 1)
            {
                Edge edge = priorityQueue.DeleteMax();
                if (unionFind.IsConnected(edge.V, edge.W))
                {
                    continue;
                }

                unionFind.Union(edge.V, edge.W);
                mst.Enqueue(edge);
            }
        }

        public override float Weight => throw new NotImplementedException();

        public override IEnumerable<Edge> Edges()
        {
            throw new NotImplementedException();
        }
    }
}
