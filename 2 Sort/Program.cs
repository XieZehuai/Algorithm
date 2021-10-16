using System;
using _2_Sort.PriorityQueue;

namespace _2_Sort
{
    public class Program
    {
        private static void Main(string[] args)
        {
            int[] data = new int[] { 6, 78, 45, 34, 1, 6, 8, 3 };
            PriorityQueue<int> queue = new PriorityQueue<int>(data);

            while (!queue.IsEmpty)
            {
                Console.Write(queue.Dequeue() + " ");
            }
        }
    }
}
