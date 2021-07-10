using _2_Sort;

namespace _5_String.StringSort
{
    /// <summary>
    /// 高位优先的字符串排序，字符串的长度可以不同
    /// </summary>
    public class MSD : ISorter<string>
    {
        private const int R = 26; // 基数

        private readonly int threshold; // 子数组长度小于该值时切换排序算法
        private readonly ISorter<string> sorter; // 子数组长度小于 threshold 时使用的排序算法
        private string[] aux; // 数据分类的辅助数组

        public MSD(ISorter<string> sorter, int threshold)
        {
            this.sorter = sorter;
            this.threshold = threshold;
        }

        public string Name => "高位优先的字符串排序";

        public void Sort(string[] data)
        {
            int length = data.Length;
            aux = new string[length];
            Sort(data, 0, length - 1, 0);
        }

        public void Sort(string[] data, int low, int high)
        {
            int length = data.Length;
            aux = new string[length];
            Sort(data, low, high, 0);
        }

        private void Sort(string[] data, int low, int high, int d)
        {
            // 排序元素个数小于 M 时用插入排序
            if (high <= low + threshold)
            {
                sorter.Sort(data, low, high);
            }
            else
            {
                int[] count = new int[R + 2];

                for (int i = low; i <= high; i++)
                {
                    count[CharAt(data[i], d) + 1]++;
                }

                for (int r = 0; r <= R; r++)
                {
                    count[r + 1] += count[r];
                }

                for (int i = low; i <= high; i++)
                {
                    aux[count[CharAt(data[i], d)]++] = data[i];
                }

                for (int i = low; i <= high; i++)
                {
                    data[i] = aux[i - low];
                }

                for (int r = 0; r < R; r++)
                {
                    Sort(data, low + count[r], low + count[r + 1] - 1, d + 1);
                }
            }
        }

        private int CharAt(string str, int index)
        {
            if (index < str.Length)
            {
                return str[index] - 'a' + 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
