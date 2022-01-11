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

            try
            {
                var reader = new StreamReader(@file_name);
                double record = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    string[] tokens = line.Split(';');
                    foreach (string s in tokens)
                    {
                        if (double.TryParse(s, out record))
                            list.Add(record);
                    }
                }
            }
            catch (IOException e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw e;
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
