using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Graph.MinimumSpanningTree
{
    /// <summary>
    /// 带权重的无向边
    /// </summary>
    public class Edge : IComparable<Edge>
    {
        private readonly int v; // 第一个顶点
        private readonly int w; // 第二个顶点
        private readonly float weight; // 权重

        public Edge(int v, int w, float weight)
        {
            this.v = v;
            this.w = w;
            this.weight = weight;
        }

        /// <summary>
        /// 权重
        /// </summary>
        public float Weight => weight;

        /// <summary>
        /// 第一个顶点
        /// </summary>
        public int V => v;

        /// <summary>
        /// 第二个顶点
        /// </summary>
        public int W => w;

        /// <summary>
        /// 根据顶点获取另一个顶点
        /// </summary>
        /// <param name="vertex">边的某个顶点</param>
        /// <returns>边的另一个顶点</returns>
        public int Other(int vertex)
        {
            if (vertex == v)
            {
                return w;
            }
            else if (vertex == w)
            {
                return v;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"顶点{vertex}不属于当前边");
            }
        }

        public int CompareTo(Edge other)
        {
            if (weight > other.weight)
            {
                return -1;
            }
            else if (weight == other.weight)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public override string ToString()
        {
            return $"{v} - {w}  {weight}";
        }
    }
}
