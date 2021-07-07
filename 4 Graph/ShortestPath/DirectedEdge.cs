namespace _4_Graph.ShortestPath
{
    /// <summary>
    /// 带权重的有向边
    /// </summary>
    public class DirectedEdge : WeightedEdge
    {
        public DirectedEdge(int v, int w, float weight) : base(v, w, weight)
        {
        }

        public override string ToString()
        {
            return $"\t{V}->{W} ({Weight})";
        }
    }
}
