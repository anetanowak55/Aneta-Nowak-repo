using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatisticalMeasuresProject
{
    public partial class Form1 : Form
    {
        int dataSource = 9; // 0 - csv, 1 - random
        int libraryChoice = 9; // 0 - c#, 1 - asm
        int noThreads = 1;
        TimeSpan time;

        public Form1()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
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

        private void displayOutputCs(double[] results)
        {
            textBox1.Text += "Library: C#; Time: " + time.TotalMilliseconds.ToString() + " ms; Output: std=" + results[0].ToString()
                + ", aad=" + results[1].ToString() + ", cv=" + results[2].ToString() + "\r\n";
        }

        private void displayOutputAsm(double[] results)
        {
            textBox1.Text += "Library: Asm; Time: " + time.TotalMilliseconds.ToString() + " ms; Output: std=" + results[0].ToString() 
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
                        Stopwatch stopWatch = new Stopwatch();
                        stopWatch.Start();

                        double[] results = statCal.statCalRndSample(sampleNo, noThreads, false);

                        stopWatch.Stop();
                        time = stopWatch.Elapsed;

                        displayOutputCs(results);
                    }
                    else if (libraryChoice == 1) // Asm
                    {
                        Stopwatch stopWatch = new Stopwatch();
                        stopWatch.Start();

                        double[] results = statCal.statCalRndSample(sampleNo, noThreads, true);

                        stopWatch.Stop();
                        time = stopWatch.Elapsed;

                        displayOutputAsm(results);
                    }
                    else
                    {
                        textBox1.Text += "No library was chosen." + "\r\n";
                    }
                }
                else
                {
                    textBox1.Text += "Sample size must be greater than 0." + "\r\n";
                }
            }
            else if (dataSource == 0) // data from a csv file
            {
                if (libraryChoice == 0) // C#
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();

                    double[] results = statCal.statCalFromCsv(noThreads, false);

                    stopWatch.Stop();
                    time = stopWatch.Elapsed;

                    displayOutputCs(results);
                }
                else if (libraryChoice == 1) // Asm
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();

                    double[] results = statCal.statCalFromCsv(noThreads, true);

                    stopWatch.Stop();
                    time = stopWatch.Elapsed;

                    displayOutputAsm(results);
                }
                else
                {
                    textBox1.Text += "No library was chosen." + "\r\n";
                }
            }
            else
            {
                textBox1.Text += "No source of data was chosen." + "\r\n";
            }
        }

        
    }
}
