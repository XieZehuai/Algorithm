﻿using System.Dynamic;

namespace _5_String
{
    internal class Program : DynamicObject
    {
        private static void Main(string[] args)
        {
            Tries.Test.Invoke();
        }
    }
}
