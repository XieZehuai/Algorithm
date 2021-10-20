using System;
using System.Diagnostics;

namespace Test
{
    public static class Timer
    {
        private static Stopwatch stopwatch = new Stopwatch();

        /// <summary>
        /// 执行操作并计算耗时
        /// </summary>
        /// <param name="log">是否打印耗时信息</param>
        /// <param name="action">要执行的操作</param>
        /// <returns>耗时</returns>
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
