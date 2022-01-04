using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticalMeasuresProject
{
    class TaskManager : StatCal
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
            if (leftoverRecords != 0)
            {
                Task firstTask = new Task(() => { StatCal.calculateArraySum(array, start, start + recordsPerThread + leftoverRecords, ref result); });
                taskList.Add(firstTask);
            }
            else
            {
                Task firstTask = new Task(() => { StatCal.calculateArraySum(array, start, start + recordsPerThread, ref result); });
                taskList.Add(firstTask);
            }

            for (int i = 1; i < threadsNo; i++)
            {
                int start_cpy = start;
                Task task = new Task(() => { StatCal.calculateArraySum(array, start_cpy, start_cpy + recordsPerThread, ref result); });
                taskList.Add(task);
                start += recordsPerThread;
            }

        }

        public static void calculateStdDevTasks(int threadsNo, double[] array, double avg, int added_zeros)
        {
            taskList.Clear();

            int arrayLength = array.Length - added_zeros;
            if (threadsNo > arrayLength)
                threadsNo = arrayLength;

            int recordsPerThread = arrayLength / threadsNo;
            int leftoverRecords = arrayLength % threadsNo;

            int start = 0;
            if (leftoverRecords != 0)
            {
                Task firstTask = new Task(() => { StatCal.calculateDev(array, avg, start, start + recordsPerThread + leftoverRecords, ref result); });
                taskList.Add(firstTask);
            }
            else
            {
                Task firstTask = new Task(() => { StatCal.calculateDev(array, avg, start, start + recordsPerThread, ref result); });
                taskList.Add(firstTask);
            }

            for (int i = 1; i < threadsNo; i++)
            {
                int start_cpy = start;
                Task task = new Task(() => { StatCal.calculateDev(array, avg, start_cpy, start_cpy + recordsPerThread, ref result); });
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
            Task.WaitAll(arr); // tu pojawia sie blad przy uzyciu biblioteki asm
                               // komunikat: "W bibliotece DLL '...' nie można znaleźć punktu wejścia o nazwie 'StdAsm'."


            return result;
        }
    }
}
