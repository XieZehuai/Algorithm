using System.Collections;
using System.Collections.Generic;

namespace _1_Basics
{
    /// <summary>
    /// 泛型背包，只能添加元素和遍历所有元素
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Bag<T> : IEnumerable<T>
    {
        #region 链表节点
        private class Node
        {
            public T item;
            public Node next;

            public Node(T item, Node next = null)
            {
                this.item = item;
                this.next = next;
            }
        }
        #endregion


        private Node head;

        private int count = 0;

        /// <summary>
        /// 背包中元素的个数
        /// </summary>
        public int Count => count;

        /// <summary>
        /// 背包是否为空
        /// </summary>
        public bool IsEmpty => Count == 0;

        /// <summary>
        /// 添加一个元素
        /// </summary>
        /// <param name="item">要添加的元素</param>
        public void Add(T item)
        {
            Node node = new Node(item, head);
            head = node;
            count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node node = head;

            while (node != null)
            {
                yield return node.item;
                node = node.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
