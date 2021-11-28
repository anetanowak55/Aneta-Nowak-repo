using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticalMeasuresProject
{
    class StdDev
    {
        public bool is_asm;
        static int no_threads;
        /**
         * Calculates the sum of values in an array - a task for one of the threads.
         * 
         * @param array Array of values to be used for calculating sum.
         * @param start Starting point.
         * @param end Finishing point.
         * @param result A partial sum.
         */
        public static void calculateArraySum(double[] array, int start, int end, ref double result)
        {
            for (int i = start; i < end; i++)
            {
                result += array[i];
                Console.WriteLine(result);
            }
        }

        /**
         * Calculates an average of values in an array.
         * 
         * @param array Array of values to be used for calculating avg.
         * @param no_threads Number of threads to be used for executing calculations.
         * @returns Value of the avg.
         */
        static double calculateArrayAverage(double[] array)
        {
            TaskManager.calculateArraySumTasks(no_threads, array);
            double sum = TaskManager.start();

            return sum / array.Length;
        }

        /**
         * Calculates standard deviation of a given sample.
         * 
         * @param array Array of values to be used for calculating std dev.
         * @param no_threads Number of threads to be used for executing calculations.
         * @returns Value of the standard deviation.
         */
        public double calculateStdDev(double[] array)
        {
            double result = 0;
            double squares_sum = 0;
            double square = 0;
            double avg = calculateArrayAverage(array);

            for (int i = 0; i < array.Length; i++) // !! THREADS !!
            {
                square = Math.Pow(array[i] - avg, 2);
                squares_sum += square;
            }

            result = Math.Sqrt(squares_sum / array.Length);

            return result;
        }

        /**
         * Calculates standard deviation of a random sample for demostrative purposes.
         * 
         * @param sample_size Number of random values to be generated.
         * @param no_threads Number of threads to be used for executing calculations.
         * @returns Value of the standard deviation.
         */
        public double calculateStdDevOfRandomSample(int sample_size, int no_thread)
        {
            no_threads = no_thread;
            double[] array = new double[sample_size];
            Random rnd = new Random();

            for (int i = 0; i < sample_size; i++)
            {
                array[i] = rnd.Next();
            }

            return calculateStdDev(array);
        }
    }
}
