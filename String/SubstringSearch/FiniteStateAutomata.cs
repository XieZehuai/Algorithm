namespace _5_String.SubstringSearch
{
    public class FiniteStateAutomata : ISubstringSearcher
    {
        private int[,] dfa;

        public string Name => "FiniteStateAutomata";

        public int Search(string text, string pattern)
        {
            if (dfa == null)
            {
                GenerateDfa(pattern);
            }

            int i, j, n = text.Length, m = pattern.Length;

            for (i = 0, j = 0; i < n && j < m; i++)
            {
                j = dfa[text[i] - 'a', j];
            }

            if (j == m) return i - m;
            else return -1;
        }

        private void GenerateDfa(string pattern)
        {
            dfa = new int[26, pattern.Length];
            dfa[pattern[0] - 'a', 0] = 1;

            for (int x = 0, j = 1; j < pattern.Length; j++)
            {
                for (int c = 0; c < 26; c++)
                {
                    dfa[c, j] = dfa[c, x];
                }

                dfa[pattern[j] - 'a', j] = j + 1;
                x = dfa[pattern[j] - 'a', x];
            }
        }
    }
}
