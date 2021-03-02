using System;
using System.Diagnostics;
using static _2_Sort.PriorityQueue.PriorityQueueTest;

namespace _2_Sort
{
    /*
     * 测试各种排序算法
     */
    public class SortTest
    {
        private const int dataCount = 500000;
        private static Stopwatch stopwatch = new Stopwatch();
        private static int[] bestData;
        private static int[] randomData;
        private static int[] worstData;

        private const int flag = 0;

        private static BubbleSort bubbleSort = new BubbleSort();
        private static SelectSort selectSort = new SelectSort();
        private static InsertSort insertSort = new InsertSort();
        private static ShellSort shellSort = new ShellSort();
        private static MergeSort mergeSortBT = new MergeSort(true);
        private static MergeSort mergeSortBU = new MergeSort(false);
        private static QuickSort quickSort = new QuickSort();
        private static HeapSort heapSort = new HeapSort();
        private static CSharpSort cSharpSort = new CSharpSort();

        public static void Test()
        {
            if (flag == 1)
            {
                int[] arr = WorstData(30);
                //new CSharpSort().Sort(arr);
                new CSharpSort().Test(arr, (x, y) => y - x);
                Print(arr);
            }
            else
            {
                bestData = BestData(dataCount);
                randomData = RandomData(dataCount);
                worstData = WorstData(dataCount);

                //Test(bubbleSort);
                //Test(selectSort);
                //Test(insertSort);
                Test(shellSort);
                Test(mergeSortBT);
                Test(mergeSortBU);
                Test(quickSort);
                Test(heapSort);
                Test(cSharpSort);
            }
        }

        private static void Test(ISorter sorter)
        {
            int[] temp = new int[dataCount];
            Console.WriteLine(sorter.Name);

            Array.Copy(bestData, 0, temp, 0, dataCount);
            Console.WriteLine("    最好：" + Sort(sorter, temp));

            Array.Copy(randomData, 0, temp, 0, dataCount);
            Console.WriteLine("    随机：" + Sort(sorter, temp));

            Array.Copy(worstData, 0, temp, 0, dataCount);
            Console.WriteLine("    最差：" + Sort(sorter, temp) + "\n");
        }

        private static double Sort<T>(ISorter sorter, T[] arr) where T : IComparable<T>
        {
            stopwatch.Reset();
            stopwatch.Start();
            sorter.Sort(arr);
            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }

        private static int[] BestData(int count)
        {
            int[] arr = new int[count];

            for (int i = 0; i < count; i++)
            {
                arr[i] = i;
            }

            return arr;
        }

        private static int[] RandomData(int count)
        {
            int[] arr = new int[count];
            Random random = new Random();
            int max = count * 3;

            for (int i = 0; i < count; i++)
            {
                arr[i] = random.Next() % max;
            }

            return arr;
        }

        private static int[] WorstData(int count)
        {
            int[] arr = new int[count];

            for (int i = 0; i < count; i++)
            {
                arr[i] = count - i;
            }

            return arr;
        }

        private static void Print<T>(T[] arr) where T : IComparable<T>
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
