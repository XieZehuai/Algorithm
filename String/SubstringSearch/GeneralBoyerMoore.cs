using System.Collections.Generic;

namespace _5_String.SubstringSearch
{
    public class GeneralBoyerMoore : ISubstringSearcher
    {
        public string Name => "General Boyer-Moore";

        public int Search(string text, string pattern)
        {
            int n = text.Length, m = pattern.Length;
            Dictionary<char, int> right = new Dictionary<char, int>();
            for (int i = 0; i < m; i++)
            {
                if (!right.ContainsKey(pattern[i]))
                {
                    right.Add(pattern[i], i);
                }
                else
                {
                    right[pattern[i]] = i;
                }
            }

            int skip;
            for (int i = 0; i <= n - m; i += skip)
            {
                skip = 0;
                for (int j = m - 1; j >= 0; j--)
                {
                    if (pattern[j] != text[i + j])
                    {
                        int r = right.ContainsKey(text[i + j]) ? right[text[i + j]] : -1;
                        skip = j - r;
                        if (skip < 1) skip = 1;
                        break;
                    }
                }
                if (skip == 0) return i;
            }

            return -1;
        }
    }
}
