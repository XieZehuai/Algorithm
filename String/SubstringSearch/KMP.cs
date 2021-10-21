using System;

namespace _5_String.SubstringSearch
{
    public class KMP : ISubstringSearcher
    {
        public string Name => "KMP";

        public int Search(string text, string pattern)
        {
            int[] prefix = GetPrefixTable(pattern);
            int m = text.Length, n = pattern.Length;
            int i = 0, j = 0;

            while (i < m)
            {
                if (j == n - 1 && text[i] == pattern[j])
                {
                    return i - j;
                }

                if (text[i] == pattern[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    j = prefix[j];
                    if (j == -1)
                    {
                        j = 0;
                        i++;
                    }
                }
            }

            return -1;
        }

        private int[] GetPrefixTable(string pattern)
        {
            int[] prefix = new int[pattern.Length];
            int len = 0;
            int i = 1;

            while (i < pattern.Length)
            {
                if (pattern[i] == pattern[len])
                {
                    prefix[i] = ++len;
                    i++;
                }
                else
                {
                    if (len > 0)
                    {
                        len = prefix[len - 1];
                        prefix[i] = len;
                    }
                    else
                    {
                        prefix[i] = 0;
                        i++;
                    }
                }
            }

            for (i = prefix.Length - 1; i > 0; i--)
            {
                prefix[i] = prefix[i - 1];
            }
            prefix[0] = -1;

            return prefix;
        }
    }
}
