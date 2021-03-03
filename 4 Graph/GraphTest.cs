using System;
using System.Collections.Generic;
using _4_Graph.GraphSearchAlgorithm;

namespace _4_Graph
{
    public class GraphTest
    {
        private static readonly int vertexCount = 13;
        private static readonly int[,] edges = new int[14, 2]
        {
            { 0, 5 },
            { 4, 3 },
            { 0, 1 },
            { 9, 12 },
            { 6, 4 },
            { 5, 4 },
            { 0, 2 },
            { 11, 12 },
            { 9, 10 },
            { 0, 6 },
            { 7, 8 },
            { 9, 11 },
            { 5, 3 },
            { 3, 0 },
        };

        public static void Test()
        {
            int target = int.Parse(Console.ReadLine()); // 输入目标顶点
            IGraph graph = CreateDirectedGraph(); // 生成图数据

            DirectedDepthFirstOrder search = new DirectedDepthFirstOrder(CreateDirectedGraph());

            Console.WriteLine("前序排列");
            foreach (var i in search.PreOrder())
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.WriteLine("后序排列");
            foreach (var i in search.PostOrder())
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();


            Console.WriteLine("逆后序排列");
            foreach (var i in search.ReversePostOrder())
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            //GraphSearchTest(new UnionFindSearch(graph, target));
            //GraphSearchTest(new DepthFirstSearch(graph, target));

            //GraphPathSearchTest(new DFSPathSearch(graph, target), target);
            //GraphPathSearchTest(new BFSPathSearch(graph, target), target);

            //GraphConnectedComponentTest(new DFSConnectedComponent(graph));
        }

        #region 图搜索算法测试
        private static void GraphSearchTest(IGraphSearch search)
        {
            Console.WriteLine(search.Name);

            // 打印所有与目标顶点连通的顶点
            for (int i = 0; i < vertexCount; i++)
            {
                if (search.IsConnectedTo(i))
                {
                    Console.Write(i + " ");
                }
            }

            Console.WriteLine();
            Console.WriteLine(search.Count());
        }
        #endregion

        #region 图路径搜索算法测试
        private static void GraphPathSearchTest(IGraphPathSearch search, int start)
        {
            Console.WriteLine(search.Name);

            // 打印图中所有顶点到start的路径
            for (int i = 0; i < vertexCount; i++)
            {
                Console.Write(start + " to " + i + " : ");

                if (search.HasPathTo(i))
                {
                    foreach (var v in search.PathTo(i))
                    {
                        if (start == v) Console.Write(v);
                        else Console.Write(" -> " + v);
                    }
                }
                else
                {
                    Console.Write("No path");
                }

                Console.WriteLine();
            }
        }
        #endregion

        #region 图连通分量测试
        private static void GraphConnectedComponentTest(IGraphConnectedComponent search)
        {
            Console.WriteLine(search.Name);

            int count = search.Count();
            Console.WriteLine(count + "个连通分量");

            List<int>[] components = new List<int>[count];
            for (int i = 0; i < count; i++)
            {
                components[i] = new List<int>();
            }

            for (int v = 0; v < vertexCount; v++)
            {
                components[search.Id(v)].Add(v);
            }

            for (int i = 0; i < count; i++)
            {
                foreach (var v in components[i])
                {
                    Console.Write(v + " ");
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region 生成图数据
        private static IGraph CreateGraph()
        {
            return new UndirectedGraph(vertexCount, edges);
        }

        private static IDirectedGraph CreateDirectedGraph()
        {
            return new DirectedGraph(vertexCount, edges);
        }
        #endregion
    }
}