﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace StatisticalMeasuresProject
{
    class StatCal
    {
        [DllImport(@"C:\Users\aneta\Documents\GitHub\Aneta-Nowak-repo\StatisticalMeasuresProject\x64\Debug\SumAsm.dll")]
        static extern double SumAsm(double[] array, int start, int end, ref double result);
        [DllImport(@"C:\Users\aneta\Documents\GitHub\Aneta-Nowak-repo\StatisticalMeasuresProject\x64\Debug\StdAsm.dll")]
        static extern double StdDevAsm(double[] array, double avg, int start, int end, ref double result);
        [DllImport(@"C:\Users\aneta\Documents\GitHub\Aneta-Nowak-repo\StatisticalMeasuresProject\x64\Debug\AvgAsm.dll")]
        static extern double AvgDevAsm(double[] array, double avg, int start, int end, ref double result);

        public static bool is_asm;
        static int no_threads;
        static int added_zeros = 0;
        double array_avg = 0;
        readonly int no_decimal_places = 4;

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
            if (is_asm == false)
            {
                for (int i = start; i < end; i++)
                {
                    result += array[i];
                }
            }
            else
            {
                result = SumAsm(array, start, end, ref result);
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

            return sum / (array.Length - added_zeros);
        }

        /**
         * Calculates standard deviation of a given sample.
         * 
         * @param array Array of values to be used for calculating std dev.
         * @param no_threads Number of threads to be used for executing calculations.
         * @returns Value of the standard deviation.
         */
        private double calculateStdDev(double[] array)
        {
            double result = 0;
            array_avg = calculateArrayAverage(array);

            TaskManager.calculateStdDevTasks(no_threads, array, array_avg, added_zeros);
            double squares_sum = TaskManager.start();

            result = Math.Sqrt(squares_sum / (array.Length - added_zeros));

            return result;
        }

        /**
         * Calculates average absolute deviation of a given sample.
         * 
         * @param array Array of values to be used for calculating aad.
         * @param no_threads Number of threads to be used for executing calculations.
         * @returns Value of the average absolute deviation.
         */
        private double calculateAvgDev(double[] array)
        {
            TaskManager.calculateAvgDevTasks(no_threads, array, array_avg, added_zeros);
            double dif_sum = TaskManager.start();

            return dif_sum / (array.Length - added_zeros);
        }

        /**
         * Calculates the sum of differences - a task for one of the threads.
         * 
         * @param array Array of values to be used for calculations
         * @param avg Average of values in the array.
         * @param start Starting point.
         * @param end Finishing point.
         * @param result A partial result.
         */
        public static void calculateSumOfDif(double[] array, double avg, int start, int end, ref double result)
        {
            if (is_asm == false)
            {
                for (int i = start; i < end; i++)
                {
                    result += Math.Abs(array[i] - avg);
                }
            }
            else
            {
                result = AvgDevAsm(array, avg, start, end, ref result);

                double zeros_adjustment = added_zeros * avg;
                result -= zeros_adjustment;
            }
        }

        /**
         * Calculates the sum of squared differences - a task for one of the threads.
         * 
         * @param array Array of values to be used for calculations
         * @param avg Average of values in the array.
         * @param start Starting point.
         * @param end Finishing point.
         * @param result A partial result.
         */
        public static void calculateSumOfSqDif(double[] array, double avg, int start, int end, ref double result)
        {
            if (is_asm == false)
            {
                for (int i = start; i < end; i++)
                {
                    result += Math.Pow(array[i] - avg, 2);
                }
            }
            else
            {
                result = StdDevAsm(array, avg, start, end, ref result); 

                double zeros_adjustment = added_zeros * Math.Pow(0 - avg, 2);
                result -= zeros_adjustment;
            }
        }

        /**
         * Calculates satistical measures of a random sample for demostrative purposes.
         * 
         * @param sample_size Number of random values to be generated.
         * @param no_thread Number of threads to be used for executing calculations.
         * @param asm Boolean value indicating if the asm library should be used.
         * @returns double[] array of results
         */
        public double[] statCalRndSample(int sample_size, int no_thread, bool asm)
        {
            is_asm = asm;
            no_threads = no_thread;

            if (sample_size % 4 != 0)
            {
                added_zeros = 4 - sample_size % 4;
            }

            double[] array = new double[sample_size + added_zeros];
            Random rnd = new Random();

            for (int i = 0; i < sample_size; i++)
            {
                array[i] = rnd.Next();
            }
            for (int i = 0; i< added_zeros; i++)
            {
                array[sample_size + i] = 0;
            }

            for (int i = 0; i < array.Length; i++)
                Console.WriteLine(array[i] + " ");

            double[] results = new double[3];
            results[0] = Math.Round(calculateStdDev(array), no_decimal_places);
            results[1] = Math.Round(calculateAvgDev(array), no_decimal_places);
            results[2] = Math.Round(results[0] / array_avg, no_decimal_places);

            return results;
        }

        /**
         * Calculates satistical measures of a sample represented in a csv file.
         * 
         * @param no_thread Number of threads to be used for executing calculations.
         * @param asm Boolean value indicating if the asm library should be used.
         * @returns double[] array of results
         */
        public double[] statCalFromCsv(int no_thread, bool asm)
        {
            is_asm = asm;
            no_threads = no_thread;
            CsvParser csvParser = new CsvParser();
            string file_name = @"C:\Users\aneta\Documents\GitHub\Aneta-Nowak-repo\StatisticalMeasuresProject\csv_files\data1.csv";

            List<double> list = csvParser.readCsv(file_name);

            if (list.Count % 4 != 0)
            {
                added_zeros = 4 - list.Count % 4;
                for (int i = 0; i < added_zeros; i++)
                {
                    list.Add(0);
                }
            }

            double[] array = csvParser.listToArray(list);

            double[] results = new double[3];
            results[0] = Math.Round(calculateStdDev(array), no_decimal_places);
            results[1] = Math.Round(calculateAvgDev(array), no_decimal_places);
            results[2] = Math.Round(results[0] / array_avg, no_decimal_places);

            return results;
        }
    }
}