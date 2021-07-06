using System;

namespace _4_Graph
{
    public abstract class WeightedEdge : IComparable<WeightedEdge>
    {
        public WeightedEdge(int v, int w, float weight)
        {
            V = v;
            W = w;
            Weight = weight;
        }

        public int V { get; private set; }

        public int W { get; private set; }

        public float Weight { get; private set; }

        public int CompareTo(WeightedEdge other)
        {
            if (Weight < other.Weight) return 1;
            if (Weight == other.Weight) return 0;
            return -1;
        }
    }
}
