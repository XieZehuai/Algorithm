using System;

namespace _1_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            UnionFind uf = new UnionFind(n);
            while (n-- > 0)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                int p = int.Parse(inputs[0]);
                int q = int.Parse(inputs[1]);

                if (!uf.IsConnected(p, q))
                {
                    uf.Union(p, q);
                }
            }
        }
    }
}
