using System;
using System.Collections.Generic;

namespace _5_String
{
    public abstract class Alphabet
    {
        protected Alphabet(string s)
        {
        }

        public abstract int Length { get; }

        public abstract char GetChar(int index);

        public abstract int GetIndex(char c);

        public abstract bool Contains(char c);
    }
}
