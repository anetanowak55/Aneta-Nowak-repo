using System;

namespace OperationsCs
{
    public class Class1
    {
        double Sum (double[] array, int start, int end)
        {
            double result = 0;

            for (int i = start; i < end; i++)
            {
                result += array[i];
            }
            return result;
        }
    }
}
