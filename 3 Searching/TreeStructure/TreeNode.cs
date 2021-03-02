using System;
using System.Collections.Generic;

namespace _3_Searching
{
    public abstract class TreeNodeBase<TKey, TValue, T> : KeyValue<TKey, TValue> where T : class
    {
        public T left;
        public T right;
        public int size; // 以当前节点为根的树的所有节点的数量

        public TreeNodeBase(TKey key, TValue value, int size = 1) : base(key, value)
        {
            this.size = size;
        }

        public TreeNodeBase(TKey key, TValue value, int size = 1, T left = null, T right = null) : base(key, value)
        {
            this.left = left;
            this.right = right;
            this.size = size;
        }
    }


    public class TreeNode<TKey, TValue> : TreeNodeBase<TKey, TValue, TreeNode<TKey, TValue>>
    {
        public TreeNode(TKey key, TValue value, int size = 1) : base(key, value, size)
        {
        }

        public TreeNode(TKey key, TValue value, int size = 1, TreeNode<TKey, TValue> left = null,
            TreeNode<TKey, TValue> right = null) : base(key, value, size, left, right)
        {
        }
    }


    public class RedBlackNode<TKey, TValue> : TreeNodeBase<TKey, TValue, RedBlackNode<TKey, TValue>>
    {
        public enum Color
        {
            Red,
            Black,
        }

        public Color color;

        public RedBlackNode(TKey key, TValue value, Color color, int size = 1) : base(key, value, size)
        {
            this.color = color;
        }

        public RedBlackNode(TKey key, TValue value, Color color, int size = 1, RedBlackNode<TKey, TValue> left = null,
            RedBlackNode<TKey, TValue> right = null) : base(key, value, size, left, right)
        {
            this.color = color;
        }
    }
}