using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StatisticalMeasuresProject
{
    class CsvParser
    {
        public List<double> readCsv(string file_name)
        {
            List<double> list = new List<double>();

            var reader = new StreamReader(@file_name);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                double record = Convert.ToDouble(line);
                list.Add(record);
            }

            return list;
        }

        public double[] listToArray(List<double> list)
        {
            double[] array = new double[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                array[i] = list[i];
            }

            return array;
        }
    }
}
