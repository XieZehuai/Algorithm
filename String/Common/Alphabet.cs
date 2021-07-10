using System;
using System.Linq;
using System.Collections.Generic;

namespace _5_String
{
    /// <summary>
    /// 字符表，维护一个字符的集合以及每个字符对应的int值
    /// </summary>
    public class Alphabet
    {
        #region 预定义字符集
        /// <summary>
        /// 二进制字符集，只包含0和1
        /// </summary>
        public static readonly Alphabet Binary = new Alphabet("01");

        /// <summary>
        /// 八进制字符集，包含0-7
        /// </summary>
        public static readonly Alphabet Octal = new Alphabet("01234567");

        /// <summary>
        /// 十进制字符集，包含0-9
        /// </summary>
        public static readonly Alphabet Decimal = new Alphabet("0123456789");

        /// <summary>
        /// 十六进制字符集，包含0-9及A-F
        /// </summary>
        public static readonly Alphabet Hexadecimal = new Alphabet("0123456789ABCDEF");

        /// <summary>
        /// 小写字母字符集，包含所有小写字母
        /// </summary>
        public static readonly Alphabet Lowercase = new Alphabet("abcdefghijklmnopqrstuvwxyz");

        /// <summary>
        /// 大写字母字符集，包含所有大写字母
        /// </summary>
        public static readonly Alphabet Uppercase = new Alphabet("ABCDEFGHIJKLMNOPQRSTUVWXYZ");

        /// <summary>
        /// Base64字符集，包含大小写字母及数字等64个字符
        /// </summary>
        public static readonly Alphabet Base64 = new Alphabet("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/");

        /// <summary>
        /// 7位ASCII码字符集
        /// </summary>
        public static readonly Alphabet ASCII = new Alphabet(1 << 7);

        /// <summary>
        /// 扩展的8位ASCII码字符集
        /// </summary>
        public static readonly Alphabet ExtendedASCII = new Alphabet(1 << 8);

        /// <summary>
        /// 十六位Unicode字符集
        /// </summary>
        public static readonly Alphabet Unicode16 = new Alphabet(1 << 16);
        #endregion


        private readonly Dictionary<char, int> charToIndex = new Dictionary<char, int>();
        private readonly Dictionary<int, char> indexToChar = new Dictionary<int, char>();

        public Alphabet(int r)
        {
            for (int i = 0; i < r; i++)
            {
                char c = (char)i;
                charToIndex.Add(c, i);
                indexToChar.Add(i, c);
            }
        }

        public Alphabet(string alpha)
        {
            for (int i = 0; i < alpha.Length; i++)
            {
                if (!charToIndex.ContainsKey(alpha[i]))
                {
                    charToIndex.Add(alpha[i], i);
                    indexToChar.Add(i, alpha[i]);
                }
            }
        }

        public int R => charToIndex.Count;

        public int LgR
        {
            get
            {
                int lgR = 0;
                for (int t = R - 1; t >= 1; t /= 2)
                {
                    lgR++;
                }

                return LgR;
            }
        }

        public char GetChar(int index)
        {
            if (!indexToChar.ContainsKey(index)) throw new IndexOutOfRangeException();
            return indexToChar[index];
        }

        public int GetIndex(char c)
        {
            if (!charToIndex.ContainsKey(c)) throw new ArgumentException();
            return charToIndex[c];
        }

        public bool Contains(char c)
        {
            return charToIndex.ContainsKey(c);
        }

        public int[] ToIndices(string str)
        {
            int[] indices = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                indices[i] = GetIndex(str[i]);
            }

            return indices;
        }

        public string ToString(int[] indices)
        {
            string str = string.Empty;
            for (int i = 0; i < indices.Length; i++)
            {
                str += GetChar(indices[i]);
            }

            return str;
        }
    }
}
