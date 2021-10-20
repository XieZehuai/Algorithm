using System;
using Test;

namespace _5_String.SubstringSearch
{
    public static class Test
    {
        private const int TEXT_LENGTH = 100000;
        private const int PATTERN_LENGTH = 20;

        private static string bestText;
        private static string bestPattern;
        private static string normalText;
        private static string normalPattern;
        private static string worstText;
        private static string worstPattern;

        static Test()
        {
            #region 构建最好情况的数据
            char[] c = new char[TEXT_LENGTH];
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = i >= (c.Length - PATTERN_LENGTH) ? 'b' : 'a';
            }
            bestText = new string(c);

            c = new char[PATTERN_LENGTH];
            for (int i = 0; i < PATTERN_LENGTH; i++)
            {
                c[i] = 'b';
            }
            bestPattern = new string(c);
            #endregion

            #region 构建正常情况的数据
            normalText = RandomString(TEXT_LENGTH);
            normalPattern = normalText.Substring(normalText.Length - PATTERN_LENGTH, PATTERN_LENGTH);
            #endregion

            #region 构建最差情况的数据
            c = new char[TEXT_LENGTH];
            c[c.Length - 1] = 'b';
            for (int i = 0; i < c.Length - 1; i++)
            {
                c[i] = 'a';
            }
            worstText = new string(c);
            worstPattern = worstText.Substring(worstText.Length - PATTERN_LENGTH, PATTERN_LENGTH);
            #endregion
        }

        public static void Invoke()
        {
            EfficiencyTest(new BruteForce());
            EfficiencyTest(new FiniteStateAutomata());
            EfficiencyTest(new BoyerMoore());
            EfficiencyTest(new CSharpImplement());
        }

        private static void CorrectnessTest(ISubstringSearcher searcher)
        {
            for (int i = 0; i < 10; i++)
            {
                string text = RandomString(15);
                string pattern = text.Substring(8, 5);
                int result = searcher.Search(text, pattern);
                if (result != 8)
                {
                    Console.WriteLine($"{searcher.Name} 实现错误");
                    Console.WriteLine(text);
                    Console.WriteLine(pattern);
                    return;
                }
            }

            Console.WriteLine($"{searcher.Name} 实现正确");
        }

        private static void EfficiencyTest(ISubstringSearcher searcher)
        {
            Console.WriteLine(searcher.Name + '：');
            Console.WriteLine($"\t最好情况：{Counting(searcher, bestText, bestPattern).ToString()} \t毫秒");
            Console.WriteLine($"\t正常情况：{Counting(searcher, normalText, normalPattern).ToString()} \t毫秒");
            Console.WriteLine($"\t最差情况：{Counting(searcher, worstText, worstPattern).ToString()} \t毫秒\n");
        }

        private static long Counting(ISubstringSearcher searcher, string text, string pattern)
        {
            long cost = 0L;
            for (int i = 0; i < 10; i++)
            {
                cost += Timer.Counting(false, () => searcher.Search(text, pattern));
            }

            return cost;
        }

        private static string RandomString(int length)
        {
            char[] c = new char[length];
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                int n = random.Next() % 26 + 'a';
                c[i] = Convert.ToChar(n);
            }

            return new string(c);
        }
    }
}
