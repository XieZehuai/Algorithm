using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Graph.MinimumSpanningTree
{
    public static class Test
    {
        public static void Invoke()
        {
            EdgeWeightedGraph graph = CreateGraph();

            //foreach (var edge in graph.Edges())
            //{
            //    Console.WriteLine(edge);
            //}
            //Console.WriteLine();

            MST mst = new Kruskal(graph);
            foreach (var edge in mst.Edges())
            {
                Console.WriteLine(edge);
            }
            Console.WriteLine("权重：" + mst.Weight);
        }

        private static EdgeWeightedGraph CreateGraph()
        {
            EdgeWeightedGraph graph = new EdgeWeightedGraph(8);

            graph.AddEdge(new UndirectedEdge(4, 5, 35f));
            graph.AddEdge(new UndirectedEdge(4, 7, 37f));
            graph.AddEdge(new UndirectedEdge(5, 7, 28f));
            graph.AddEdge(new UndirectedEdge(0, 7, 16f));
            graph.AddEdge(new UndirectedEdge(1, 5, 32f));
            graph.AddEdge(new UndirectedEdge(0, 4, 38f));
            graph.AddEdge(new UndirectedEdge(2, 3, 17f));
            graph.AddEdge(new UndirectedEdge(1, 7, 19f));
            graph.AddEdge(new UndirectedEdge(0, 2, 26f));
            graph.AddEdge(new UndirectedEdge(1, 2, 36f));
            graph.AddEdge(new UndirectedEdge(1, 3, 29f));
            graph.AddEdge(new UndirectedEdge(2, 7, 34f));
            graph.AddEdge(new UndirectedEdge(6, 2, 40f));
            graph.AddEdge(new UndirectedEdge(3, 6, 52f));
            graph.AddEdge(new UndirectedEdge(6, 0, 58f));
            graph.AddEdge(new UndirectedEdge(6, 4, 93f));

            return graph;
        }
    }
}
