using System;
using System.Linq;

namespace _4_Graph
{
    /// <summary>
    /// 图工具类，包含一些图的常用方法
    /// </summary>
    public static class GraphUtil
    {
        /// <summary>
        /// 计算图中某个顶点的度数
        /// </summary>
        /// <param name="vertex">要计算度数的顶点</param>
        /// <returns>顶点的度数</returns>
        public static int Degree(this IDirectedGraph graph, int vertex)
        {
            return graph.Adjacent(vertex).Count();
        }

        /// <summary>
        /// 计算图所有顶点中的最大度数
        /// </summary>
        /// <returns>图中度数最大的顶点的度数</returns>
        public static int MaxDegree(this IDirectedGraph graph)
        {
            int max = 0;

            for (int vertex = 0; vertex < graph.VertexCount; vertex++)
            {
                int cnt = graph.Degree(vertex);
                if (cnt > max)
                {
                    max = cnt;
                }
            }

            return max;
        }

        /// <summary>
        /// 计算图中所有顶点的平均度数
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static float AvergeDegree(this IDirectedGraph graph)
        {
            // 因为每条边两者两个顶点，所以每天条对应两度，所有边的度数除以顶点数就是平均度数
            return graph.EdgeCount * 2f / graph.VertexCount;
        }

        /// <summary>
        /// 计算图中自环的个数（自环就是变连线自己形成的环）
        /// </summary>
        /// <returns>自环的个数</returns>
        public static int SelfLoopCount(this IDirectedGraph graph)
        {
            int cnt = 0;

            for (int vertex = 0; vertex < graph.VertexCount; vertex++)
            {
                cnt += graph.Adjacent(vertex).Count(v => v == vertex);
            }

            return cnt / 2; // 每条边都会被计算两次，所以要除以2
        }

        /// <summary>
        /// 在控制台打印出图的顶点以及边的信息
        /// </summary>
        public static void Print(this IDirectedGraph graph)
        {
            Console.WriteLine("打印图");
            Console.WriteLine(graph.VertexCount + "个顶点  " + graph.EdgeCount + "条边");
            
            for (int i = 0; i < graph.EdgeCount; i++)
            {
                Console.Write(i + ": ");
                
                foreach (var vertex in graph.Adjacent(i))
                {
                    Console.Write(vertex + " ");
                }

                Console.WriteLine();
            }
        }
    }
}