using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using _3_Searching.Hash;

namespace _3_Searching
{
    public class SymbolTableTest
    {
        private static readonly string[] words = GenerateData(ELEMENT_COUNT);

        private const int ELEMENT_COUNT = 100000;
        private const int TEST_TIMES = 1;
        private const int SAME_KEY = 20;

        private static readonly Stopwatch watch = new Stopwatch();

        public static void Test()
        {
            int flag = int.Parse(Console.ReadLine() ?? "0");

            if (flag == 1)
            {
                // Test(new SequentialSearchSymbolTable<string, int>());
                Test(new BinarySearchSymbolTable<string, int>(2));
                Test(new BinarySearchTreeSymbolTable<string, int>());
                Test(new RedBlackTreeSymbolTable<string, int>());
                Test(new SeparateChainingHashSymbolTable<string, int>());
                Test(new LinearProbingHashSymbolTable<string, int>(ELEMENT_COUNT / 2));
                Test(new RedBlackTreeHashSymbolTable<string, int>());
                Test(new CSharpDictionary<string, int>());
            }
            else if (flag == 2)
            {
                OrderedSymbolTable<Transaction, int> table =
                    new RedBlackTreeSymbolTable<Transaction, int>();

                Transaction t = new Transaction("小红", DateTime.Today, 300);
                table.Put(t, 0);

                t = new Transaction("小黄", DateTime.Today.AddDays(-2), 200);
                table.Put(t, 0);

                t = new Transaction("小蓝", DateTime.Today.AddDays(-3), 150);
                table.Put(t, 0);

                t = new Transaction("小绿", DateTime.Today.AddDays(1), 400);
                table.Put(t, 0);

                foreach (var variable in table)
                {
                    Console.WriteLine(variable);
                }
            }
        }

        private static void Test(SymbolTable<string, int> symbolTable)
        {
            Console.WriteLine(symbolTable.Name);
            watch.Reset();
            watch.Start();

            for (int t = 0; t < TEST_TIMES; t++)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (symbolTable.Contains(words[i]))
                    {
                        symbolTable.Put(words[i], symbolTable.Get(words[i]) + 1);
                    }
                    else
                    {
                        symbolTable.Put(words[i], 1);
                    }
                }
            }

            KeyValue<string, int> temp = new KeyValue<string, int>();
            foreach (KeyValue<string, int> item in symbolTable)
            {
                if (item.Value > temp.Value)
                {
                    temp = item;
                }
            }

            watch.Stop();

            Console.WriteLine("  单词：" + temp.Key);
            Console.WriteLine("  次数：" + temp.Value);
            Console.WriteLine("  用时：" + watch.Elapsed.TotalMilliseconds + " 毫秒\n");
        }

        private static string[] GenerateData(int length)
        {
            string[] data = new string[length];
            Random random = new Random();
            int diff = length / SAME_KEY;

            for (int i = 0; i < length; i++)
            {
                data[i] = (random.Next() % diff).ToString();
            }

            return data;
        }
    }
}