using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace _4_Graph.ShortestPath
{
    public abstract class SP
    {
        protected DirectedEdge[] edgeTo;
        protected float[] distanceTo;
        protected int start;

        protected SP(EdgeWeightedDigraph digraph, int start)
        {
            this.start = start;
            edgeTo = new DirectedEdge[digraph.VertexCount];
            distanceTo = new float[digraph.VertexCount];

            for (int v = 0; v < digraph.VertexCount; v++)
            {
                distanceTo[v] = float.MaxValue;
            }
            distanceTo[start] = 0f;
        }

        /// <summary>
        /// 获取从起点到目标点的距离，如果不存在路径则距离为无穷大
        /// </summary>
        /// <param name="vertex">目标点</param>
        public float DistanceTo(int vertex)
        {
            return distanceTo[vertex];
        }

        /// <summary>
        /// 判断是否存在从起点到目标点的路径
        /// </summary>
        /// <param name="vertex">目标点</param>
        public bool HasPathTo(int vertex)
        {
            return distanceTo[vertex] < float.MaxValue;
        }

        /// <summary>
        /// 从顶点到目标点的路径
        /// </summary>
        /// <param name="vertex">目标点</param>
        public IEnumerable<DirectedEdge> PathTo(int vertex)
        {
            if (!HasPathTo(vertex)) return Enumerable.Empty<DirectedEdge>();

            Stack<DirectedEdge> path = new Stack<DirectedEdge>();
            for (DirectedEdge edge = edgeTo[vertex]; edge != null; edge = edgeTo[edge.V])
            {
                path.Push(edge);
            }

            return path;
        }

        protected virtual void Relax(DirectedEdge edge)
        {
            int v = edge.V;
            int w = edge.W;
            if (distanceTo[w] > distanceTo[v] + edge.Weight)
            {
                distanceTo[w] = distanceTo[v] + edge.Weight;
                edgeTo[w] = edge;
            }
        }

        protected virtual void Relax(EdgeWeightedDigraph digraph, int vertex)
        {
            foreach (var edge in digraph.Adjacent(vertex))
            {
                int w = edge.W;
                if (distanceTo[w] > distanceTo[vertex] + edge.Weight)
                {
                    distanceTo[w] = distanceTo[vertex] + edge.Weight;
                    edgeTo[w] = edge;
                }
            }
        }
    }
}