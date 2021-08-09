using System;
using System.Collections.Generic;

namespace _2_Sort
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Queue<int> q = new Queue<int>();
            int[] data = new int[20];
            Random rd = new Random();
            PriorityQueue<int> queue = new PriorityQueue<int>(Compare: (a, b) =>
            {
                return b - a;
            });

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;
                q.Enqueue(i * 2);
                Console.Write(data[i] + " ");
            }
            Console.WriteLine();

            int k = 10;
            for (int i = 0; i < k; i++)
            {
                queue.Enqueue(data[i]);
            }

            for (int i = k; i < data.Length; i++)
            {
                if (data[i] > queue.Peek())
                {
                    queue.Dequeue();
                    queue.Enqueue(data[i]);
                }
            }

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }

    internal class Test : IComparable<Test>
    {
        public int id;

        public Test(int id)
        {
            this.id = id;
        }

        public int CompareTo(Test other)
        {
            return id - other.id;
        }

        public override string ToString()
        {
            return id.ToString();
        }
    }
}
