using System.Collections.Generic;
using _3_Searching;

namespace _5_String.Tries
{
    public class TrieSymbolTable<TV> : StringSymbolTable<TV>
    {
        #region 节点类
        private class Node
        {
            public TV value;
            public bool isEmpty = true;
            public Node[] nodes = new Node[26];

            /// <summary>
            /// 以当前节点为根的树的节点数量
            /// </summary>
            public int Size
            {
                get
                {
                    int size = 0;

                    if (!isEmpty) size++;

                    for (int i = 0; i < nodes.Length; i++)
                    {
                        if (nodes[i] != null)
                        {
                            size += nodes[i].Size;
                        }
                    }

                    return size;
                }
            }
        }
        #endregion


        private const int R = 26;

        private Node root;

        public override string Name => "单词查找树";

        public override int Size => root == null ? 0 : root.Size;

        public override IEnumerable<string> Keys => KeysWithPrefix(string.Empty);

        public override IEnumerable<TV> Values
        {
            get
            {
                List<TV> list = new List<TV>();
                CollectValues(root, list);
                return list;
            }
        }

        public override bool Contains(string key)
        {
            return Contains(root, key, 0);
        }

        public override void Put(string key, TV value)
        {
            root = Put(root, key, value, 0);
        }

        public override TV Get(string key)
        {
            Node node = Get(root, key, 0);

            if (node == null) throw new KeyNotFoundException();
            return node.value;
        }

        public override void Delete(string key)
        {
            Delete(root, key, 0);
        }

        public override IEnumerator<KeyValue<string, TV>> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<string> KeysThatMatch(string pattern)
        {
            List<string> list = new List<string>();
            CollectKeys(root, "", pattern, list);
            return list;
        }

        public override IEnumerable<string> KeysWithPrefix(string prefix)
        {
            List<string> list = new List<string>();
            CollectKeys(Get(root, prefix, 0), prefix, list);
            return list;
        }

        public override string LongestPrefixOf(string str)
        {
            int length = Search(root, str, 0, 0);
            return str.Substring(0, length);
        }


        /************************** 私有方法 **************************/

        private bool Contains(Node node, string key, int d)
        {
            if (node == null) return false;
            if (d == key.Length) return !node.isEmpty;

            for (int i = 0; i < R; i++)
            {
                if (Contains(node.nodes[i], key, d + 1))
                {
                    return true;
                }
            }

            return false;
        }

        private Node Put(Node node, string key, TV value, int d)
        {
            if (node == null) node = new Node();

            if (d == key.Length)
            {
                node.value = value;
                node.isEmpty = false;
                return node;
            }

            int index = key[d] - 'a';
            node.nodes[index] = Put(node.nodes[index], key, value, d + 1);
            return node;
        }

        private Node Get(Node node, string key, int d)
        {
            if (node == null) return null;
            if (d == key.Length) return node;

            int index = key[d] - 'a';
            return Get(node.nodes[index], key, d + 1);
        }

        // 获取以node为根的树所有节点的键
        private void CollectKeys(Node node, string str, List<string> list)
        {
            if (node == null) return;

            if (!node.isEmpty)
            {
                list.Add(str);
            }

            for (int i = 0; i < node.nodes.Length; i++)
            {
                string s = str + (char)(i + 'a');
                CollectKeys(node.nodes[i], s, list);
            }
        }

        // 获取所有与pattern匹配的键
        private void CollectKeys(Node node, string prefix, string pattern, List<string> list)
        {
            if (node == null) return;

            int d = prefix.Length;

            if (d == pattern.Length)
            {
                if (!node.isEmpty) list.Add(prefix);
                return;
            }

            char next = pattern[d];
            for (int i = 0; i < R; i++)
            {
                char c = (char)(i + 'a');
                if (next == '*' || next == c)
                {
                    CollectKeys(node.nodes[i], prefix + c, pattern, list);
                }
            }
        }

        private void CollectValues(Node node, List<TV> list)
        {
            if (node == null) return;

            if (!node.isEmpty)
            {
                list.Add(node.value);
            }

            for (int i = 0; i < R; i++)
            {
                CollectValues(node.nodes[i], list);
            }
        }

        private int Search(Node node, string str, int d, int length)
        {
            if (node == null) return length;
            if (!node.isEmpty) length = d;
            if (d == str.Length) return length;

            int index = str[d] - 'a';
            return Search(node.nodes[index], str, d + 1, length);
        }

        private Node Delete(Node node, string key, int d)
        {
            if (node == null) return null;

            if (d == key.Length)
            {
                node.isEmpty = true;
            }
            else
            {
                int index = key[d] - 'a';
                node.nodes[index] = Delete(node.nodes[index], key, d + 1);
            }

            if (!node.isEmpty) return node;

            for (int i = 0; i < R; i++)
            {
                if (!node.nodes[i].isEmpty)
                {
                    return node;
                }
            }

            return null;
        }
    }
}
