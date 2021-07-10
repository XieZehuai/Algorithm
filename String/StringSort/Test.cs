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
            //string[] rawData = GenerateTestData(10, 5, 10);
            //CorrectnessTest(new MSD(15), rawData);

            string[] rawData = GenerateTestData(LENGTH, 20);
            EfficiencyTest(new LSD(W), rawData);
            EfficiencyTest(new MSD(new QuickSort<string>(), 10), rawData);
            EfficiencyTest(new CSharpSort<string>(), rawData);
        }

        private static void CorrectnessTest(ISorter<string> sorter, string[] rawData)
        {
            string[] data1 = new string[rawData.Length];
            Array.Copy(rawData, data1, rawData.Length);
            sorter.Sort(data1);

            string[] data2 = new string[rawData.Length];
            Array.Copy(rawData, data2, rawData.Length);
            new CSharpSort<string>().Sort(data2);

            bool result = true;
            for (int i = 0; i < rawData.Length; i++)
            {
                if (data1[i] != data2[i])
                {
                    result = false;
                }
            }

            Console.WriteLine(result);
        }

        // 效率测试
        private static void EfficiencyTest(ISorter<string> sorter, string[] rawData)
        {
            // 复制原始数据
            string[] data = new string[rawData.Length];
            Array.Copy(rawData, data, rawData.Length);

            // 排序并计时
            sw.Restart();
            sorter.Sort(data);
            sw.Stop();

            // 打印结果
            Console.WriteLine($"{sorter.Name}\t{sw.Elapsed.TotalMilliseconds}\t毫秒");
        }

        // 生成 length 个长度为 w 的随机字符串
        private static string[] GenerateTestData(int length, int w)
        {
            return GenerateTestData(length, w, w);
        }

        // 生成 length 个长度为 minW 到 maxW 之间的随机字符串
        private static string[] GenerateTestData(int length, int minW, int maxW)
        {
            string[] data = new string[length];
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            int delta = maxW - minW + 1;

            for (int i = 0; i < length; i++)
            {
                int w = random.Next() % delta + minW;
                for (int j = 0; j < w; j++)
                {
                    char c = (char)(random.Next() % 26 + 'a');
                    sb.Append(c);
                }

                data[i] = sb.ToString();
                sb.Clear();
            }

            return data;
        }
    }
}
