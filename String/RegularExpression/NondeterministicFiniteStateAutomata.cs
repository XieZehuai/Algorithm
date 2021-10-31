using System.Collections.Generic;
using _1_Basics;
using _4_Graph;
using _4_Graph.GraphSearchAlgorithm;

namespace _5_String.RegularExpression
{
    public class NondeterministicFiniteStateAutomata
    {
        /// <summary>
        /// 判断给定字符串text中是否包含与pattern匹配的子串
        /// </summary>
        public bool Recognizes(string text, string pattern)
        {
            Bag<int> pc = new Bag<int>();
            DirectedGraph graph = GenerateNFA(pattern);
            DepthFirstSearch dfs = new DepthFirstSearch(graph, 0);

            for (int v = 0; v < graph.VertexCount; v++)
            {
                if (dfs.IsConnectedTo(v))
                {
                    pc.Add(v);
                }
            }

            for (int i = 0; i < text.Length; i++)
            {
                Bag<int> match = new Bag<int>();
                foreach (var v in pc)
                {
                    if (v < pattern.Length)
                    {
                        if (pattern[v] == text[i] || pattern[v] == '.')
                        {
                            match.Add(v + 1);
                        }
                    }
                }

                pc = new Bag<int>();
                dfs = new DepthFirstSearch(graph, match);
                for (int v = 0; v < graph.VertexCount; v++)
                {
                    if (dfs.IsConnectedTo(v))
                    {
                        pc.Add(v);
                    }
                }
            }

            foreach (var v in pc)
            {
                if (v == pattern.Length)
                {
                    return true;
                }
            }

            return false;
        }

        private DirectedGraph GenerateNFA(string pattern)
        {
            DirectedGraph graph = new DirectedGraph(pattern.Length + 1);
            Stack<int> ops = new Stack<int>();

            for (int i = 0; i < pattern.Length; i++)
            {
                int lp = i;
                if (pattern[i] == '(' || pattern[i] == '|')
                {
                    ops.Push(i);
                }
                else if (pattern[i] == ')')
                {
                    int or = ops.Pop();
                    if (pattern[or] == '|')
                    {
                        lp = ops.Pop();
                        graph.AddEdge(lp, or + 1);
                        graph.AddEdge(or, i);
                    }
                    else
                    {
                        lp = or;
                    }
                }

                if (i + 1 < pattern.Length && pattern[i + 1] == '*')
                {
                    graph.AddEdge(lp, i + 1);
                    graph.AddEdge(i + 1, lp);
                }

                if (pattern[i] == '(' || pattern[i] == '*' || pattern[i] == ')')
                {
                    graph.AddEdge(i, i + 1);
                }
            }

            return graph;
        }
    }
}
