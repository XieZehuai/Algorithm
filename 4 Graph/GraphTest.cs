using System;
using System.Collections.Generic;
using _4_Graph.Common;
using _4_Graph.GraphSearchAlgorithm;

namespace _4_Graph
{
    public class GraphTest
    {
        public static void Test()
        {
            int target = int.Parse(Console.ReadLine()); // 输入目标顶点
            IGraph graph = CreateGraph(); // 生成图数据
            int vertexCount = graph.VertexCount;

            //GraphSearchTest(new UnionFindSearch(graph, target), vertexCount);
            //GraphSearchTest(new DepthFirstSearch(graph, target), vertexCount);

            //GraphPathSearchTest(new DFSPathSearch(graph, target), target, vertexCount);
            //GraphPathSearchTest(new BFSPathSearch(graph, target), target, vertexCount);

            GraphConnectedComponentTest(new DFSConnectedComponent(graph), vertexCount);
        }

        #region 图搜索算法测试
        private static void GraphSearchTest(IGraphSearch search, int vertexCount)
        {
            Console.WriteLine(search.Name);

            // 打印所有与目标顶点相邻的顶点
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
        private static void GraphPathSearchTest(IGraphPathSearch search, int start, int vertexCount)
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
                        else Console.Write("->" + v);
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
        private static void GraphConnectedComponentTest(IGraphConnectedComponent search, int vertexCount)
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
            int[,] edges = new int[13, 2]
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
            };

            return new UndirectedGraph(13, edges);
        }
        #endregion
    }
}