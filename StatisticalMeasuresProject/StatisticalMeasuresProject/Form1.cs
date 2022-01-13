using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatisticalMeasuresProject
{
    public partial class Form1 : Form
    {
        int dataSource = 9; // 0 - csv, 1 - random
        int libraryChoice = 9; // 0 - c#, 1 - asm
        int noThreads = Environment.ProcessorCount;
        int noIterations = 1;
        double timeNumeric;
        String filePath = null;

        public Form1()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
            threadNoNumerpicUpDown.Value = noThreads;
        }

        private void csvFileRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            dataSource = 0;
        }

        private void randSampleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            dataSource = 1;
        }

        private void cSharpRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            libraryChoice = 0;
        }

        private void assemblyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            libraryChoice = 1;
        }

        private void threadNoNumerpicUpDown_ValueChanged(object sender, EventArgs e)
        {
            noThreads = Decimal.ToInt32(threadNoNumerpicUpDown.Value);
        }

        private void noIterationsNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            noIterations = Decimal.ToInt32(noIterationsNumericUpDown1.Value);
        }

        private void displayOutputCs(double[] results)
        {
            textBox1.Text += "Library: C#; Time: " + timeNumeric.ToString() + " ms; Output: std=" + results[0].ToString()
                + ", aad=" + results[1].ToString() + ", cv=" + results[2].ToString() + "\r\n";
        }

        private void displayOutputAsm(double[] results)
        {
            textBox1.Text += "Library: Asm; Time: " + timeNumeric.ToString() + " ms; Output: std=" + results[0].ToString() 
                + ", aad=" + results[1].ToString() + ", cv=" + results[2].ToString() + "\r\n";
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            StatCal statCal = new StatCal();

            if (dataSource == 1) // random sample
            {
                int sampleNo = Decimal.ToInt32(sampleNoNumericUpDown.Value);
                if (sampleNo > 0)
                {
                    if (libraryChoice == 0) // C#
                    {
                        double[] results = new double[3];
                        TimeSpan time = new TimeSpan();
                        for (int i = 0; i < noIterations; i++)
                        {
                            Stopwatch stopWatch = new Stopwatch();
                            stopWatch.Start();

                            results = statCal.statCalRndSample(sampleNo, noThreads, false);

                            stopWatch.Stop();
                            time += stopWatch.Elapsed;
                        }

                        timeNumeric = time.TotalMilliseconds / noIterations;
                        displayOutputCs(results);
                    }
                    else if (libraryChoice == 1) // Asm
                    {
                        double[] results = new double[3];
                        TimeSpan time = new TimeSpan();
                        for (int i = 0; i < noIterations; i++)
                        {
                            
                            Stopwatch stopWatch = new Stopwatch();
                            stopWatch.Start();

                            results = statCal.statCalRndSample(sampleNo, noThreads, true);

                            stopWatch.Stop();
                            time += stopWatch.Elapsed;
                        }

                        timeNumeric = time.TotalMilliseconds / noIterations;
                        displayOutputAsm(results);
                    }
                    else
                    {
                        displayMessage("No library was chosen.");
                    }
                }
                else
                {
                    displayMessage("Sample size must be greater than 0.");
                }
            }
            else if (dataSource == 0) // data from a csv file
            {
                if (String.IsNullOrEmpty(filePath))
                {
                    displayMessage("You must choose a csv file.");
                    return;
                }
                if (libraryChoice == 0) // C#
                {
                    double[] results = new double[3];
                    TimeSpan time = new TimeSpan();
                    for (int i = 0; i < noIterations; i++)
                    {
                        Stopwatch stopWatch = new Stopwatch();
                        stopWatch.Start();

                        results = statCal.statCalFromCsv(noThreads, false, filePath);
                        

                        stopWatch.Stop();
                        time += stopWatch.Elapsed;
                    }

                    timeNumeric = time.TotalMilliseconds / noIterations;
                    displayOutputCs(results);
                }
                else if (libraryChoice == 1) // Asm
                {
                    double[] results = new double[3];
                    TimeSpan time = new TimeSpan();
                    for (int i = 0; i < noIterations; i++)
                    {
                        Stopwatch stopWatch = new Stopwatch();
                        stopWatch.Start();

                        results = statCal.statCalFromCsv(noThreads, true, filePath);

                        stopWatch.Stop();
                        time += stopWatch.Elapsed;
                    }

                    timeNumeric = time.TotalMilliseconds / noIterations;
                    displayOutputAsm(results);
                }
                else
                {
                    displayMessage("No library was chosen.");
                }
            }
            else
            {
                displayMessage("No source of data was chosen.");
            }
        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "C:\\Users\\aneta\\Documents\\GitHub\\Aneta-Nowak-repo\\StatisticalMeasuresProject\\test_data";
            openFileDialog.Filter = "csv files (*.csv)|*.csv";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;
            }
        }

        private void displayMessage(string message)
        {
            textBox1.Text += message + "\r\n";
        }

        private void cleanButton_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
