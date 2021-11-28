using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticalMeasuresProject
{
    class ThreadManager
    {
        private static int threadsCount;
        private static int AvailableThreadsCount;
        public static readonly int MAX_THREADS = 64;

        public static void InitThreadsManagement(int threads)
        {
            threadsCount = threads;
            AvailableThreadsCount = threads;
        }

        public static bool IsThreadAvailable()
        {
            return true ? (AvailableThreadsCount > 0) : false;
        }
        public static void ReleaseThread()
        {
            AvailableThreadsCount += 1;
        }

        public static void GetThread()
        {
            AvailableThreadsCount -= 1;
        }

        public static int GetThreadsCount()
        {
            return threadsCount;
        }

        public static int GetAvailableCount()
        {
            return AvailableThreadsCount;
        }
    }
}
