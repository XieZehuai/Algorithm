using System;
using _2_Sort;

namespace _5_String.StringSort
{
    /// <summary>
    /// 低位优先的字符串排序，所有字符串的长度都应该相同
    /// </summary>
    public class LSD : ISorter<string>
    {
        private const int START = 'a';

        private readonly int w;

        public LSD(int w)
        {
            this.w = w;
        }

        public string Name => "低位优先的字符串排序";

        public void Sort(string[] data)
        {
            int length = data.Length;
            string[] aux = new string[length];

            for (int d = w - 1; d >= 0; d--)
            {
                int[] count = new int[27];
                for (int i = 0; i < length; i++)
                {
                    count[data[i][d] - START + 1]++;
                }

                for (int i = 0; i < 26; i++)
                {
                    count[i + 1] += count[i];
                }

                for (int i = 0; i < length; i++)
                {
                    int index = data[i][d] - START;
                    aux[count[index]++] = data[i];
                }

                for (int i = 0; i < length; i++)
                {
                    data[i] = aux[i];
                }
            }
        }

        public void Sort(string[] data, int low, int high)
        {
            throw new NotImplementedException();
        }
    }
}
