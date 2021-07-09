using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_String.StringSort
{
    /// <summary>
    /// 高位优先的字符串排序，字符串的长度可以不同
    /// </summary>
    public class MSD
    {
        private const int M = 15; // 子数组长度小于该值时切换为插入排序
        private string[] aux; // 数据分类的辅助数组

        public void Sort(string[] data)
        {

        }

        private int CharAt(string str, int index)
        {
            if (index < str.Length)
            {
                return str[index];
            }
            else
            {
                return -1;
            }
        }
    }
}
