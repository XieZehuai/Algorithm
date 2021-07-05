using System;

namespace _1_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Bag<int> bag = new Bag<int>();

            int n;
            while ((n = int.Parse(Console.ReadLine())) != 0)
            {
                bag.Add(n);
            }

            Console.WriteLine(bag.Count);
            foreach (var item in bag)
            {
                Console.Write(item + " ");
            }
        }
    }
}
