using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    public class calculate
    {
        public calculate() {; }
        public static double Sum(double[] array, int start, int end)
        {
            double result = 0;

            for (int i = start; i < end; i++)
            {
                result += array[i];
            }
            return result;
        }

        public static double SumOfDif(double[] array, double avg, int start, int end)
        {
            double result = 0;

            double temp_result = 0;
            for (int i = start; i < end; i++)
            {
                temp_result += Math.Abs(array[i] - avg);
            }
            result += temp_result;

            return result;
        }

        public static double SumOfSqDif(double[] array, double avg, int start, int end)
        {
            double result = 0;

            for (int i = start; i < end; i++)
            {
                result += Math.Pow(array[i] - avg, 2);
            }

            return result;
        }
    }
}
