using System;
using System.Collections.Generic;

namespace _3_Searching
{
    /*
     * 基于红黑树实现的符号表
     */
    public class RedBlackTreeSymbolTable<TK, TV> : TreeSymbolTableBase<TK, TV, RedBlackNode<TK, TV>>
        where TK : IComparable<TK>
    {
        public override string Name => "红黑树";

        public override bool IsEmpty => root == null;

        public RedBlackTreeSymbolTable(int order = 0) : base(order)
        {
        }

        public override void Put(TK key, TV value)
        {
            root = Put(root, key, value,
                () => new RedBlackNode<TK, TV>(key, value, RedBlackNode<TK, TV>.Color.Red, 1));

            root.color = RedBlackNode<TK, TV>.Color.Black;
        }

        public override void Delete(TK key)
        {
            if (!Contains(key)) throw new KeyNotFoundException();

            if (!IsRed(root.left) && !IsRed(root.right))
                root.color = RedBlackNode<TK, TV>.Color.Red;

            root = Delete(root, key);

            if (!IsEmpty) root.color = RedBlackNode<TK, TV>.Color.Black;
        }

        public override void DeleteMin()
        {
            if (IsEmpty) throw new KeyNotFoundException();

            if (!IsRed(root.left) && !IsRed(root.right))
                root.color = RedBlackNode<TK, TV>.Color.Red;

            root = DeleteMin(root);

            if (!IsEmpty) root.color = RedBlackNode<TK, TV>.Color.Black;
        }

        public override void DeleteMax()
        {
            if (IsEmpty) throw new KeyNotFoundException();

            if (!IsRed(root.left) && !IsRed(root.right))
                root.color = RedBlackNode<TK, TV>.Color.Red;

            root = DeleteMax(root);

            if (!IsEmpty) root.color = RedBlackNode<TK, TV>.Color.Black;
        }

        /*******************************************************************
         *     辅助函数
         *******************************************************************/

        protected override RedBlackNode<TK, TV> Put(RedBlackNode<TK, TV> node, TK key, TV value,
            Func<RedBlackNode<TK, TV>> create)
        {
            if (node == null) return create();

            int cmp = key.CompareTo(node.Key);

            if (cmp < 0)
                node.left = Put(node.left, key, value, create);
            else if (cmp > 0)
                node.right = Put(node.right, key, value, create);
            else
                node.Value = value;

            if (IsRed(node.right) && !IsRed(node.left)) node = RotateLeft(node);
            if (IsRed(node.left) && IsRed(node.left.left)) node = RotateRight(node);
            if (IsRed(node.left) && IsRed(node.right)) FlipColors(node);

            node.size = SizeOfNode(node.left) + SizeOfNode(node.right) + 1;

            return node;
        }

        /// <summary>
        /// 判断连接到当前节点的链接是否为红色
        /// </summary>
        /// <param name="node">要判断的节点</param>
        protected virtual bool IsRed(RedBlackNode<TK, TV> node)
        {
            return node != null && node.color == RedBlackNode<TK, TV>.Color.Red;
        }

        /// <summary>
        /// 左旋操作，将红色右链接指向的右节点向上提，节点本身向左下降
        /// </summary>
        /// <param name="node">要进行左旋操作的带有红色右链接的节点</param>
        /// <returns>旋转后带有红色左链接的节点</returns>
        protected virtual RedBlackNode<TK, TV> RotateLeft(RedBlackNode<TK, TV> node)
        {
            RedBlackNode<TK, TV> right = node.right;
            node.right = right.left;
            right.left = node;
            right.color = node.color;
            node.color = RedBlackNode<TK, TV>.Color.Red;
            right.size = node.size;
            node.size = SizeOfNode(node.left) + SizeOfNode(node.right) + 1;

            return right;
        }

        /// <summary>
        /// 右旋操作，将红色左链接指向的左节点向上提，节点本身向右下降
        /// </summary>
        /// <param name="node">要进行右旋操作的带有红色左链接的节点</param>
        /// <returns>旋转后带有红色右链接的节点</returns>
        protected virtual RedBlackNode<TK, TV> RotateRight(RedBlackNode<TK, TV> node)
        {
            RedBlackNode<TK, TV> left = node.left;
            node.left = left.right;
            left.right = node;
            left.color = node.color;
            node.color = RedBlackNode<TK, TV>.Color.Red;
            left.size = node.size;
            node.size = SizeOfNode(node.left) + SizeOfNode(node.right) + 1;

            return left;
        }

        /// <summary>
        /// 当一个节点的左右两条链接都是红色链接时，需要转换颜色，
        /// 把当前节点转换成红色，两个直接点转换成黑色
        /// </summary>
        /// <param name="node">要转换的节点</param>
        protected virtual void FlipColors(RedBlackNode<TK, TV> node)
        {
            node.color = RedBlackNode<TK, TV>.Color.Red;
            node.left.color = RedBlackNode<TK, TV>.Color.Black;
            node.right.color = RedBlackNode<TK, TV>.Color.Black;
        }

        protected override RedBlackNode<TK, TV> Delete(RedBlackNode<TK, TV> node, TK key)
        {
            if (key.CompareTo(node.Key) < 0)
            {
                if (!IsRed(node.left) && !IsRed(node.left.left)) node = MoveRedLeft(node);

                node.left = Delete(node.left, key);
            }
            else
            {
                if (IsRed(node.left)) node = RotateRight(node);

                if (key.CompareTo(node.Key) == 0 && node.right == null) return null;

                if (!IsRed(node.right) && !IsRed(node.right.right)) node = MoveRedRight(node);

                if (key.CompareTo(node.Key) == 0)
                {
                    RedBlackNode<TK, TV> temp = node;
                    node = GetMin(temp.right);
                    node.color = temp.color;
                    node.left = temp.left;
                    node.right = DeleteMin(temp.right);
                    node.size = SizeOfNode(node.left) + SizeOfNode(node.right) + 1;
                }
                else
                {
                    node.right = Delete(node.right, key);
                }
            }

            return Balance(node);
        }

        protected override RedBlackNode<TK, TV> DeleteMin(RedBlackNode<TK, TV> node)
        {
            if (node.left == null) return null;

            if (!IsRed(node.left) && !IsRed(node.left.left)) node = MoveRedLeft(node);

            node.left = DeleteMin(node.left);

            return Balance(node);
        }

        protected override RedBlackNode<TK, TV> DeleteMax(RedBlackNode<TK, TV> node)
        {
            if (IsRed(node.left)) node = RotateRight(node);

            if (node.right == null) return null;

            if (!IsRed(node.right) && !IsRed(node.right.left)) node = MoveRedRight(node);

            node.right = DeleteMax(node.right);

            return Balance(node);
        }

        protected virtual RedBlackNode<TK, TV> MoveRedLeft(RedBlackNode<TK, TV> node)
        {
            FlipColors(node);

            if (IsRed(node.right.left))
            {
                node.right = RotateRight(node.right);
                node = RotateLeft(node);
                FlipColors(node);
            }

            return node;
        }

        protected virtual RedBlackNode<TK, TV> MoveRedRight(RedBlackNode<TK, TV> node)
        {
            FlipColors(node);

            if (IsRed(node.right.left))
            {
                node.right = RotateRight(node.right);
                node = RotateLeft(node);
                FlipColors(node);
            }

            return node;
        }

        protected virtual RedBlackNode<TK, TV> Balance(RedBlackNode<TK, TV> node)
        {
            if (IsRed(node.right) && !IsRed(node.left)) node = RotateLeft(node);
            if (IsRed(node.left) && IsRed(node.left.left)) node = RotateRight(node);
            if (IsRed(node.left) && IsRed(node.right)) FlipColors(node);

            node.size = SizeOfNode(node.left) + SizeOfNode(node.right) + 1;

            return node;
        }
    }
}