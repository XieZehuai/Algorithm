using System.Collections.Generic;
using _3_Searching;

namespace _5_String.Tries
{
    /// <summary>
    /// 键为string类型的符号表API
    /// </summary>
    /// <typeparam name="TV">值的数据类型</typeparam>
    public abstract class StringSymbolTable<TV> : SymbolTable<string, TV>
    {
        /// <summary>
        /// s的前缀中最长的键
        /// </summary>
        public abstract string LongestPrefixOf(string str);

        /// <summary>
        /// 所有以prefix为前缀的键
        /// </summary>
        public abstract IEnumerable<string> KeysWithPrefix(string prefix);

        /// <summary>
        /// 所有和pattern匹配的键（"*" 能够匹配任意字符）
        /// </summary>
        public abstract IEnumerable<string> KeysThatMatch(string pattern);
    }
}
