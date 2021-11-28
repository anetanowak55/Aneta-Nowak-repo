using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticalMeasuresProject
{
    class TaskManager : StdDev
    {
        private static int threadsNo;
        private static int arrayLength;
        private static List<Task> taskList = new List<Task>();
        private static double result = 0;

        public static void calculateArraySumTasks(int threadsNo, double[] array)
        {
            taskList.Clear();

            int arrayLength = array.Length;
            if (threadsNo > arrayLength)
                threadsNo = arrayLength;

            int recordsPerThread = arrayLength / threadsNo;
            int leftoverRecords = arrayLength % threadsNo;

            int start = 0;
            for (int i = 0; i < threadsNo; i++)
            {
                int start_cpy = start;
                Task task = new Task(() => { StdDev.calculateArraySum(array, start_cpy, start_cpy + recordsPerThread, ref result); });
                taskList.Add(task);
                start += recordsPerThread;
            }
        }

        public static double start()
        {
            result = 0;

            Task[] arr = taskList.ToArray();
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i].Start();
            }
            Task.WaitAll(arr);

            return result;
        }
    }
}
