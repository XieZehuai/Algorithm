namespace _5_String.SubstringSearch
{
    public class CSharpImplement : ISubstringSearcher
    {
        public string Name => "C#";

        public int Search(string text, string pattern)
        {
            return text.IndexOf(pattern);
        }
    }
}
