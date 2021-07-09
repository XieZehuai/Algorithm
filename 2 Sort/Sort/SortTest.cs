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
        private const int DATA_COUNT = 500000;

        private static readonly Stopwatch stopwatch = new Stopwatch();

        private static int[] bestData;
        private static int[] randomData;
        private static int[] worstData;

        private const int FLAG = 0;

        private static BubbleSort<int> bubbleSort = new BubbleSort<int>();
        private static SelectSort<int> selectSort = new SelectSort<int>();
        private static InsertSort<int> insertSort = new InsertSort<int>();
        private static ShellSort<int> shellSort = new ShellSort<int>();
        private static MergeSort<int> mergeSortBT = new MergeSort<int>(true);
        private static MergeSort<int> mergeSortBU = new MergeSort<int>(false);
        private static QuickSort<int> quickSort = new QuickSort<int>();
        private static HeapSort<int> heapSort = new HeapSort<int>();
        private static CSharpSort<int> cSharpSort = new CSharpSort<int>();

        public static void Test()
        {
            if (FLAG == 1)
            {
                int[] arr = WorstData(30);
                cSharpSort.Sort(arr, (x, y) => y - x);
                Print(arr);
            }
            else
            {
                bestData = BestData(DATA_COUNT);
                randomData = RandomData(DATA_COUNT);
                worstData = WorstData(DATA_COUNT);

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

        private static void Test(ISorter<int> sorter)
        {
            int[] temp = new int[DATA_COUNT];
            Console.WriteLine(sorter.Name);

            Array.Copy(bestData, 0, temp, 0, DATA_COUNT);
            Console.WriteLine("    最好：" + Sort(sorter, temp));

            Array.Copy(randomData, 0, temp, 0, DATA_COUNT);
            Console.WriteLine("    随机：" + Sort(sorter, temp));

            Array.Copy(worstData, 0, temp, 0, DATA_COUNT);
            Console.WriteLine("    最差：" + Sort(sorter, temp) + "\n");
        }

        private static double Sort<T>(ISorter<T> sorter, T[] data)
        {
            stopwatch.Reset();
            stopwatch.Start();
            sorter.Sort(data);
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
