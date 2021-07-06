using System;

namespace _4_Graph.MinimumSpanningTree
{
    /// <summary>
    /// 带权重的无向边
    /// </summary>
    public class UndirectedEdge : WeightedEdge
    {
        public UndirectedEdge(int v, int w, float weight) : base(v, w, weight)
        {
        }

        /// <summary>
        /// 根据顶点获取另一个顶点
        /// </summary>
        /// <param name="vertex">边的某个顶点</param>
        /// <returns>边的另一个顶点</returns>
        public int Other(int vertex)
        {
            if (vertex == V)
            {
                return W;
            }
            else if (vertex == W)
            {
                return V;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"顶点{vertex}不属于当前边");
            }
        }

        public override string ToString()
        {
            return $"{V} - {W}  {Weight}";
        }
    }
}
