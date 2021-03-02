namespace _1_Basics
{
    /// <summary>
    /// 并查集
    /// </summary>
    public class UnionFind
    {
        private readonly int[] nodes; // 保存所有节点
        private readonly int[] size; // 每个节点对应的集合的大小
        private int count; // 集合的数量

        // 以整数标识初始化N个点（0 - N-1）
        public UnionFind(int n)
        {
            count = n;
            nodes = new int[n];
            size = new int[n];

            for (int i = 0; i < n; i++)
            {
                nodes[i] = i;
                size[i] = 1;
            }
        }

        // 在p和q之间添加一条连接
        public void Union(int p, int q)
        {
            int pRoot = Find(p);
            int qRoot = Find(q);
            if (pRoot == qRoot) return;

            if (size[pRoot] < size[qRoot])
            {
                size[qRoot] += size[pRoot];
                nodes[pRoot] = qRoot;
            }
            else
            {
                size[pRoot] += size[qRoot];
                nodes[qRoot] = pRoot;
            }

            count--;
        }

        // p所在的集合的标识符
        public int Find(int p)
        {
            while (p != nodes[p])
            {
                p = nodes[p];
            }

            return p;
        }

        // 判断p和q是否处于同一个集合中
        public bool IsConnected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        // 获取集合的数量
        public int Count()
        {
            return count;
        }
    }
}
