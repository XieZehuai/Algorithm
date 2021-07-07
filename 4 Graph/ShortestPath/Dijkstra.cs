using System;
using _2_Sort.PriorityQueue;

namespace _4_Graph.ShortestPath
{
    public class Dijkstra : SP
    {
        private IndexPriorityQueue<float> priorityQueue;

        public Dijkstra(EdgeWeightedDigraph digraph, int start) : base(digraph, start)
        {
            priorityQueue = new IndexPriorityQueue<float>(digraph.VertexCount);
            FindPath(digraph, start);
        }

        private void FindPath(EdgeWeightedDigraph digraph, int start)
        {
            priorityQueue.Insert(start, 0f);

            while (!priorityQueue.IsEmpty)
            {
                Relax(digraph, priorityQueue.DeleteMax());
            }
        }

        protected override void Relax(EdgeWeightedDigraph digraph, int vertex)
        {
            foreach (var edge in digraph.Adjacent(vertex))
            {
                int w = edge.W;
                if (distanceTo[w] > distanceTo[vertex] + edge.Weight)
                {
                    distanceTo[w] = distanceTo[vertex] + edge.Weight;
                    edgeTo[w] = edge;

                    if (priorityQueue.Contains(w))
                    {
                        priorityQueue.Change(w, distanceTo[w]);
                    }
                    else
                    {
                        priorityQueue.Insert(w, distanceTo[w]);
                    }
                }
            }
        }
    }
}
