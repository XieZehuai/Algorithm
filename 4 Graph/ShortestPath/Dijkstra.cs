using System;

namespace _4_Graph.ShortestPath
{
    public class Dijkstra : SP
    {
        public Dijkstra(EdgeWeightedDigraph digraph, int start) : base(digraph, start)
        {
        }

        protected override void FindPath(EdgeWeightedDigraph digraph, int start)
        {
            throw new NotImplementedException();
        }
    }
}
