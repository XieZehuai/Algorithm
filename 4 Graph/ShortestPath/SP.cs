using System.Collections.Generic;


namespace _4_Graph.ShortestPath
{
    public abstract class SP
    {
        public SP(EdgeWeightedDigraph digraph, int s)
        {
            
        }

        /// <summary>
        /// 获取从起点到目标点的距离，如果不存在路径则距离为无穷大
        /// </summary>
        /// <param name="vertex">目标点</param>
        public abstract float DistanceTo(int vertex);

        /// <summary>
        /// 判断是否存在从起点到目标点的路径
        /// </summary>
        /// <param name="vertex">目标点</param>
        public abstract bool HasPathTo(int vertex);

        /// <summary>
        /// 从顶点到目标点的路径
        /// </summary>
        /// <param name="vertex">目标点</param>
        public abstract IEnumerable<DirectedEdge> PathTo(int vertex);
    }
}