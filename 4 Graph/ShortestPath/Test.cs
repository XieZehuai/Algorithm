namespace _4_Graph.ShortestPath
{
    public static class Test
    {
        public static void Invoke()
        {
            var digraph = CreateGraph();
        }

        private static EdgeWeightedDigraph CreateGraph()
        {
            EdgeWeightedDigraph digraph = new EdgeWeightedDigraph(8);
            
            digraph.AddEdge(4, 5, 35f);
            digraph.AddEdge(5, 4, 35f);
            digraph.AddEdge(4, 7, 37f);
            digraph.AddEdge(5, 7, 28f);
            digraph.AddEdge(7, 5, 28f);
            
            digraph.AddEdge(5, 1, 32f);
            digraph.AddEdge(0, 4, 38f);
            digraph.AddEdge(0, 2, 26f);
            digraph.AddEdge(7, 3, 39f);
            digraph.AddEdge(1, 3, 29f);
            
            digraph.AddEdge(2, 7, 34f);
            digraph.AddEdge(6, 2, 40f);
            digraph.AddEdge(3, 6, 52f);
            digraph.AddEdge(6, 0, 58f);
            digraph.AddEdge(6, 4, 93f);

            return digraph;
        }
    }
}