using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticalMeasuresProject
{
    class TaskManager : StatCal
    {
        private static List<Task> taskList = new List<Task>();
        private static double result = 0;

        public static void calculateArraySumTasks(int threadsNo, double[] array)
        {
            taskList.Clear();

            int arrayLength = array.Length;
            int recordsPerThread = arrayLength / threadsNo;
            int leftoverRecords = arrayLength % threadsNo;

            int start = 0;

            if (leftoverRecords != 0)
            {
                int start_cpy = start;
                int end = start + recordsPerThread + leftoverRecords;
                Task firstTask = new Task(() => { StatCal.calculateArraySum(array, start_cpy, end, ref result); });
                taskList.Add(firstTask);
                //Console.WriteLine(start.ToString() + " " + end.ToString());
                start = end;
            }
            else
            {
                int start_cpy = start;
                int end = start + recordsPerThread;
                Task firstTask = new Task(() => { StatCal.calculateArraySum(array, start_cpy, end, ref result); });
                taskList.Add(firstTask);
                //Console.WriteLine(start.ToString() + " " + end.ToString());
                start = end;
            }

            for (int i = 1; i < threadsNo; i++)
            {
                int start_cpy = start;
                int end = start + recordsPerThread;
                Task task = new Task(() => { StatCal.calculateArraySum(array, start_cpy, end, ref result); });
                taskList.Add(task);
                //Console.WriteLine(start.ToString() + " " + end.ToString());
                start = end;
            }

        }

        public static void calculateStdDevTasks(int threadsNo, double[] array, double avg, int added_zeros)
        {
            taskList.Clear();

            int arrayLength = array.Length;
            int recordsPerThread = arrayLength / threadsNo;
            int leftoverRecords = arrayLength % threadsNo;

            int start = 0;
            if (leftoverRecords != 0)
            {
                int start_cpy = start;
                int end = start + recordsPerThread + leftoverRecords;
                Task firstTask = new Task(() => { StatCal.calculateSumOfSqDif(array, avg, start_cpy, end, ref result); });
                taskList.Add(firstTask);
                start = end;
            }
            else
            {
                int start_cpy = start;
                int end = start + recordsPerThread;
                Task firstTask = new Task(() => { StatCal.calculateSumOfSqDif(array, avg, start_cpy, end, ref result); });
                taskList.Add(firstTask);
                start = end;
            }

            for (int i = 1; i < threadsNo; i++)
            {
                int start_cpy = start;
                int end = start + recordsPerThread;
                Task task = new Task(() => { StatCal.calculateSumOfSqDif(array, avg, start_cpy, end, ref result); });
                taskList.Add(task);
                start = end;
            }
        }

        public static void calculateAvgDevTasks(int threadsNo, double[] array, double avg, int added_zeros)
        {
            taskList.Clear();

            int arrayLength = array.Length;
            int recordsPerThread = arrayLength / threadsNo;
            int leftoverRecords = arrayLength % threadsNo;

            int start = 0;
            if (leftoverRecords != 0)
            {
                int start_cpy = start;
                int end = start + recordsPerThread + leftoverRecords;
                Task firstTask = new Task(() => { StatCal.calculateSumOfDif(array, avg, start_cpy, end, ref result); });
                taskList.Add(firstTask);
                start = end;
            }
            else
            {
                int start_cpy = start;
                int end = start + recordsPerThread;
                Task firstTask = new Task(() => { StatCal.calculateSumOfDif(array, avg, start_cpy, end, ref result); });
                taskList.Add(firstTask);
                start = end;
            }

            for (int i = 1; i < threadsNo; i++)
            {
                int start_cpy = start;
                int end = start + recordsPerThread;
                Task task = new Task(() => { StatCal.calculateSumOfDif(array, avg, start_cpy, end, ref result); });
                taskList.Add(task);
                start = end;
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
