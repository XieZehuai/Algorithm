using System;
using System.Diagnostics;
using System.Text;
using _2_Sort;

namespace _5_String.StringSort
{
    public static class Test
    {
        private static readonly Stopwatch sw = new Stopwatch();

        private const int LENGTH = 100000;
        private const int W = 20;

        public static void Invoke()
        {
            string[] originData = GenerateTestData(LENGTH, W);

            SortTest(new LSD(W), originData);
            SortTest(new CSharpSort<string>(), originData);
        }

        private static void SortTest(ISorter<string> sorter, string[] originData)
        {
            string[] data = new string[originData.Length];
            Array.Copy(originData, data, originData.Length);
            Sort(sorter, data);
        }

        private static void Sort<T>(ISorter<T> sorter, T[] data)
        {
            sw.Restart();
            sorter.Sort(data);
            sw.Stop();

            Console.WriteLine($"{sorter.Name}\t{sw.Elapsed.TotalMilliseconds}毫秒");
        }

        private static string[] GenerateTestData(int length, int w)
        {
            string[] str = new string[length];
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < w; j++)
                {
                    char c = (char)(random.Next() % 26 + 'a');
                    sb.Append(c);
                }
                str[i] = sb.ToString();
            }

            return str;
        }
    }
}
