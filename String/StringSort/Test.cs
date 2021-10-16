using System;
using System.Collections.Generic;
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
            List<(int, string)> students = new List<(int, string)>();
            students.Add((1, "小明"));
            students.Add((2, "小红"));
            students.Add((3, "小兰"));
            students.Add((2, "小绿"));
            students.Add((3, "小黄"));
            students.Add((1, "小华"));
            students.Add((1, "小紫"));
            students.Add((4, "小黑"));

            BaseSort baseSort = new BaseSort();
            baseSort.Sort(students, 5);
            foreach (var student in students)
            {
                Console.WriteLine(student.Item1 + " " + student.Item2);
            }

            //string[] data = GenerateTestData(10, 5, 10);
            //CorrectnessTest(new Quick3StringSort(), data);

            string[] rawData = GenerateTestData(LENGTH, W);
            EfficiencyTest(new LSD(W), rawData);
            EfficiencyTest(new MSD(new QuickSort<string>(), 10), rawData);
            EfficiencyTest(new Quick3StringSort(), rawData);
            EfficiencyTest(new QuickSort<string>(), rawData);
            EfficiencyTest(new CSharpSort<string>(), rawData);
        }

        /// <summary>
        /// 测试排序算法是否正确实现
        /// </summary>
        /// <param name="sorter">要测试的算法</param>
        /// <param name="rawData">测试使用的数据</param>
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
