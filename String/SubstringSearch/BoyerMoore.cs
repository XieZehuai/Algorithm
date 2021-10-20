namespace _5_String.SubstringSearch
{
    public class BoyerMoore : ISubstringSearcher
    {
        private int[] right;

        public string Name => "Boyer-Moore";

        public int Search(string text, string pattern)
        {
            int n = text.Length, m = pattern.Length;

            if (right == null)
            {
                right = new int[26];
                for (int i = 0; i < 26; i++)
                {
                    right[i] = -1;
                }
                for (int i = 0; i < m; i++)
                {
                    right[pattern[i] - 'a'] = i;
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
                        skip = j - right[text[i + j] - 'a'];
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
