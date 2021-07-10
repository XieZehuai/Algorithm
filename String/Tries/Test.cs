using System;

namespace _5_String.Tries
{
    public static class Test
    {
        public static void Invoke()
        {
            StringSymbolTable<int> table = new TrieSymbolTable<int>();

            table.Put("hello", 1);
            table.Put("hallo", 2);
            table.Put("holo", 3);
            table.Put("hollow", 4);
            table.Put("holl", 4);
            table.Put("hollowknig", 4);
            table.Put("haven", 5);

            Console.WriteLine(table.LongestPrefixOf("hollowknight"));
        }
    }
}
