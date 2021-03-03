using System;
using System.Collections;
using System.Collections.Generic;

namespace _4_Graph
{
    /// <summary>
    /// 无向图
    /// </summary>
    public class UndirectedGraph : IGraph
    {
        #region 用于在图中表示边的数据结构
        /// <summary>
        /// 用于在图中表示边的数据结构
        /// </summary>
        protected class Edge : IEnumerable<int>, IEnumerator<int>
        {
            public readonly int vertex;
            public Edge next;

            private Edge current = null;

            public Edge(int vertex)
            {
                this.vertex = vertex;
                next = null;
            }

            public int Current => current.vertex;

            object IEnumerator.Current => Current;

            public IEnumerator<int> GetEnumerator()
            {
                return this;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public bool MoveNext()
            {
                current = current == null ? this : current.next;

                return current != null;
            }

            public void Reset()
            {
                current = null;
            }

            public void Dispose()
            {
            }
        }
        #endregion

        protected readonly int vertexCount;
        protected int edgeCount;
        protected readonly Edge[] edges;

        public UndirectedGraph(int vertexCount)
        {
            this.vertexCount = vertexCount;
            edges = new Edge[vertexCount];
            edgeCount = 0;
        }

        public UndirectedGraph(int vertexCount, int[,] edges)
        {
            this.vertexCount = vertexCount;
            this.edges = new Edge[vertexCount];

            for (int i = 0; i < edges.GetLength(0); i++)
            {
                AddEdge(edges[i, 0], edges[i, 1]);
            }
        }

        public virtual int VertexCount => vertexCount;

        public virtual int EdgeCount => edgeCount;

        public virtual void AddEdge(int from, int to)
        {
            Edge edge = new Edge(to) { next = edges[from] };
            edges[from] = edge;

            edge = new Edge(from) { next = edges[to] };
            edges[to] = edge;

            edgeCount++;
        }

        public virtual IEnumerable<int> Adjacent(int vertex)
        {
            return edges[vertex];
        }
    }
}