using System;

namespace _5_String.RegularExpression
{
    internal static class Test
    {
        public static void Invoke()
        {
            string s = "aa";
            string p = "a*";
            Console.WriteLine(IsMatch(s, p));
        }

        public static bool IsMatch(string s, string p)
        {
            bool[] pc = new bool[p.Length + 1];
            pc[0] = true;
            int i = 0;

            while (i < s.Length)
            {
                bool[] match = new bool[p.Length + 1];
                bool flag = false;

                for (int j = 0; j < pc.Length - 1; j++)
                {
                    if (!pc[j])
                    {
                        continue;
                    }

                    flag = true;
                    if (p[j] == s[i] || p[j] == '.')
                    {
                        match[j + 1] = true;
                    }
                    if (j + 1 < p.Length && p[j + 1] == '*')
                    {
                        match[j] = true;
                        match[j + 1] = true;
                    }
                    if (p[j] == '*')
                    {
                        match[j + 1] = true;
                    }
                }

                i++;
                if (!flag) break;
                pc = match;
            }

            return i == s.Length && pc[pc.Length - 1];
        }
    }
}
