using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticalMeasuresProject
{
    class StdDev
    {
        /**
         * Calculates the sum of values in an array.
         * 
         * @param array Array of values to be used for calculating sum.
         * @returns Value of the sum.
         */
        static int calculateArraySum(int[] array)
        {
            int result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i];
            }
            return result;
        }

        /**
         * Calculates an average of values in an array.
         * 
         * @param array Array of values to be used for calculating avg.
         * @returns Value of the avg.
         */
        static double calculateArrayAverage(int[] array)
        {
            return calculateArraySum(array) / array.Length;
        }

        /**
         * Calculates standard deviation of a given sample.
         * 
         * @param array Array of values to be used for calculating std dev.
         * @returns Value of the standard deviation.
         */
        public double calculateStdDev(int[] array)
        {
            double result = 0;
            double squares_sum = 0;
            double square = 0;
            double avg = calculateArrayAverage(array);

            for (int i = 0; i < array.Length; i++)
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
         * @returns Value of the standard deviation.
         */
        public double calculateStdDevOfRandomSample(int sample_size)
        {
            int[] array = new int[sample_size];
            Random rnd = new Random();

            for (int i = 0; i < sample_size; i++)
            {
                array[i] = rnd.Next();
            }

            return calculateStdDev(array);
        }
    }
}
