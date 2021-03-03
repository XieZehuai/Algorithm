using _3_Searching.Hash;

namespace _4_Graph
{
    /// <summary>
    /// 符号图，可用任意数据类型作为顶点来构成一幅图
    /// </summary>
    /// <typeparam name="T">顶点的数据类型</typeparam>
    public class SymbolGraph<T>
    {
        private LinearProbingHashSymbolTable<T, int> indexes; // 用一个哈希表来保存顶点到索引的映射
        private T[] keys; // 用一个顶点数据类型的数组来保存索引到顶点的映射
        private IGraph graph;

        public SymbolGraph(T[,] inputs)
        {
            indexes = new LinearProbingHashSymbolTable<T, int>();

            // 构建顶点到索引的映射
            for (int i = 0; i < inputs.GetLength(0); i++)
            {
                for (int j = 0; j < inputs.GetLength(1); j++)
                {
                    if (!indexes.Contains(inputs[i, j]))
                    {
                        indexes.Put(inputs[i, j], indexes.Size);
                    }
                }
            }

            // 构建索引到顶点的映射
            keys = new T[indexes.Size];
            foreach (var item in indexes)
            {
                keys[indexes.Get(item.Key)] = item.Key;
            }

            // 构建图
            graph = new UndirectedGraph(indexes.Size);
            for (int i = 0; i < inputs.GetLength(0); i++)
            {
                int v = indexes.Get(inputs[i, 0]);

                for (int j = 1; j < inputs.GetLength(1); j++)
                {
                    graph.AddEdge(v, Index(inputs[i, j]));
                }
            }
        }

        /// <summary>
        /// 判断图中是否包含顶点
        /// </summary>
        /// <param name="vertex">顶点</param>
        public bool Contains(T vertex)
        {
            return indexes.Contains(vertex);
        }

        /// <summary>
        /// 获取顶点对应的索引
        /// </summary>
        /// <param name="vertex">顶点</param>
        /// <returns>顶点的索引</returns>
        public int Index(T vertex)
        {
            return indexes.Get(vertex);
        }

        /// <summary>
        /// 根据索引获取顶点
        /// </summary>
        /// <param name="index">顶点的索引</param>
        /// <returns>对应的顶点</returns>
        public T Name(int index)
        {
            return keys[index];
        }

        /// <summary>
        /// 获取当前符号图表示的图数据结构
        /// </summary>
        /// <returns></returns>
        public IGraph Graph()
        {
            return graph;
        }
    }
}
