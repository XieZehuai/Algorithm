using System;
using Test;

namespace _5_String.SubstringSearch
{
    public static class Test
    {
        public static void Invoke()
        {
            char[] c = new char[10000];
            char[] s = new char[5000];
            c[9999] = 'b';
            for (int i = 0; i < 9999; i++)
            {
                c[i] = 'a';
            }
            Array.Copy(c, c.Length - s.Length, s, 0, s.Length);

            string text = new string(c);
            string pattern = new string(s);
            
            ISubstringSearcher searcher = new BruteForce();

            Timer.Counting(true, () =>
            {
                Console.WriteLine(searcher.Search(text, pattern).ToString());
            });
        }
    }
}
