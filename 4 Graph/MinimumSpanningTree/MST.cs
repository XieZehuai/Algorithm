using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Graph.MinimumSpanningTree
{
    /// <summary>
    /// 最小生成树算法，用给定的无向加权图生成最小生成树
    /// </summary>
    public abstract class MST
    {
        protected EdgeWeightedGraph graph;

        /// <summary>
        /// 构造函数，指定用于生成最小生成树的图
        /// </summary>
        /// <param name="graph"></param>
        public MST(EdgeWeightedGraph graph)
        {
            this.graph = graph;
        }

        /// <summary>
        /// 最小生成树的权重
        /// </summary>
        public abstract float Weight { get; }

        /// <summary>
        /// 最小生成树的所有边
        /// </summary>
        public abstract IEnumerable<UndirectedEdge> Edges();
    }
}
