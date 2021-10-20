namespace _5_String.SubstringSearch
{
    public interface ISubstringSearcher
    {
        /// <summary>
        /// 算法的名字
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 在目标字符串text中寻找与pattern相同的子串
        /// </summary>
        /// <returns>寻找成功则返回子串的起始索引，失败则返回-1</returns>
        int Search(string text, string pattern);
    }
}
