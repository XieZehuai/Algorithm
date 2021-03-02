using System;

namespace _3_Searching
{
    /*
     * 用二叉搜索树实现的符号表
     */
    public class BinarySearchTreeSymbolTable<TKey, TValue> : TreeSymbolTableBase<TKey, TValue,
        TreeNode<TKey, TValue>> where TKey : IComparable<TKey>
    {
        public override string Name => "二叉搜索树";

        public BinarySearchTreeSymbolTable(int order = 0) : base(order)
        {
        }

        public override void Put(TKey key, TValue value)
        {
            root = Put(root, key, value, () => new TreeNode<TKey, TValue>(key, value, 1));
        }
    }
}