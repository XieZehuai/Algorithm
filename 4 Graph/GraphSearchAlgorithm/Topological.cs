using System.Collections.Generic;

namespace _4_Graph.GraphSearchAlgorithm
{
    /// <summary>
    /// 有向图的拓扑排序算法
    /// </summary>
    public class Topological
    {
        private IEnumerable<int> order;

        public Topological(IDirectedGraph graph)
        {
            DirectedCycle cycle = new DirectedCycle(graph);

            // 只有有向无环图才能进行拓扑排序
            if (!cycle.HasCycle())
            {
                DirectedDepthFirstOrder dfs = new DirectedDepthFirstOrder(graph);
                order = dfs.ReversePostOrder();
            }
        }

        public IEnumerable<int> Order()
        {
            return order;
        }

        public bool IsDAG()
        {
            return order != null;
        }
    }
}
