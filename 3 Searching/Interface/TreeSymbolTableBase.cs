using System;
using System.Collections.Generic;
using System.Linq;

namespace _3_Searching
{
    public abstract class TreeSymbolTableBase<TKey, TValue, TNode> :
        OrderedSymbolTable<TKey, TValue>
        where TKey : IComparable<TKey>
        where TNode : TreeNodeBase<TKey, TValue, TNode>
    {
        protected TNode root; // 根节点
        protected readonly int order = 0;

        protected TreeSymbolTableBase(int order = 0)
        {
            this.order = order;
        }

        public override int Size => SizeOfNode(root);

        public override TKey Min
        {
            get
            {
                if (root == null) throw new KeyNotFoundException();

                return GetMin(root).Key;
            }
        }

        public override TKey Max
        {
            get
            {
                if (root == null) throw new KeyNotFoundException();

                return GetMax(root).Key;
            }
        }

        public override void DeleteMin()
        {
            if (root == null) throw new NullReferenceException();

            root = DeleteMin(root);
        }

        public override void DeleteMax()
        {
            if (root == null) throw new NullReferenceException();

            root = DeleteMax(root);
        }

        public override bool Contains(TKey key)
        {
            return Find(root, key) != null;
        }

        public override void Delete(TKey key)
        {
            root = Delete(root, key);
        }

        public override TValue Get(TKey key)
        {
            TNode target = Find(root, key);
            if (target == null) throw new KeyNotFoundException("在表中找不到键" + key);

            return target.Value;
        }

        public override int Rank(TKey key)
        {
            return Rank(root, key);
        }

        public override TKey Select(int rank)
        {
            TNode node = Select(root, rank);
            if (node == null) throw new ArgumentOutOfRangeException();

            return node.Key;
        }

        public override TKey Floor(TKey key)
        {
            TNode node = Floor(root, key);
            if (node == null) throw new ArgumentOutOfRangeException();

            return node.Key;
        }

        public override TKey Ceiling(TKey key)
        {
            TNode node = Ceiling(root, key);
            if (node == null) throw new ArgumentOutOfRangeException();

            return node.Key;
        }

        public override IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            List<KeyValue<TKey, TValue>> list = new List<KeyValue<TKey, TValue>>();
            Traverse(root, list, Min, Max);

            return list.GetEnumerator();
        }

        public override IEnumerable<TKey> KeysBetween(TKey low, TKey high)
        {
            List<KeyValue<TKey, TValue>> list = new List<KeyValue<TKey, TValue>>();
            Traverse(root, list, low, high);

            List<TKey> temp = new List<TKey>(list.Count);
            temp.AddRange(list.Select(t => t.Key));

            return temp;
        }

        /****************************************************
         *                     辅助函数
         ****************************************************/

        // 在以node为根的树中查找拥有对应key的节点
        protected virtual TNode Find(TNode node, TKey key)
        {
            while (true)
            {
                if (node == null) return null;

                int cmp = key.CompareTo(node.Key);
                if (cmp == 0) return node;
                node = cmp > 0 ? node.right : node.left;
            }
        }

        // 把key和value插入到以node为根的树中，如果已经有对应的key，就直接修改节点的值，没有则插入新节点
        protected virtual TNode Put(TNode node, TKey key, TValue value, Func<TNode> create)
        {
            // if (node == null) return new TNode(key, value, 1);
            if (node == null) return create();

            int cmp = key.CompareTo(node.Key);

            if (cmp == 0)
                node.Value = value;
            else if (cmp > 0)
                node.right = Put(node.right, key, value, create);
            else
                node.left = Put(node.left, key, value, create);

            node.size = SizeOfNode(node.left) + SizeOfNode(node.right) + 1;

            return node;
        }

        protected virtual int SizeOfNode<T>(TreeNodeBase<TKey, TValue, T> node) where T : class
        {
            return node?.size ?? 0;
        }

        /// <summary>
        /// 根据设定的遍历顺序遍历整棵树并把节点保存到存入的集合里
        /// </summary>
        /// <param name="node">要遍历的树的根节点</param>
        /// <param name="collection">用于存储遍历到的节点的集合</param>
        /// <param name="low">要遍历的key的最小值</param>
        /// <param name="high">要遍历的key的最大值</param>
        protected virtual void Traverse(TNode node,
            ICollection<KeyValue<TKey, TValue>> collection,
            TKey low, TKey high)
        {
            if (low.CompareTo(high) > 0) return;
            if (node == null) return;
            if (node.Key.CompareTo(low) < 0 || node.Key.CompareTo(high) > 0) return;

            if (order == 0)
            {
                Traverse(node.left, collection, low, high);
                collection.Add(node);
                Traverse(node.right, collection, low, high);
            }
            else if (order < 0)
            {
                Traverse(node.left, collection, low, high);
                Traverse(node.right, collection, low, high);
                collection.Add(node);
            }
            else
            {
                collection.Add(node);
                Traverse(node.left, collection, low, high);
                Traverse(node.right, collection, low, high);
            }
        }

        protected virtual TNode Floor(TNode node, TKey key)
        {
            while (true)
            {
                if (node == null) return null;

                int cmp = key.CompareTo(node.Key);

                if (cmp == 0) return node;
                if (cmp < 0)
                {
                    node = node.left;
                    continue;
                }

                TNode temp = Floor(node.right, key);
                return temp ?? node;
            }
        }

        protected virtual TNode Ceiling(TNode node, TKey key)
        {
            while (true)
            {
                if (node == null) return null;

                int cmp = key.CompareTo(node.Key);

                if (cmp == 0) return node;
                if (cmp > 0)
                {
                    node = node.right;
                    continue;
                }

                TNode temp = Floor(node.left, key);
                return temp ?? node;
            }
        }

        protected virtual int Rank(TNode node, TKey key)
        {
            while (true)
            {
                if (node == null) return 0;

                int cmp = key.CompareTo(node.Key);

                if (cmp == 0) return SizeOfNode(node.left);
                if (cmp > 0) return Rank(node.right, key) + SizeOfNode(node.left) + 1;
                node = node.left;
            }
        }

        protected virtual TNode Select(TNode node, int rank)
        {
            while (true)
            {
                if (node == null) return null;

                int size = SizeOfNode(node.left);

                if (size == rank) return node;
                if (size > rank)
                {
                    node = node.left;
                    continue;
                }

                node = node.right;
                rank = rank - size - 1;
            }
        }

        protected virtual TNode GetMin(TNode node)
        {
            if (node == null) throw new ArgumentNullException();

            TNode temp = node;

            while (temp.left != null)
            {
                temp = temp.left;
            }

            return temp;
        }

        protected virtual TNode GetMax(TNode node)
        {
            if (node == null) throw new ArgumentNullException();

            TNode temp = node;

            while (temp.right != null)
            {
                temp = temp.right;
            }

            return temp;
        }

        protected virtual TNode Delete(TNode node, TKey key)
        {
            if (node == null) return null;

            int cmp = key.CompareTo(node.Key);
            if (cmp < 0)
            {
                node.left = Delete(node.left, key);
            }
            else if (cmp > 0)
            {
                node.right = Delete(node.right, key);
            }
            else
            {
                if (node.right == null) return node.left;
                if (node.left == null) return node.right;

                TNode temp = node;
                node = GetMin(temp.right);
                node.left = temp.left;
                node.right = DeleteMin(temp.right);
            }

            node.size = SizeOfNode(node.left) + SizeOfNode(node.right) + 1;

            return node;
        }

        protected virtual TNode DeleteMin(TNode node)
        {
            if (node.left == null) return node.right;

            node.left = DeleteMin(node.left);
            node.size = SizeOfNode(node.left) + SizeOfNode(node.right) + 1;

            return node;
        }

        protected virtual TNode DeleteMax(TNode node)
        {
            if (node.right == null) return node.left;

            node.right = DeleteMin(node.right);
            node.size = SizeOfNode(node.left) + SizeOfNode(node.right) + 1;

            return node;
        }
    }
}