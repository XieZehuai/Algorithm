using System;
using System.Diagnostics;

namespace Test
{
    public static class Timer
    {
        private static Stopwatch stopwatch = new Stopwatch();

        public static long Counting(bool log, Action action)
        {
            stopwatch.Restart();
            action();
            stopwatch.Stop();

            if (log)
            {
                Console.WriteLine($"耗时 {stopwatch.ElapsedMilliseconds.ToString()} 毫秒");
            }

            return stopwatch.ElapsedMilliseconds;
        }
    }
}
