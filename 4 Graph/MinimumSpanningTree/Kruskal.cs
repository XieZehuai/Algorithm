using System;
using System.Collections.Generic;
using _1_Basics;
using _2_Sort.PriorityQueue;

namespace _4_Graph.MinimumSpanningTree
{
    public class Kruskal : MST
    {
        private Queue<UndirectedEdge> mst;

        public Kruskal(EdgeWeightedGraph graph) : base(graph)
        {
            mst = new Queue<UndirectedEdge>();
            IPriorityQueue<UndirectedEdge> priorityQueue = new HeapPriorityQueue<UndirectedEdge>(graph.Edges());
            UnionFind unionFind = new UnionFind(graph.VertexCount);

            while (!priorityQueue.IsEmpty && mst.Count < graph.VertexCount - 1)
            {
                UndirectedEdge edge = priorityQueue.DeleteMax();
                if (unionFind.IsConnected(edge.V, edge.W))
                {
                    continue;
                }

                unionFind.Union(edge.V, edge.W);
                mst.Enqueue(edge);
            }
        }

        public override float Weight => throw new NotImplementedException();

        public override IEnumerable<UndirectedEdge> Edges()
        {
            throw new NotImplementedException();
        }
    }
}
