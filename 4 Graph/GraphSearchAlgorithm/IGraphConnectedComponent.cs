namespace _4_Graph.GraphSearchAlgorithm
{
    public interface IGraphConnectedComponent
    {
        string Name { get; }

        bool IsConnected(int v, int w);

        int Id(int v);

        int Count();
    }
}
